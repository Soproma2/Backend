using HomeWork32.Models;
using HomeWork32.Services.PostService;
using HomeWork32.Services.UserService;

UserService userService = new UserService();
PostService postService = new PostService();
User currentUser = null;

while (true)
{
    Console.WriteLine("\n===== Main Menu =====");
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Login");
    Console.WriteLine("3. Create Post");
    Console.WriteLine("4. Update Post");
    Console.WriteLine("5. Delete Post");
    Console.WriteLine("6. Show Posts");
    Console.WriteLine("7. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            userService.Register();
            break;

        case "2":
            currentUser = userService.Login();
            break;

        case "3":
            if (currentUser == null)
            {
                Console.WriteLine("You must login first!");
            }
            else
            {
                postService.CreatePost(currentUser);
            }
            break;

        case "4":
            if (currentUser == null)
            {
                Console.WriteLine("You must login first!");
            }
            else
            {
                postService.UpdatePost(currentUser);
            }
            break;

        case "5":
            if (currentUser == null)
            {
                Console.WriteLine("You must login first!");
            }
            else
            {
                postService.DeletePost(currentUser);
            }
            break;

        case "6":
            postService.ShowPosts();
            break;

        case "7":
            Console.WriteLine("Exiting...");
            return;

        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}
