using System.ComponentModel.DataAnnotations;

namespace DataMonitorWeb.Models
{
    [MetadataType(typeof(WatcherMetaData))]
    public partial class Watcher
    {
    }

    public class WatcherMetaData
    {
        [Required]
        public string Name { get; set; }
    }
}