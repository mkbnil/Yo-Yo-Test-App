using System;
using System.Collections.Generic;
using System.Text;

namespace YoYoTestApp.Shared.Models
{
    public class Athlete
    {
        private int _id;
        private string _name;
        private int _level;
        private int _shuttle;
        private bool _isWarned = false;
        private bool _isStopped = false;
        private string _warnText = "Warn";

        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int Level { get { return _level; } set { _level = value; } }
        public int Shuttle { get { return _shuttle; } set { _shuttle = value; } }
        public bool IsWarned { get { return _isWarned; } set { _isWarned = value; } }
        public bool IsStopped { get { return _isStopped; } set { _isStopped = value; } }
        public string WarnText { get { return _warnText; } set { _warnText = value; } }
    }

}
