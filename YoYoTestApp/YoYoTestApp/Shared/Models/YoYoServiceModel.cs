using System;
using System.Collections.Generic;
using System.Text;

namespace YoYoTestApp.Shared.Models
{
    public class YoYoServiceModel
    {
        public List<Athlete> Athletes { get; set; }
        public List<TestModel> Tests { get; set; }
        public bool IsProcessStarted { get; set; }
        public TestModel TestModel { get; set; }

        public TimeSpan NextShuttle { get; set; }
        public string NextShuttleString { get; set; }
        public int TotalTime { get; set; }
        public int TotalDistance { get; set; }
        public int Level { get; set; }
        public int Shuttle { get; set; }
        public double ShuttleSpeed { get; set; }

        public bool IsStarted { get; set; }

        public double ShuttleTimeLeft { get; set; }
        public double ShuttleTimeElapsed { get; set; }

        public TimeSpan ShuttleLength { get; set; }
    }
}
