using MetarAPI.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetarAPI.Services
{
    /// <summary>
    /// Use this Class in an application that requires Dependency Injection. This can be used for a DI role. Do not use
    /// MetarActions if using this class.
    /// </summary>
    public class MetarData
    {
        private readonly DiMetarContext _context;
        public MetarData(DiMetarContext context)
        {
            this._context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public IEnumerable<Metar> FilterByStation(string stationName)
        {
            return _context.Metars.Where(report => report.StationId == stationName).ToList();
        }

        public IEnumerable<Metar> FilterByTime(DateTime start, DateTime end)
        {
            DateTime startUtc = start.ToUniversalTime();
            DateTime endUtc = end.ToUniversalTime();
            return _context.Metars.Where(report => report.ObservationTime >= startUtc && report.ObservationTime <= endUtc).ToList();
        }

        public IEnumerable<Metar> GetAllMetars()
        {
            return _context.Metars;
        }

        public IEnumerable<Metar> GetYesterdayReports()
        {
            DateTime start = DateTime.UtcNow.AddDays(-1);
            return _context.Metars.Where(report => report.ObservationTime.Date == start.Date).OrderBy(report => report.ObservationTime).ToList();
        }
    }
}
