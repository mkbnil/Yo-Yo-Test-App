using System;
using System.Collections.Generic;
using YoYoTestWeb.ViewModels;

namespace YoYoTestWeb.Services
{
    public class YoYoService
    {
        public List<Athlete> Athletes { get; set; }
        public bool IsProcessStarted { get; set; }
        public TestModel TestModel { get; set; }

        public TimeSpan NextShuttle { get; set; }
        public string NextShuttleString { get; set; }
        public TimeSpan TotalTime { get; set; }
        public int TotalDistance { get; set; }
        public int Level { get; set; }
        public int Shuttle { get; set; }
        public double ShuttleSpeed { get; set; }

        public bool IsStarted { get; set; }

        public TimeSpan ShuttleLength { get; set; }
        public YoYoService()
        {
            Athletes = GetInitialData();
            IsProcessStarted = false;
            TestModel = new TestModel();
            IsStarted = false;
            ShuttleLength = new TimeSpan(0, 1, 0);
        }

        public List<Athlete> GetInitialData()
        {
            var result = new List<Athlete>();
            result.Add(new Athlete()
            {
                Id = 1,
                IsStopped = false,
                IsWarned = false,
                Level = 0,
                Name = "Ashton Eaton",
                Shuttle = 0
            });
            result.Add(new Athlete()
            {
                Id = 2,
                IsStopped = false,
                IsWarned = false,
                Level = 0,
                Name = "Bryan Clay",
                Shuttle = 0
            });
            result.Add(new Athlete()
            {
                Id = 3,
                IsStopped = false,
                IsWarned = false,
                Level = 0,
                Name = "Dean Karnazes",
                Shuttle = 0
            });
            result.Add(new Athlete()
            {
                Id = 4,
                IsStopped = false,
                IsWarned = false,
                Level = 0,
                Name = "Usain Bolt",
                Shuttle = 0
            });

            return result;
        }

        public void Warn(Athlete athlete)
        {
            if (!athlete.IsWarned)
            {
                athlete.IsWarned = true;
                athlete.WarnText = "Warned"; 
            }
            else
            {
                athlete.IsStopped = true;
            }
        }

        public void Stop(Athlete athlete)
        {
            athlete.IsStopped = true;
        }


        public void OneShuttleCompleted(TimeSpan timespan)
        {
            TotalTime = TotalTime.Add(timespan);
            Level += 1;
            Shuttle += 1;
        }
    }    
}
