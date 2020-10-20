using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoYoTestApp.Shared.Models;

namespace YoYoTestApp.Server.Services
{
    public interface IYoYoService
    {
        List<Athlete> LoadAthletes();
        List<TestModel> LoadTests();
        void Warn(int Id);
        void Stop(int Id);
        void UpdateCounter(double actualdistance);
        void UpdateAthleteInfo();
        void OnEditButtonClick(int id, int level, int shuttle);
    }
}
