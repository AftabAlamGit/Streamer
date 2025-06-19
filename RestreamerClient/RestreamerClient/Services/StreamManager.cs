using RestreamerClient.Interfaces;
using RestreamerClient.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestreamerClient.Services
{
    public class StreamManager : IStreamerManager
    {
        private readonly ConcurrentDictionary<string, StreamSession> _sessions = new();
        private readonly FFmpegService _ffmpegService = new();

        public void StartStreaming(string inputUrl, string outputUrl)
        {
            if (_sessions.ContainsKey(inputUrl)) return;

            var process = _ffmpegService.StartRestream(inputUrl, outputUrl);

            var session = new StreamSession
            {
                InputUrl = inputUrl,
                OutputUrl = outputUrl,
                StartTime = DateTime.Now,
                Process = process
            };

            _sessions.TryAdd(inputUrl, session);
        }

        public void StopStreaming(string inputUrl)
        {
            if (_sessions.TryRemove(inputUrl, out var session))
            {
                _ffmpegService.StopRestream(session.Process);
            }
        }

        public void AddStreamingUrl()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> ActiveStreams => _sessions.Keys;
    }
}
