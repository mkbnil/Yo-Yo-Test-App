using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YoYoTestWeb.ViewModels;

namespace YoYoTestWeb.Services
{
    public class YoYoService
    {
        private IList<Athlete> _athletes = new List<Athlete>();
        private IList<TestModel> _tests = new List<TestModel>();
        private double _shuttleTimeLeft = 0;
        private double _shuttleTimeElapsed = 0;
        private int _totalTime = 0;
        private int _totalDistance = 0;
        private int _level;
        private int _shuttle;
        private double _speed;
        private bool _isProcessStarted = false;


        public IList<Athlete> Athletes { get { return _athletes; } }
        public IList<TestModel> Tests { get { return _tests; } }
        public double ShuttleTimeLeft { get { return _shuttleTimeLeft; } }
        public double ShuttleTimeElapsed { get { return _shuttleTimeElapsed; } }
        public int TotalTime { get { return _totalTime; } }
        public int TotalDistance { get { return _totalDistance; } }
        public int Level { get { return _level; } }
        public int Shuttle { get { return _shuttle; } }
        public double Speed { get { return _speed; } }
        public bool IsProcessStarted { get { return _isProcessStarted; } set { _isProcessStarted = value; } }



        public YoYoService()
        {
            LoadTests();
            LoadAthletes();
        }
        public async Task OnTestStart()
        {
            _isProcessStarted = true;
            foreach (TestModel testdata in _tests)
            {
               await Run(testdata);
            }
        }
        private async Task Run(TestModel testdata)
        {
            var shuttleno = 0;
            while (shuttleno < testdata.ShuttleNo)
            {
                _level = testdata.Speedlevel;
                _shuttle = shuttleno;
                _speed = testdata.Speed;
                _shuttleTimeElapsed = 0;
                _shuttleTimeLeft = testdata.LevelTime;
                _totalDistance += testdata.AccumulatedShuttleDistance;
                while (true)
                {
                    UpdateCounter();
                    if (_shuttleTimeLeft < 1.0f) break;
                    await Task.Delay(1000);
                }
                UpdateAthleteInfo();
            }

        }



        public void Warn(Athlete athlete)
        {
            var id = athlete.Id;
            if (!athlete.IsWarned)
            {
                athlete.IsWarned = true;
                athlete.WarnText = "Warned";
            }
            else
            {
                athlete.IsStopped = true;
            }

            _athletes.Where(i => i.Id == id && i.IsWarned == true).ToList().ForEach(i => i.IsStopped = true);
            _athletes.Where(i => i.Id == id && i.IsWarned == false).ToList().ForEach(i => i.IsWarned = true);
        }

        public void Stop(Athlete athlete)
        {
            athlete.IsStopped = true;
            _athletes.Where(i => i.Id == athlete.Id && i.IsStopped == false).ToList().ForEach(i => i.IsStopped = true);
        }

        public async void OnEditButtonClick(int id, int level, int shuttle)
        {
            foreach (var athlete in _athletes.Where(i => i.Id == id))
            {
                athlete.Level = level;
                athlete.Shuttle = shuttle;
            }
        }

        private void UpdateAthleteInfo()
        {
            foreach (var athlete in _athletes.Where(i => i.IsStopped == false))
            {
                athlete.Level = _level;
                athlete.Shuttle = _shuttle;
            }
        }
        private void UpdateCounter()
        {
            _shuttleTimeElapsed += 1;
            _shuttleTimeLeft -= 1.0f;
            _totalTime += 1;
        }

        private void LoadAthletes()
        {
            _athletes.Add(new Athlete() { Id = 1, Name = "Virat Kohli" });
            _athletes.Add(new Athlete() { Id = 2, Name = "AB Devillers" });
            _athletes.Add(new Athlete() { Id = 3, Name = "Aaron Finch" });
        }

        private void LoadTests()
        {
           // _tests = JsonConvert.DeserializeObject<List<TestModel>>(File.ReadAllText(Directory.GetCurrentDirectory() + "\\fitnessrating_beeptest.json"));
            var test = new TestModel()
            {
                AccumulatedShuttleDistance = 40,
                Speedlevel = 1,
                ShuttleNo = 5,
                Speed = 10,
                LevelTime = 14.4f,
                CommulativeTime = new DateTime(),
                StartTime = new DateTime(),
                ApproxVo2Max = 36.74f

            };
            _tests.Add(test);

        }

    }
}    

