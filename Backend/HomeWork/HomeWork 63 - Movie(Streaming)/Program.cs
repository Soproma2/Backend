using HomeWork_63___Movie_Streaming_.Data;
using HomeWork_63___Movie_Streaming_.Enums;
using HomeWork_63___Movie_Streaming_.Services;

class Program
{
    static MovieService _movieService;
    static UserService _userService;
    static ActorService _actorService;
    static DirectorService _directorService;
    static GenreService _genreService;
    static SubscriptionService _subscriptionService;

    static async Task Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        using var context = new StreamingDbContext();
        await context.Database.EnsureCreatedAsync();

        _movieService = new MovieService(context);
        _userService = new UserService(context);
        _actorService = new ActorService(context);
        _directorService = new DirectorService(context);
        _genreService = new GenreService(context);
        _subscriptionService = new SubscriptionService(context);

        await MainMenuAsync();
    }

    // ══════════════════════════════════════════════════════════════════
    //                        მთავარი მენიუ
    // ══════════════════════════════════════════════════════════════════
    static async Task MainMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║        კინო / Streaming სისტემა         ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. ფილმების მართვა                     ║");
            Console.WriteLine("║  2. მომხმარებლების მართვა               ║");
            Console.WriteLine("║  3. მსახიობების მართვა                  ║");
            Console.WriteLine("║  4. რეჟისორების მართვა                  ║");
            Console.WriteLine("║  5. ჟანრების მართვა                     ║");
            Console.WriteLine("║  6. გამოწერების მართვა                  ║");
            Console.WriteLine("║  0. გასვლა                              ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("აირჩიე: ");

            switch (Console.ReadLine())
            {
                case "1": await MovieMenuAsync(); break;
                case "2": await UserMenuAsync(); break;
                case "3": await ActorMenuAsync(); break;
                case "4": await DirectorMenuAsync(); break;
                case "5": await GenreMenuAsync(); break;
                case "6": await SubscriptionMenuAsync(); break;
                case "0": Console.WriteLine("ნახვამდის!"); return;
                default: Error("არასწორი არჩევანი!"); break;
            }
        }
    }

    // ══════════════════════════════════════════════════════════════════
    //                       ფილმების მენიუ
    // ══════════════════════════════════════════════════════════════════
    static async Task MovieMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║             ფილმების მართვა             ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. ფილმის დამატება                     ║");
            Console.WriteLine("║  2. ყველა ფილმის ნახვა                  ║");
            Console.WriteLine("║  3. მსახიობის მიბმა ფილმზე              ║");
            Console.WriteLine("║  4. ჟანრის მიბმა ფილმზე                 ║");
            Console.WriteLine("║  5. რეჟისორის მიბმა ფილმზე              ║");
            Console.WriteLine("║  0. უკან                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("აირჩიე: ");

            switch (Console.ReadLine())
            {
                case "1": await AddMovieAsync(); break;
                case "2": await ListMoviesAsync(); break;
                case "3": await AddActorToMovieAsync(); break;
                case "4": await AddGenreToMovieAsync(); break;
                case "5": await AddDirectorToMovieAsync(); break;
                case "0": return;
                default: Error("არასწორი არჩევანი!"); break;
            }
        }
    }

    static async Task AddMovieAsync()
    {
        Console.Clear();
        Header("ფილმის დამატება");

        var title = Read("სახელი");
        var year = ReadInt("გამოშვების წელი");
        var duration = ReadInt("ხანგრძლივობა (წუთები)");
        var language = Read("ენა");
        var rating = ReadDecimal("რეიტინგი (0.0 - 10.0)");

        var movie = await _movieService.CreateMovieAsync(title, year, duration, language, rating);
        Success($"ფილმი დაემატა! ID: {movie.Id}");
        Pause();
    }

    static async Task ListMoviesAsync()
    {
        Console.Clear();
        Header("ყველა ფილმი");

        var movies = await _movieService.GetAllMoviesAsync();
        if (movies.Count == 0) { Info("ფილმი არ მოიძებნა."); Pause(); return; }

        foreach (var m in movies)
        {
            Console.WriteLine($"\n  🎬 [{m.Id}] {m.Title} ({m.ReleaseYear}) | {m.DurationMinutes} წთ | {m.Rating}/10");
            Console.WriteLine($"      ენა:        {m.Language}");
            Console.WriteLine($"      ჟანრები:    {(m.MovieGenres.Any() ? string.Join(", ", m.MovieGenres.Select(mg => mg.Genre.Name)) : "—")}");
            Console.WriteLine($"      მსახიობები: {(m.MovieCasts.Any() ? string.Join(", ", m.MovieCasts.Select(mc => $"{mc.Actor.FullName} [{mc.CastType}]")) : "—")}");
            Console.WriteLine($"      რეჟისორი:   {(m.MovieDirectors.Any() ? string.Join(", ", m.MovieDirectors.Select(md => md.Director.FullName)) : "—")}");
        }
        Pause();
    }

    static async Task AddActorToMovieAsync()
    {
        Console.Clear();
        Header("მსახიობის მიბმა ფილმზე");

        var movieId = ReadInt("ფილმის ID");
        var actorId = ReadInt("მსახიობის ID");
        var character = Read("პერსონაჟის სახელი");
        Console.WriteLine("  როლის ტიპი:");
        foreach (var v in Enum.GetValues<CastType>())
            Console.WriteLine($"    {(int)v}. {v}");
        var castType = (CastType)ReadInt("აირჩიე");

        try
        {
            await _movieService.AddActorToMovieAsync(movieId, actorId, character, castType);
            Success("მსახიობი მიება ფილმს!");
        }
        catch (Exception ex) { Error(ex.InnerException?.Message ?? ex.Message); }
        Pause();
    }

    static async Task AddGenreToMovieAsync()
    {
        Console.Clear();
        Header("ჟანრის მიბმა ფილმზე");

        var movieId = ReadInt("ფილმის ID");
        var genreId = ReadInt("ჟანრის ID");
        Console.Write("  მთავარი ჟანრია? (y/n): ");
        var isPrimary = Console.ReadLine()?.ToLower() == "y";

        try
        {
            await _movieService.AddGenreToMovieAsync(movieId, genreId, isPrimary);
            Success("ჟანრი მიება ფილმს!");
        }
        catch (Exception ex) { Error(ex.InnerException?.Message ?? ex.Message); }
        Pause();
    }

    static async Task AddDirectorToMovieAsync()
    {
        Console.Clear();
        Header("რეჟისორის მიბმა ფილმზე");

        var movieId = ReadInt("ფილმის ID");
        var directorId = ReadInt("რეჟისორის ID");
        Console.WriteLine("  რეჟისორის როლი:");
        foreach (var v in Enum.GetValues<DirectorRole>())
            Console.WriteLine($"    {(int)v}. {v}");
        var directorRole = (DirectorRole)ReadInt("აირჩიე");

        try
        {
            await _movieService.AddDirectorToMovieAsync(movieId, directorId, directorRole);
            Success("რეჟისორი მიება ფილმს!");
        }
        catch (Exception ex) { Error(ex.InnerException?.Message ?? ex.Message); }
        Pause();
    }


    static async Task UserMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║          მომხმარებლების მართვა          ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. მომხმარებლის დამატება               ║");
            Console.WriteLine("║  2. მომხმარებლის დეტალები (ID-ით)       ║");
            Console.WriteLine("║  3. ფილმის Watchlist-ში დამატება        ║");
            Console.WriteLine("║  4. ფილმის ნანახად მონიშვნა             ║");
            Console.WriteLine("║  5. გამოწერის მინიჭება                  ║");
            Console.WriteLine("║  0. უკან                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("აირჩიე: ");

            switch (Console.ReadLine())
            {
                case "1": await AddUserAsync(); break;
                case "2": await UserDetailsAsync(); break;
                case "3": await AddToWatchlistAsync(); break;
                case "4": await MarkAsWatchedAsync(); break;
                case "5": await AddSubscriptionAsync(); break;
                case "0": return;
                default: Error("არასწორი არჩევანი!"); break;
            }
        }
    }

    static async Task AddUserAsync()
    {
        Console.Clear();
        Header("მომხმარებლის დამატება");

        var username = Read("მომხმარებლის სახელი");
        var email = Read("ელ-ფოსტა");

        var user = await _userService.CreateUserAsync(username, email);
        Success($"მომხმარებელი დაემატა! ID: {user.Id}");
        Pause();
    }

    static async Task UserDetailsAsync()
    {
        Console.Clear();
        Header("მომხმარებლის დეტალები");

        var id = ReadInt("მომხმარებლის ID");
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) { Error("მომხმარებელი ვერ მოიძებნა."); Pause(); return; }

        Console.WriteLine($"\n  👤 {user.Username}  |  {user.Email}");
        Console.WriteLine($"  რეგისტრაცია: {user.RegisteredAt:dd/MM/yyyy}");

        Console.WriteLine("\n  🎬 Watchlist:");
        if (!user.Watchlists.Any()) Console.WriteLine("     —");
        foreach (var w in user.Watchlists)
            Console.WriteLine($"     ▸ {w.Movie?.Title} | ნანახი: {w.IsWatched} | შეფასება: {(w.UserRating.HasValue ? w.UserRating + "/10" : "—")}");

        Console.WriteLine("\n  💳 გამოწერები:");
        if (!user.UserSubscriptions.Any()) Console.WriteLine("     —");
        foreach (var us in user.UserSubscriptions)
            Console.WriteLine($"     ▸ {us.Subscription?.Name} | {us.Subscription?.MonthlyPrice}₾/თვე | აქტიური: {us.IsActive}");

        Pause();
    }

    static async Task AddToWatchlistAsync()
    {
        Console.Clear();
        Header("Watchlist-ში დამატება");

        var userId = ReadInt("მომხმარებლის ID");
        var movieId = ReadInt("ფილმის ID");

        try
        {
            await _userService.AddToWatchlistAsync(userId, movieId);
            Success("ფილმი Watchlist-ში დაემატა!");
        }
        catch (Exception ex) { Error(ex.InnerException?.Message ?? ex.Message); }
        Pause();
    }

    static async Task MarkAsWatchedAsync()
    {
        Console.Clear();
        Header("ფილმის ნანახად მონიშვნა");

        var userId = ReadInt("მომხმარებლის ID");
        var movieId = ReadInt("ფილმის ID");
        var rating = ReadInt("შეფასება (1-10)");

        try
        {
            await _userService.MarkAsWatchedAsync(userId, movieId, rating);
            Success("ფილმი ნანახად მოინიშნა!");
        }
        catch (Exception ex) { Error(ex.InnerException?.Message ?? ex.Message); }
        Pause();
    }

    static async Task AddSubscriptionAsync()
    {
        Console.Clear();
        Header("გამოწერის მინიჭება");

        var userId = ReadInt("მომხმარებლის ID");
        var subscriptionId = ReadInt("გამოწერის ID");
        var startDate = ReadDate("დაწყების თარიღი (dd.MM.yyyy)");
        var endDate = ReadDate("დასრულების თარიღი (dd.MM.yyyy)");

        try
        {
            await _userService.AddSubscriptionAsync(userId, subscriptionId, startDate, endDate);
            Success("გამოწერა მინიჭებულია!");
        }
        catch (Exception ex) { Error(ex.InnerException?.Message ?? ex.Message); }
        Pause();
    }

    static async Task ActorMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║            მსახიობების მართვა           ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. მსახიობის დამატება                  ║");
            Console.WriteLine("║  2. ყველა მსახიობის ნახვა               ║");
            Console.WriteLine("║  0. უკან                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("აირჩიე: ");

            switch (Console.ReadLine())
            {
                case "1": await AddActorAsync(); break;
                case "2": await ListActorsAsync(); break;
                case "0": return;
                default: Error("არასწორი არჩევანი!"); break;
            }
        }
    }

    static async Task AddActorAsync()
    {
        Console.Clear();
        Header("მსახიობის დამატება");

        var name = Read("სრული სახელი");
        var dob = ReadDate("დაბადების თარიღი (dd.MM.yyyy)");
        var nationality = Read("ეროვნება");

        var actor = await _actorService.CreateActorAsync(name, dob, nationality);
        Success($"მსახიობი დაემატა! ID: {actor.Id}");
        Pause();
    }

    static async Task ListActorsAsync()
    {
        Console.Clear();
        Header("ყველა მსახიობი");

        var actors = await _actorService.GetAllActorsAsync();
        if (actors.Count == 0) { Info("მსახიობი არ მოიძებნა."); Pause(); return; }

        Console.WriteLine($"\n  {"ID",-5} {"სახელი",-25} {"ეროვნება",-15} {"ფილმები",-10}");
        Console.WriteLine(new string('─', 58));
        foreach (var a in actors)
        {
            Console.WriteLine($"  {a.Id,-5} {a.FullName,-25} {a.Nationality,-15} {a.MovieCasts.Count,-10}");
            foreach (var mc in a.MovieCasts)
                Console.WriteLine($"        🎬 {mc.Movie?.Title}  [{mc.CharacterName}]");
        }
        Pause();
    }

    static async Task DirectorMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║           რეჟისორების მართვა            ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. რეჟისორის დამატება                  ║");
            Console.WriteLine("║  0. უკან                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("აირჩიე: ");

            switch (Console.ReadLine())
            {
                case "1": await AddDirectorAsync(); break;
                case "0": return;
                default: Error("არასწორი არჩევანი!"); break;
            }
        }
    }

    static async Task AddDirectorAsync()
    {
        Console.Clear();
        Header("რეჟისორის დამატება");

        var name = Read("სრული სახელი");
        var nationality = Read("ეროვნება");
        var dob = ReadDate("დაბადების თარიღი (dd.MM.yyyy)");

        var director = await _directorService.CreateDirectorAsync(name, nationality, dob);
        Success($"რეჟისორი დაემატა! ID: {director.Id}");
        Pause();
    }

    static async Task GenreMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║              ჟანრების მართვა            ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. ჟანრის დამატება                     ║");
            Console.WriteLine("║  0. უკან                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("აირჩიე: ");

            switch (Console.ReadLine())
            {
                case "1": await AddGenreAsync(); break;
                case "0": return;
                default: Error("არასწორი არჩევანი!"); break;
            }
        }
    }

    static async Task AddGenreAsync()
    {
        Console.Clear();
        Header("ჟანრის დამატება");

        Console.WriteLine("  ჟანრი:");
        foreach (var v in Enum.GetValues<GenreE>())
            Console.WriteLine($"    {(int)v}. {v}");
        var name = (GenreE)ReadInt("აირჩიე");
        var description = Read("აღწერა");

        var genre = await _genreService.CreateGenreAsync(name, description);
        Success($"ჟანრი დაემატა! ID: {genre.Id}");
        Pause();
    }

    static async Task SubscriptionMenuAsync()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║           გამოწერების მართვა            ║");
            Console.WriteLine("╠══════════════════════════════════════════╣");
            Console.WriteLine("║  1. გამოწერის დამატება                  ║");
            Console.WriteLine("║  2. ყველა გამოწერის ნახვა               ║");
            Console.WriteLine("║  0. უკან                                 ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.Write("აირჩიე: ");

            switch (Console.ReadLine())
            {
                case "1": await AddSubscriptionPlanAsync(); break;
                case "2": await ListSubscriptionsAsync(); break;
                case "0": return;
                default: Error("არასწორი არჩევანი!"); break;
            }
        }
    }

    static async Task AddSubscriptionPlanAsync()
    {
        Console.Clear();
        Header("გამოწერის დამატება");

        Console.WriteLine("  გამოწერის ტიპი:");
        foreach (var v in Enum.GetValues<SubscriptionPlan>())
            Console.WriteLine($"    {(int)v}. {v}");
        var name = (SubscriptionPlan)ReadInt("აირჩიე");
        var price = ReadDecimal("თვიური ფასი");
        var screens = ReadInt("მაქს. ეკრანები");
        Console.Write("  4K-ის მხარდაჭერა? (y/n): ");
        var has4K = Console.ReadLine()?.ToLower() == "y";

        var sub = await _subscriptionService.CreateSubscriptionAsync(name, price, screens, has4K);
        Success($"გამოწერა დაემატა! ID: {sub.Id}");
        Pause();
    }

    static async Task ListSubscriptionsAsync()
    {
        Console.Clear();
        Header("ყველა გამოწერა");

        var subs = await _subscriptionService.GetAllSubscriptionsAsync();
        if (subs.Count == 0) { Info("გამოწერა არ მოიძებნა."); Pause(); return; }

        Console.WriteLine($"\n  {"ID",-5} {"სახელი",-12} {"ფასი",-10} {"ეკრანები",-10} {"4K",-5}");
        Console.WriteLine(new string('─', 45));
        foreach (var s in subs)
            Console.WriteLine($"  {s.Id,-5} {s.Name,-12} {s.MonthlyPrice + "₾",-10} {s.MaxScreens,-10} {s.Has4K,-5}");

        Pause();
    }


    static string Read(string label)
    {
        Console.Write($"  {label}: ");
        return Console.ReadLine() ?? "";
    }

    static int ReadInt(string label)
    {
        while (true)
        {
            Console.Write($"  {label}: ");
            if (int.TryParse(Console.ReadLine(), out int val)) return val;
            Error("მხოლოდ რიცხვი შეიყვანე!");
        }
    }

    static decimal ReadDecimal(string label)
    {
        while (true)
        {
            Console.Write($"  {label}: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal val)) return val;
            Error("მხოლოდ რიცხვი შეიყვანე!");
        }
    }

    static DateTime ReadDate(string label)
    {
        while (true)
        {
            Console.Write($"  {label}: ");
            if (DateTime.TryParseExact(Console.ReadLine(), "dd.MM.yyyy",
                null, System.Globalization.DateTimeStyles.None, out DateTime val)) return val;
            Error("ფორმატი: dd.MM.yyyy  (მაგ: 15.06.2024)");
        }
    }

    static void Header(string text) => Console.WriteLine($"──── {text} ────\n");

    static void Success(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n  ✅ {text}");
        Console.ResetColor();
    }

    static void Error(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\n  ❌ {text}");
        Console.ResetColor();
    }

    static void Info(string text)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"\n  ℹ  {text}");
        Console.ResetColor();
    }

    static void Pause()
    {
        Console.Write("\n  Enter-ი გასაგრძელებლად...");
        Console.ReadLine();
    }

}