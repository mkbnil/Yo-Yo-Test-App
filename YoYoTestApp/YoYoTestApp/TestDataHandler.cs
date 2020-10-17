using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using YoYoTestApp.Models;

namespace YoYoTestApp
{
    public class TestDataHandler
    {
        private IList<Athlete> _athletes;
        private IList<TestData> _tests;
        private float _shuttleTimeLeft = 0;
        private float _shuttleTimeElapsed = 0;
        private int _totalTime = 0;
        private int _totalDistance = 0;
        private int _level;
        private int _shuttle;
        private float _speed;


        public IList<Athlete> Athletes { get { return _athletes; } }
        public IList<TestData> Tests { get { return _tests; } }
        public float ShuttleTimeLeft { get { return _shuttleTimeLeft; } }
        public float ShuttleTimeElapsed { get { return _shuttleTimeElapsed; } }
        public int TotalTime { get { return _totalTime; } }
        public int TotalDistance { get { return _totalDistance; } }
        public int Level { get { return _level; } }
        public int Shuttle { get { return _shuttle; } }
        public float Speed { get { return _speed; } }

        public TestDataHandler()
        {
            LoadTests();
            LoadAthletes();
        }

        public async void OnTestStart()
        {

            foreach (TestData testdata in _tests)
            {
                Run(testdata);
            }
        }

        public async void OnWarningButtonClick(int id)
        {
            _athletes.Where(i => i.Id == id && i.IsWarned == true).ToList().ForEach(i => i.IsStopped = true);
            _athletes.Where(i => i.Id == id && i.IsWarned == false).ToList().ForEach(i => i.IsWarned = true);
        }
        public async void OnStopButtonClick(int id)
        {
            _athletes.Where(i => i.Id == id && i.IsStopped == false).ToList().ForEach(i => i.IsStopped = true);  
        }

        public async void  OnEditButtonClick(int id, int level, int shuttle)
        {
            foreach (var athlete in _athletes.Where(i => i.Id == id))
            {
                athlete.Level = level;
                athlete.Shuttle = shuttle;
            }
        }
        private async void Run(TestData testdata)
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
                    if (_shuttleTimeLeft == 0) break;
                    await Task.Delay(1000);
                }
                UpdateAthleteInfo();
            }

        }

        private void UpdateAthleteInfo()
        {
            foreach(var athlete in _athletes.Where(i => i.IsStopped == false))
            {
                athlete.Level = _level;
                athlete.Shuttle = _shuttle;
            }
        }

        private void LoadAthletes()
        {
            _athletes.Add(new Athlete() { Id = 1, Name = "Virat Kohli" });
            _athletes.Add(new Athlete() { Id = 2, Name = "AB Devillers" });
            _athletes.Add(new Athlete() { Id = 3, Name = "Aaron Finch" });
        }

        private void LoadTests()
        {
            _tests = JsonConvert.DeserializeObject<List<TestData>>(File.ReadAllText("./fitnessrating_beeptest.json"));
        }

        private void UpdateCounter()
        {
            _shuttleTimeElapsed += 1;
            _shuttleTimeLeft -= 1;
            _totalTime += 1;
        }
    }
}
