using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoYoTestApp.Shared.Models;

namespace YoYoTestApp.Server.Services
{
    public class YoYoService : IYoYoService
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
        public YoYoService()
        {
            Athletes = LoadAthletes();
            Tests = LoadTests();
            IsProcessStarted = false;
            IsStarted = false;
            ShuttleLength = new TimeSpan(0, 1, 0);
        }

        public List<Athlete> LoadAthletes()
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

        public List<TestModel> LoadTests()
        {
            var _tests = new List<TestModel>();
            var test = new TestModel()
            {
                AccumulatedShuttleDistance = 40,
                Speedlevel = 1,
                ShuttleNo = 5,
                Speed = 10,
                LevelTime = 14.4f,
                CommulativeTime = new TimeSpan(),
                StartTime = new TimeSpan(),
                ApproxVo2Max = 36.74

            };
            _tests.Add(test);
            test = new TestModel()
            {
                AccumulatedShuttleDistance = 80,
                Speedlevel = 2,
                ShuttleNo = 1,
                Speed = 12,
                LevelTime = 12.5,
                CommulativeTime = new TimeSpan(),
                StartTime = new TimeSpan(),
                ApproxVo2Max = 37.07

            };
            _tests.Add(test);

            return _tests;

        }
        public void Warn(int Id)
        {
            Athletes.Where(i => i.Id == Id && i.IsWarned == true).FirstOrDefault(i => i.IsStopped = true);
            Athletes.Where(i => i.Id == Id && i.IsWarned == false).FirstOrDefault(i => i.IsWarned = true);  
        }

        public void Stop(int Id)
        {
            Athletes.Where(i => i.Id == Id).FirstOrDefault(i => i.IsStopped = true);

        }

        public void UpdateCounter(double actualdistance)
        {
            ShuttleTimeElapsed += 1;
            ShuttleTimeLeft -= 1;
            TotalTime += 1;
            TotalDistance += (int)actualdistance;

        }

        public void UpdateAthleteInfo()
        {
            foreach (var athlete in Athletes.Where(i => i.IsStopped == false))
            {
                athlete.Level = Level;
                athlete.Shuttle = Shuttle;
            }
        }

        public async void OnEditButtonClick(int id, int level, int shuttle)
        {
            foreach (var athlete in Athletes.Where(i => i.Id == id))
            {
                athlete.Level = level;
                athlete.Shuttle = shuttle;
            }
        }

       
    }

}
