using System;
using System.Collections.Generic;

namespace MasterLinq
{
    public class PlayersComparer : IEqualityComparer<ChessPlayer>
    {
        public bool Equals(ChessPlayer x, ChessPlayer y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return string.Equals(x.FirstName, y.FirstName, StringComparison.InvariantCultureIgnoreCase)
                   && string.Equals(x.LastName, y.LastName, StringComparison.InvariantCultureIgnoreCase)
                   && x.BirthYear == y.BirthYear
                   && x.Rating == y.Rating
                   && string.Equals(x.Country, y.Country, StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(ChessPlayer obj)
        {
            unchecked
            {
                var hashCode = (obj.FirstName != null
                    ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.FirstName)
                    : 0);
                hashCode = (hashCode * 397) ^ (obj.LastName != null
                               ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.LastName)
                               : 0);
                hashCode = (hashCode * 397) ^ obj.BirthYear;
                hashCode = (hashCode * 397) ^ obj.Rating;
                hashCode = (hashCode * 397) ^ (obj.Country != null
                               ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(obj.Country)
                               : 0);
                return hashCode;
            }
        }
    }
    public class ChessPlayer : IHaveId
    {
        private sealed class FirstNameRatingEqualityComparer : IEqualityComparer<ChessPlayer>
        {
            public bool Equals(ChessPlayer x, ChessPlayer y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.FirstName, y.FirstName) && x.Rating == y.Rating;
            }

            public int GetHashCode(ChessPlayer obj)
            {
                unchecked
                {
                    return ((obj.FirstName != null ? obj.FirstName.GetHashCode() : 0) * 397) ^ obj.Rating;
                }
            }
        }

        public static IEqualityComparer<ChessPlayer> FirstNameRatingComparer { get; } = 
            new FirstNameRatingEqualityComparer();

        private string _country;
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int BirthYear { get; set; }

        public int Rating { get; set; }

        public string Country
        {
            get
            {
                return _country;
            }
            set => _country = value;
        }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"Full Name: {FirstName + " " + LastName}, Rating = {Rating}, from {Country}, Born in {BirthYear}";
        }

        public static ChessPlayer ParseFideCsv(string line)
        {
            string[] parts = line.Split(';');
            return new ChessPlayer()
            {
                Id = int.Parse(parts[0]),
                LastName = parts[1].Split(',')[0].Trim(),
                FirstName = parts[1].Split(',')[1].Trim(),
                Country = parts[3],
                Rating = int.Parse(parts[4]),
                BirthYear = int.Parse(parts[6])
            };
        }

        public static IEnumerable<ChessPlayer> GetDemoList()
        {
            return new List<ChessPlayer>()
            {
                new ChessPlayer()
                {
                    Id = 1,
                    BirthYear = 1990,
                    FirstName = "Magnus",
                    LastName = "Carlsen",
                    Rating = 2842,
                    Country = "NOR"
                },
                new ChessPlayer()
                {
                    Id = 2,
                    BirthYear = 1992,
                    FirstName = "Fabiano",
                    LastName = "Caruana",
                    Rating = 2822,
                    Country = "USA"
                },
                new ChessPlayer()
                {
                    Id = 3,
                    BirthYear = 1985,
                    FirstName = "Shakhriyar",
                    LastName = "Mamedyarov",
                    Rating = 2801,
                    Country = "AZE"
                },
                new ChessPlayer()
                {
                    Id = 4,
                    BirthYear = 1992,
                    FirstName = "Liren",
                    LastName = "Ding",
                    Rating = 2797,
                    Country = "CHN"
                },
                new ChessPlayer()
                {
                    Id = 5,
                    BirthYear = 1994,
                    FirstName = "Anish",
                    LastName = "Giri",
                    Rating = 2780,
                    Country = "NED"
                },
                new ChessPlayer()
                {
                    Id = 6,
                    BirthYear = 1993,
                    FirstName = "Wesley",
                    LastName = "So",
                    Rating = 2780,
                    Country = "USA"
                },
                new ChessPlayer()
                {
                    Id = 7,
                    BirthYear = 1975,
                    FirstName = "Vladimir",
                    LastName = "Kramnik",
                    Rating = 2779,
                    Country = "RUS"
                },
                new ChessPlayer()
                {
                    Id = 8,
                    BirthYear = 1990,
                    FirstName = "Maxime",
                    LastName = "Vachier-Lagrave",
                    Rating = 2779,
                    Country = "FRA"
                },
                new ChessPlayer()
                {
                    Id = 9,
                    BirthYear = 1987,
                    FirstName = "Hikaru",
                    LastName = "Nakamura",
                    Rating = 2777,
                    Country = "USA"
                },
                new ChessPlayer()
                {
                    Id = 10,
                    BirthYear = 1990,
                    FirstName = "Sergey",
                    LastName = "Karjakin",
                    Rating = 2773,
                    Country = "RUS"
                },
            };
        }        
    }
}