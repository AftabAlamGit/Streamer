using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestreamerClient.Services
{
    public class FFmpegService
    {
        public Process StartRestream(string input, string output)
        {
            var args = $"-re -i \"{input}\" -c:v copy -f flv \"{output}\"";

            var psi = new ProcessStartInfo
            {
                FileName = "ffmpeg",
                Arguments = args,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            };

            var process = new Process { StartInfo = psi };
            process.Start();
            return process;
        }

        public void StopRestream(Process process)
        {
            if (!process.HasExited)
                process.Kill();
        }
    }
}
