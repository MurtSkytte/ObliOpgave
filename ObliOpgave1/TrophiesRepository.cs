using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObliOpgave1
{
    public class TrophiesRepository
    {
        private int _nextId = 6;

        private List<Trophy> _trophies = new()
        {
            new Trophy(1, "Hotdog", 1992),
            new Trophy(2, "Pingpong", 2000),
            new Trophy(3, "Badminton", 2020),
            new Trophy(4, "Ironman", 2005),
            new Trophy(5, "Marathon", 1990)
        };



        public TrophiesRepository()
        {
        }

        public IEnumerable<Trophy> Get(int? yearAfter= null, string? competitionIncludes = null, string? orderBy = null)
        {
            IEnumerable<Trophy> result = new List<Trophy>(_trophies);
            if (yearAfter != null)
            {
                result = result.Where(t => t.Year > yearAfter);
            }
            if (competitionIncludes != null)
            {
                result = result.Where(t => t.Competition.Contains(competitionIncludes));
            }

            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "competition":
                    case "competition_asc":
                        result = result.OrderBy(t => t.Competition); 
                        break;
                    case "competition_desc":
                        result = result.OrderByDescending(t => t.Competition);
                        break;
                    case "year":
                    case "year_asc":
                        result = result.OrderBy(t => t.Year);
                        break;
                    case "year_desc":
                        result = result.OrderByDescending(t => t.Year);
                        break;
                    default:
                        break;

                }
            }
            return result;
        }
        public Trophy? GetById(int id)
        {
            return _trophies.Find(trophy => trophy.Id == id);
        }
        public Trophy Add(Trophy trophy)
        {
            trophy.Validate();
            trophy.Id = _nextId++;
            _trophies.Add(trophy);
            return trophy;
        }
        public Trophy Remove(int id)
        {
            Trophy? trophy = GetById(id);
            if (trophy == null)
            {
                return null;
            }
            _trophies.Remove(trophy);
            return trophy;
        }
        public Trophy? Update(int id, Trophy trophy)
        {
            trophy.Validate();
            Trophy? existingTrophy = GetById(id);
            if (existingTrophy == null)
            {
                return null;
            }
            existingTrophy.Competition = trophy.Competition;
            existingTrophy.Year = trophy.Year;
            return existingTrophy;
        }
    }
}
