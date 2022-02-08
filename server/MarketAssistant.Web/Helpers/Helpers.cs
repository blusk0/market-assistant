using MarketAssistant.Data;
using MarketAssistant.Models.Data;

namespace MarketAssistant.Web.Helpers;
public class Helpers
{
    public static void AddTestData(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {            
            var context = scope.ServiceProvider.GetRequiredService<MarketContext>();

            var greg = new Author { FirstName = "Greg", LastName = "Writesbooks" };
            var sally = new Author { FirstName = "Sally", LastName = "Pensalot" };
            var juan = new Author { FirstName = "Johnny", LastName = "Books" };
            var donna = new Author { FirstName = "Donna", LastName = "Bookspine" };
            var carl = new Author { FirstName = "Carl", LastName = "Thriller" };

            context.Authors.AddRange(greg, sally, juan, donna, carl);

            var bookSigning = new EventType { Description = "Book Signing" };
            var radioInterview = new EventType { Description = "Radio Interview" };
            var podcast = new EventType { Description = "Podcast" };
            var reading = new EventType { Description = "Book Reading" };

            context.EventTypes.AddRange(bookSigning, radioInterview, podcast, reading);

            var hardcover = new Format { Description = "Hardcover" };
            var paperback = new Format { Description = "Paperback" };
            var eBook = new Format { Description = "E-Book" };
            var audioBook = new Format { Description = "Audio Book" };

            context.Formats.AddRange(hardcover, paperback, eBook, audioBook);

            var posters = new MarketMaterialType { Description = "Posters " };
            var radioAd = new MarketMaterialType { Description = "Radio Ad" };
            var emailCampaign = new MarketMaterialType { Description = "E-Mail Campaign" };
            var websiteAd = new MarketMaterialType { Description = "Website Ad" };

            context.MarketMaterialTypes.AddRange(posters, radioAd, emailCampaign, websiteAd);

            List<Marketer> marketers = new List<Marketer>();
            marketers.Add(new Marketer { FirstName = "John", LastName = "Smith", EmployeeId = Guid.NewGuid() });
            marketers.Add(new Marketer { FirstName = "Krista", LastName = "Sellsbooks", EmployeeId = Guid.NewGuid() });
            marketers.Add(new Marketer { FirstName = "Bilbo", LastName = "Bookins", EmployeeId = Guid.NewGuid() });
            marketers.Add(new Marketer { FirstName = "George", LastName = "Jettson", EmployeeId = Guid.NewGuid() });
            marketers.Add(new Marketer { FirstName = "Patricia", LastName = "Novels", EmployeeId = Guid.NewGuid() });
            marketers.Add(new Marketer { FirstName = "Lisa", LastName = "Lovestory", EmployeeId = Guid.NewGuid() });

            context.Marketers.AddRange(marketers);

            context.SaveChanges();

            var now = DateTime.UtcNow;
            var rando = new Random();
            context.Books.Add(new Book { Author = greg, Format = hardcover, Isbn = "1232221234355", Title = "A Book for Reading", OnSaleDate = now.AddDays(rando.Next(1, 40)) });
            context.Books.Add(new Book { Author = sally, Format = paperback, Isbn = "1255221234355", Title = "To Be or To C", OnSaleDate = now.AddDays(rando.Next(1, 40)) });
            context.Books.Add(new Book { Author = juan, Format = eBook, Isbn = "1882221234355", Title = "I Fell Asleep at my Desk", OnSaleDate = now.AddDays(rando.Next(1, 40)) });
            context.Books.Add(new Book { Author = donna, Format = audioBook, Isbn = "1237721234355", Title = "Color Me Chartreuse", OnSaleDate = now.AddDays(rando.Next(1, 40)) });
            context.Books.Add(new Book { Author = carl, Format = eBook, Isbn = "3332221234355", Title = "Something For Your Cousin", OnSaleDate = now.AddDays(rando.Next(1, 40)) });
            context.Books.Add(new Book { Author = greg, Format = paperback, Isbn = "1232227734355", Title = "Bowling Pins Through the Years", OnSaleDate = now.AddDays(rando.Next(1, 40)) });
            context.Books.Add(new Book { Author = sally, Format = paperback, Isbn = "1232221234355", Title = "Supper", OnSaleDate = now.AddDays(rando.Next(1, 40)) });
            context.Books.Add(new Book { Author = juan, Format = paperback, Isbn = "4232621234335", Title = "Book 'Em, Danno", OnSaleDate = now.AddDays(rando.Next(1, 40)) });
            context.Books.Add(new Book { Author = donna, Format = hardcover, Isbn = "5232521234345", Title = "Particle Man, Particle Man", OnSaleDate = now.AddDays(rando.Next(1, 40)) });
            context.Books.Add(new Book { Author = carl, Format = eBook, Isbn = "6232421234365", Title = "The Cats of Baskerville", OnSaleDate = now.AddDays(rando.Next(1, 40)) });
            context.Books.Add(new Book { Author = carl, Format = audioBook, Isbn = "7212321234375", Title = "Cold Cases and Hot Sidewalks", OnSaleDate = now.AddDays(rando.Next(1, 40)) });
            context.Books.Add(new Book { Author = donna, Format = hardcover, Isbn = "0782221234385", Title = "Make My Leap Year", OnSaleDate = now.AddDays(rando.Next(1, 40)) });
            context.Books.Add(new Book { Author = juan, Format = paperback, Isbn = "0232121234395", Title = "I'm Just a Dog", OnSaleDate = now.AddDays(rando.Next(1, 40)) });

            context.SaveChanges();

            foreach (var book in context.Books)
            {
                book.PublishDate = book.OnSaleDate.AddDays(rando.Next(5, 40));
            }

            context.SaveChanges();

            var events = new List<Event>();
            var assignments = new List<MarketerAssignment>();
            var marketMaterials = new List<MarketMaterial>();
            int bookId;
            int eventTypeId;
            int marketerId;
            int marketMaterialTypeId;

            for (var i = 0; i < 50; i++)
            {
                bookId = rando.Next(1, 14);
                eventTypeId = rando.Next(1, 5);

                events.Add(new Event
                {
                    Book = context.Books.First(x => x.Id == bookId),
                    EventType = context.EventTypes.First(x => x.Id == eventTypeId),
                    EventDt = now.AddDays(rando.Next(60, 90))
                });

            }

            for (var i = 0; i < 10; i++)
            {
                marketerId = rando.Next(1, 7);
                bookId = rando.Next(1, 14);
                assignments.Add(new MarketerAssignment
                {
                    Book = context.Books.First(t => t.Id == bookId),
                    Marketer = context.Marketers.First(t => t.Id == marketerId),
                    AssignedDt = now.AddDays(rando.Next(-10, 0)),
                });
            }

            for (var i = 0; i < 10; i++)
            {
                marketMaterialTypeId = rando.Next(1, 5);
                bookId = rando.Next(1, 14);
                marketMaterials.Add(new MarketMaterial
                {
                    Book = context.Books.First(t => t.Id == bookId),
                    MarketMaterialType = context.MarketMaterialTypes.First(t => t.Id == marketMaterialTypeId),
                    MarketMaterialTypeId = marketMaterialTypeId,
                    StartDt = now.AddDays(rando.Next(30, 60)),
                    EndDt = now.AddDays(rando.Next(90, 120))
                });
            }

            context.MarketMaterials.AddRange(marketMaterials);
            context.MarketerAssignments.AddRange(assignments);
            context.Events.AddRange(events);
            context.SaveChanges();
        }
    }
}

