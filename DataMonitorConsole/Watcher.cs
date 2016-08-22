using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMonitorConsole
{
    class Watcher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LevelName { get; set; }
        public int? ClientId { get; set; }
        public string ClientName { get; set; }
        public string DBServer { get; set; }
        public string Database { get; set; }        
        public int? SourceId { get; set; }
        public string SourceName { get; set; }
        public string Table { get; set; }
        public int? MetricId { get; set; }
        public string MetricName { get; set; }
        public string Email { get; set; }
        public long? LastValue { get; set; }
        public string ThreasholdName { get; set; }
        public int Percentage { get; set; }        
    }
}
