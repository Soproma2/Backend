using System.Numerics;

namespace HomeWork21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Player> gamers = new List<Player>
            {
                new Player { Username = "DragonSlayer_GE", Country = "Georgia", Level = 45, Score = 12500,
                             LastLogin = DateTime.Now.AddDays(-1), Achievements = new List<string>{"FirstBlood", "LevelMaster"}, IsPremium = true },
                new Player { Username = "NightWolf_RU", Country = "Russia", Level = 32, Score = 8900,
                             LastLogin = DateTime.Now.AddDays(-5), Achievements = new List<string>{"Survivor"}, IsPremium = false },
                new Player { Username = "Phoenix_TR", Country = "Turkey", Level = 28, Score = 7200,
                             LastLogin = DateTime.Now.AddDays(-2), Achievements = new List<string>{"FirstBlood", "TeamPlayer", "Survivor"}, IsPremium = true },
                new Player { Username = "ShadowHunter_GE", Country = "Georgia", Level = 51, Score = 15600,
                             LastLogin = DateTime.Now.AddHours(-3), Achievements = new List<string>{"LevelMaster", "ScoreKing"}, IsPremium = false },
                new Player { Username = "IceQueen_UA", Country = "Ukraine", Level = 39, Score = 11200,
                             LastLogin = DateTime.Now.AddDays(-10), Achievements = new List<string>{"FirstBlood", "TeamPlayer"}, IsPremium = true }
            };

            // TODO: Top 3 მოთამაშე ქულების მიხედვით

            var top3 = gamers.OrderByDescending(x => x.Score).Take(3);
            foreach (var g in top3)
            {
                Console.WriteLine($"{g.Username} - {g.Score}");
            }

            Console.WriteLine();
            // TODO: რომელ ქვეყანას ყველაზე მეტი პრემიუმ მოთამაშე ჰყავს?
            var premiumC = gamers.Where(p => p.IsPremium == true).GroupBy(c => c.Country).OrderByDescending(p => p.Count()).FirstOrDefault();
            Console.WriteLine(premiumC.Key);

            // TODO: მოძებნე მოთამაშეები რომლებსაც "FirstBlood" achievement აქვთ
            var fB = gamers.Where(a => a.Achievements.Contains("FirstBlood"));
            foreach (var f in fB)
            {
                Console.Write($"{f.Username} - ");

                foreach (var g in f.Achievements)
                {
                    Console.Write(g+"; ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            // TODO: დათვალე საშუალო დონე თითოეული ქვეყნისთვის
            var avgC = gamers.GroupBy(c => c.Country).Select(x => new
            {
                country = x.Key,
                avgLevel = x.Average(l=>l.Level)
            });


            foreach (var g in avgC)
            {
                Console.WriteLine($"{g.country} - {g.avgLevel}");
            }
            Console.WriteLine();
            // TODO: ვინ არის "მიტოვებული" მოთამაშე (7+ დღეა არ შესულა)?
            var abandonedPlayers = gamers.Where(l=>(DateTime.Now - l.LastLogin).TotalDays > 7);

            foreach (var g in abandonedPlayers)
            {
                Console.WriteLine(g.Username);
            }
            Console.WriteLine();
            // TODO: შექმენი leaderboard - ქვეყნის სახელი + ყველაზე მაღალი ქულა იმ ქვეყნიდან
            var topList = gamers.GroupBy(c => c.Country).Select(x => new
            {
                country = x.Key,
                score = x.Max(s =>s.Score)
            }).OrderByDescending(s=>s.score).ToList();

            foreach (var g in topList)
            {
                Console.WriteLine($"{g.country} - {g.score}");
            }
        }
    }

    public class Player
    {
        public string Username { get; set; }
        public string Country { get; set; }
        public int Level { get; set; }
        public int Score { get; set; }
        public DateTime LastLogin { get; set; }
        public List<string> Achievements { get; set; }
        public bool IsPremium { get; set; }
    }
}
