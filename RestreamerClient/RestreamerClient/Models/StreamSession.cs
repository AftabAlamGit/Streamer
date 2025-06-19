using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestreamerClient.Models
{
    public class StreamSession
    {
        public string InputUrl { get; set; }
        public string OutputUrl { get; set; }
        public DateTime StartTime { get; set; }
        public System.Diagnostics.Process Process { get; set; }
    }
}
