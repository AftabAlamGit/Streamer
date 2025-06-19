using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestreamerClient.Interfaces
{
    public interface IStreamerManager
    {
        public void StartStreaming(string input, string output);
        public void StopStreaming(string input);
    }
}
