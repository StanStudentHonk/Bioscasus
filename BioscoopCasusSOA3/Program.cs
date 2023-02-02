// See https://aka.ms/new-console-template for more information
using BioscoopCasusSOA3.Models;

Console.WriteLine("Hello, World!");
Order order = new Order(5, true);
order.AddSeatReservations(new MovieTicket(12, 12, true, new MovieScreening(DateTime.Now, 20.50, new Movie("Khalid doet boem"))));
order.Export(TicketExportFormat.PLAINTEXT);
order.Export(TicketExportFormat.JSON);