using HomeWork_50___One_to_one.Data;
using HomeWork_50___One_to_one.Models;
using Microsoft.EntityFrameworkCore;

DataContext _db = new DataContext();

while (true)
{
    Console.WriteLine("\n========== HOTEL MANAGEMENT SYSTEM ==========");
    Console.WriteLine("1. Register Guest");
    Console.WriteLine("2. Show Guest Profile");
    Console.WriteLine("3. Issue Loyalty Card");
    Console.WriteLine("4. Create Room");
    Console.WriteLine("5. Assign Room Key");
    Console.WriteLine("6. Setup Minibar");
    Console.WriteLine("7. Create Booking");
    Console.WriteLine("8. Generate Invoice");
    Console.WriteLine("9. Process Payment");
    Console.WriteLine("10. Show All Guests");
    Console.WriteLine("11. Show All Rooms");
    Console.WriteLine("12. Show Active Bookings");
    Console.WriteLine("0. Exit");

    Console.Write("\nEnter your choice: ");
    string key = Console.ReadLine();

    if (key == "1")
    {
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();

        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();

        Console.Write("Phone: ");
        string phone = Console.ReadLine();

        Console.Write("Passport Number: ");
        string passportNumber = Console.ReadLine();

        Console.Write("Country: ");
        string country = Console.ReadLine();

        Console.Write("Expiry Date (yyyy-MM-dd): ");
        DateTime expiryDate = DateTime.Parse(Console.ReadLine());

        Guest guest = new Guest
        {
            FirstName = firstName,
            LastName = lastName,
            Phone = phone,
            Passport = new Passport
            {
                PassportNumber = passportNumber,
                Country = country,
                ExpiryDate = expiryDate
            }
        };

        _db.Guests.Add(guest);
        _db.SaveChanges();
        Console.WriteLine("Guest registered successfully!");
    }
    else if (key == "2")
    {
        Console.Write("Guest ID: ");
        int guestId = int.Parse(Console.ReadLine());

        var guest = _db.Guests
            .Include(g => g.Passport)
            .Include(g => g.LoyaltyCard)
            .FirstOrDefault(g => g.Id == guestId);

        if (guest == null)
        {
            Console.WriteLine("Guest not found!");
        }
        else
        {
            Console.WriteLine("\n========== GUEST INFORMATION ==========");
            Console.WriteLine($"ID: {guest.Id}");
            Console.WriteLine($"Name: {guest.FirstName} {guest.LastName}");
            Console.WriteLine($"Phone: {guest.Phone}");
            Console.WriteLine($"Registration Date: {guest.RegistrationDate:yyyy-MM-dd}");

            Console.WriteLine("\n--- Passport ---");
            Console.WriteLine($"Number: {guest.Passport.PassportNumber}");
            Console.WriteLine($"Country: {guest.Passport.Country}");
            Console.WriteLine($"Expiry: {guest.Passport.ExpiryDate:yyyy-MM-dd}");

            if (guest.LoyaltyCard != null)
            {
                Console.WriteLine("\n--- Loyalty Card ---");
                Console.WriteLine($"Card Number: {guest.LoyaltyCard.CardNumber}");
                Console.WriteLine($"Points: {guest.LoyaltyCard.Points}");
                Console.WriteLine($"Member Since: {guest.LoyaltyCard.MemberSince:yyyy-MM-dd}");
            }
        }
    }
    else if (key == "3")
    {
        Console.Write("Guest ID: ");
        int guestId = int.Parse(Console.ReadLine());

        var existingCard = _db.LoyaltyCards.FirstOrDefault(l => l.GuestId == guestId);

        if (existingCard != null)
        {
            Console.WriteLine("Loyalty card already issued!");
        }
        else
        {
            LoyaltyCard card = new LoyaltyCard
            {
                GuestId = guestId,
                CardNumber = $"LC{DateTime.Now.Ticks}",
                Points = 100
            };

            _db.LoyaltyCards.Add(card);
            _db.SaveChanges();
            Console.WriteLine($"Loyalty card issued! Number: {card.CardNumber}");
            Console.WriteLine($"Initial Points: {card.Points}");
        }
    }
    else if (key == "4")
    {
        Console.Write("Room Number: ");
        string roomNumber = Console.ReadLine();

        Console.Write("Floor: ");
        int floor = int.Parse(Console.ReadLine());

        Console.Write("Type (Standard/Deluxe/Suite): ");
        string type = Console.ReadLine();

        Room room = new Room
        {
            RoomNumber = roomNumber,
            Floor = floor,
            Type = type
        };

        _db.Rooms.Add(room);
        _db.SaveChanges();
        Console.WriteLine("Room created successfully!");
    }
    else if (key == "5")
    {
        Console.Write("Room ID: ");
        int roomId = int.Parse(Console.ReadLine());

        Console.Write("Key Code: ");
        string keyCode = Console.ReadLine();

        var existingKey = _db.RoomKeys.FirstOrDefault(k => k.RoomId == roomId);

        if (existingKey != null)
        {
            existingKey.KeyCode = keyCode;
            existingKey.IsActive = true;
            existingKey.IssuedDate = DateTime.Now;
            Console.WriteLine("Room key updated!");
        }
        else
        {
            RoomKey roomKey = new RoomKey
            {
                RoomId = roomId,
                KeyCode = keyCode
            };

            _db.RoomKeys.Add(roomKey);
            Console.WriteLine("Room key assigned!");
        }

        _db.SaveChanges();
    }
    else if (key == "6")
    {
        Console.Write("Room ID: ");
        int roomId = int.Parse(Console.ReadLine());

        Console.Write("Initial Value: ");
        decimal value = decimal.Parse(Console.ReadLine());

        var existingMinibar = _db.Minibars.FirstOrDefault(m => m.RoomId == roomId);

        if (existingMinibar != null)
        {
            Console.WriteLine("Minibar already setup!");
        }
        else
        {
            Minibar minibar = new Minibar
            {
                RoomId = roomId,
                CurrentValue = value
            };

            _db.Minibars.Add(minibar);
            _db.SaveChanges();
            Console.WriteLine("Minibar setup successfully!");
        }
    }
    else if (key == "7")
    {
        Console.Write("Guest ID: ");
        int guestId = int.Parse(Console.ReadLine());

        Console.Write("Room ID: ");
        int roomId = int.Parse(Console.ReadLine());

        Console.Write("Check-In Date (yyyy-MM-dd): ");
        DateTime checkIn = DateTime.Parse(Console.ReadLine());

        Console.Write("Check-Out Date (yyyy-MM-dd): ");
        DateTime checkOut = DateTime.Parse(Console.ReadLine());

        var room = _db.Rooms.Find(roomId);

        if (room == null)
        {
            Console.WriteLine("Room not found!");
        }
        else if (!room.IsAvailable)
        {
            Console.WriteLine("Room is not available!");
        }
        else
        {
            Booking booking = new Booking
            {
                GuestId = guestId,
                RoomId = roomId,
                CheckInDate = checkIn,
                CheckOutDate = checkOut
            };

            room.IsAvailable = false;

            _db.Bookings.Add(booking);
            _db.SaveChanges();
            Console.WriteLine($"Booking created! ID: {booking.Id}");
        }
    }
    else if (key == "8")
    {
        Console.Write("Booking ID: ");
        int bookingId = int.Parse(Console.ReadLine());

        var existingInvoice = _db.Invoices.FirstOrDefault(i => i.BookingId == bookingId);

        if (existingInvoice != null)
        {
            Console.WriteLine("Invoice already generated!");
        }
        else
        {
            Console.Write("Total Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            Invoice invoice = new Invoice
            {
                BookingId = bookingId,
                TotalAmount = amount
            };

            _db.Invoices.Add(invoice);
            _db.SaveChanges();
            Console.WriteLine("Invoice generated successfully!");
        }
    }
    else if (key == "9")
    {
        Console.Write("Booking ID: ");
        int bookingId = int.Parse(Console.ReadLine());

        var invoice = _db.Invoices.FirstOrDefault(i => i.BookingId == bookingId);

        if (invoice == null)
        {
            Console.WriteLine("Invoice not found!");
        }
        else if (invoice.IsPaid)
        {
            Console.WriteLine("Invoice already paid!");
        }
        else
        {
            invoice.IsPaid = true;
            invoice.PaymentDate = DateTime.Now;

            _db.SaveChanges();
            Console.WriteLine("Payment processed successfully!");
        }
    }
    else if (key == "10")
    {
        var guests = _db.Guests
            .Include(g => g.Passport)
            .Include(g => g.LoyaltyCard)
            .ToList();

        Console.WriteLine("\n========== GUESTS LIST ==========");
        foreach (var guest in guests)
        {
            Console.WriteLine($"ID: {guest.Id} | {guest.FirstName} {guest.LastName} | {guest.Phone}");
            Console.WriteLine($"   Passport: {guest.Passport.PassportNumber} ({guest.Passport.Country})");
            if (guest.LoyaltyCard != null)
            {
                Console.WriteLine($"   Loyalty Points: {guest.LoyaltyCard.Points}");
            }
            Console.WriteLine();
        }
    }
    else if (key == "11")
    {
        var rooms = _db.Rooms
            .Include(r => r.RoomKey)
            .Include(r => r.Minibar)
            .ToList();

        Console.WriteLine("\n========== ROOMS LIST ==========");
        foreach (var room in rooms)
        {
            Console.WriteLine($"ID: {room.Id} | Room #{room.RoomNumber} | Floor: {room.Floor} | Type: {room.Type}");
            Console.WriteLine($"   Status: {(room.IsAvailable ? "Available" : "Occupied")}");
            if (room.RoomKey != null)
            {
                Console.WriteLine($"   Key Code: {room.RoomKey.KeyCode} ({(room.RoomKey.IsActive ? "Active" : "Inactive")})");
            }
            if (room.Minibar != null)
            {
                Console.WriteLine($"   Minibar Value: ${room.Minibar.CurrentValue}");
            }
            Console.WriteLine();
        }
    }
    else if (key == "12")
    {
        var bookings = _db.Bookings
            .Where(b => b.IsActive)
            .Include(b => b.Guest)
            .Include(b => b.Room)
            .Include(b => b.Invoice)
            .ToList();

        Console.WriteLine("\n========== ACTIVE BOOKINGS ==========");
        foreach (var booking in bookings)
        {
            Console.WriteLine($"Booking #{booking.Id}");
            Console.WriteLine($"   Guest: {booking.Guest.FirstName} {booking.Guest.LastName}");
            Console.WriteLine($"   Room: {booking.Room.RoomNumber}");
            Console.WriteLine($"   Check-In: {booking.CheckInDate:yyyy-MM-dd}");
            Console.WriteLine($"   Check-Out: {booking.CheckOutDate:yyyy-MM-dd}");
            if (booking.Invoice != null)
            {
                Console.WriteLine($"   Amount: ${booking.Invoice.TotalAmount}");
                Console.WriteLine($"   Paid: {(booking.Invoice.IsPaid ? "Yes" : "No")}");
            }
            Console.WriteLine();
        }
    }
    else if (key == "0")
    {
        Console.WriteLine("Thank you!");
        break;
    }
    else
    {
        Console.WriteLine("Invalid choice!");
    }
}