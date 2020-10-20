using System;
using System.Collections.Generic;
using System.Text;

namespace YoYoTestApp.Shared.Models
{
    public class TestModel
    {
        private int _accumulatedShuttleDistance;
        private int _speedlevel;
        private int _shuttleNo;
        private double _speed;
        private double _levelTime;
        private TimeSpan _commulativeTime;
        private TimeSpan _startTime;
        private double _approxVo2Max;

        public int AccumulatedShuttleDistance
        {
            get { return _accumulatedShuttleDistance; }
            set { _accumulatedShuttleDistance = value; }
        }
        public int Speedlevel
        {
            get { return _speedlevel; }
            set { _speedlevel = value; }
        }
        public int ShuttleNo
        {
            get { return _shuttleNo; }
            set { _shuttleNo = value; }
        }

        public double Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public double LevelTime
        {
            get { return _levelTime; }
            set { _levelTime = value; }
        }

        public TimeSpan CommulativeTime
        {
            get { return _commulativeTime; }
            set { _commulativeTime = value; }
        }

        public TimeSpan StartTime
        {
            get { return _startTime; }
            set { _startTime = value; }
        }
        public double ApproxVo2Max
        {
            get { return _approxVo2Max; }
            set { _approxVo2Max = value; }
        }

    }
}
