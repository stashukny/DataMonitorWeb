using log4net;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;


namespace DataMonitorConsole
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        private static WatchersDataDataContext DB = new WatchersDataDataContext();
        static void Main(string[] args)
        {
            GetWatchers();
        }

        private static void GetWatchers()
        {
            try
            {
                //Calc metrics
                var metricWatchers = DB.vWatchers.Where(l => l.LevelName == "Metric");
                foreach (var m in metricWatchers)
                {
                    CalculateAverage(m, null);
                }

                //Aggregate Metrics to Sources
                var sourceWatchers = DB.vWatchers.Where(l => l.LevelName == "Source");
                foreach (var so in sourceWatchers)
                {
                    var aggMetrics = DB.vWatchers.Where(l => l.LevelName == "Metric" && l.SourceId == so.SourceId);
                    CalculateAverage(so, aggMetrics);
                }

                //Aggregate Sources to Clients
                var clientWatchers = DB.vWatchers.Where(l => l.LevelName == "Client");
                foreach (var c in clientWatchers)
                {
                    var aggSources = DB.vWatchers.Where(l => l.LevelName == "Source" && l.ClientId == c.ClientId);
                    CalculateAverage(c, aggSources);
                }

                //Aggregate Clients to System
                var systemWatchers = DB.vWatchers.Where(l => l.LevelName == "System");
                foreach (var s in systemWatchers)
                {
                    var aggClients = DB.vWatchers.Where(l => l.LevelName == "Client");
                    CalculateAverage(s, aggClients);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
        private static void CalculateAverage(vWatcher watcher, IQueryable<vWatcher> aggRows)
        {

            long? newAvg = null;

            try
            {
                if (aggRows != null)
                {
                    newAvg = Convert.ToInt64(aggRows.Average(a => a.LastValue));
                }
                else
                {
                    SqlConnection conn = new SqlConnection(
                "Data Source=" + watcher.DBServer + ";Initial Catalog=" + watcher.Database + ";Integrated Security=True");
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT AVG(" + watcher.MetricName + ") FROM " + watcher.Table, conn);
                    newAvg = Convert.ToInt64(cmd.ExecuteScalar());
                }
                if (!CheckBounds(watcher, newAvg))
                {
                    Notify(watcher.Email, watcher, newAvg);
                    //Notify
                }

                var updateWatcher = DB.Watchers.Single(l => l.Id == watcher.Id);
                updateWatcher.LastValue = newAvg;
                DB.SubmitChanges();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private static bool CheckBounds(vWatcher w, long? newValue)
        {
            bool result = false;
            try
            {
                long lastValueCompare = Convert.ToInt64(w.LastValue);
                long lowerBound = lastValueCompare - (lastValueCompare / 100 * w.Percentage);
                long upperBound = lastValueCompare + (lastValueCompare / 100 * w.Percentage);

                if (w.LastValue != null)
                {
                    if (newValue >= lowerBound && newValue <= upperBound)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            return result;
        }
        private static void Notify(string notify, vWatcher w, long? newAvg)
        {
            string fromEmail = ConfigurationManager.AppSettings["FromEmail"];
            string SMTPServer = ConfigurationManager.AppSettings["SMTPServer"];
            string SMTPPassword = ConfigurationManager.AppSettings["SMTPPassword"];

            try
            {
                SmtpClient client = new SmtpClient();
                client.Credentials = new NetworkCredential(fromEmail, SMTPPassword);
                client.Port = 587;
                client.Host = SMTPServer;
                client.EnableSsl = true;

                MailAddress
                    maFrom = new MailAddress(fromEmail, fromEmail, Encoding.UTF8),
                    maTo = new MailAddress(notify, notify, Encoding.UTF8);
                MailMessage mmsg = new MailMessage(maFrom.Address, maTo.Address);
                mmsg.Body = "<html><body>Watcher Level: " + w.LevelName + "<br/>"
                            + "Watcher: " + w.Name + "<br/>";
                if (string.IsNullOrEmpty(w.ClientName))
                {
                    mmsg.Body += "Client: " + w.ClientName + "<br/>";
                }
                if (string.IsNullOrEmpty(w.SourceName))
                {
                    mmsg.Body += "Source: " + w.SourceName + "<br/>";
                }
                if (string.IsNullOrEmpty(w.Table))
                {
                    mmsg.Body += "Table: " + w.Table + "<br/>";
                }
                if (string.IsNullOrEmpty(w.MetricName))
                {
                    mmsg.Body += "Metric: " + w.MetricName + "<br/>";
                }
                mmsg.Body += "<br/><br/>New Value: " + newAvg + " is beyond " + w.Percentage + "percent threashold of Last Value: " + w.LastValue + "</body></html>";
                mmsg.BodyEncoding = Encoding.UTF8;
                mmsg.IsBodyHtml = true;
                mmsg.Subject = "Temp";
                mmsg.SubjectEncoding = Encoding.UTF8;

                client.Send(mmsg);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
    }

}