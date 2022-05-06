using Microsoft.EntityFrameworkCore;

using MongoDB.Bson;
using MongoDB.Driver;

namespace DABAflevering2
{
    public class Program
    {
        public static void Main()
        {
            au674304Context dbContext = new au674304Context();

            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("sample_training");
            var collection = database.GetCollection<BsonDocument>("grades");


            Console.WriteLine("Enter 1 to get a list of alle Municipality information\n " +
                "Enter 2 to get a list of all societies sorted by their activity\n" +
                "Enter 3 to get a list of all the booked rooms, including the sociery name and chairman");

            while (true)
            {
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Municipality(dbContext);
                        break;

                    case "2":
                        SocietyActivity(dbContext);
                        break;

                    case "3":
                        bookedRooms(dbContext);
                        break;
                }
            }
                
        
        }

        static void Municipality(au674304Context dbContext)
        {
            var municipalityList = dbContext.Municipalities.Include(x => x.Rooms).ToList();

            foreach (var municipality in municipalityList)
            {

                Console.WriteLine("Municipality with id: " + municipality.MunicipalityId + " has");

                foreach (var Rooms in municipality.Rooms)
                {
                    Console.WriteLine("Room with id: " + Rooms.RoomId + " has address " + Rooms.RoomAddress);
                }

                Console.WriteLine("\n");
            }

        }

        static void SocietyActivity(au674304Context dbContext)
        {
            var societyList = dbContext.Societies.Include(x => x.Chairmen).ToList();

            var societyListSorted = societyList.OrderBy(s => s.Activity);

            foreach (var society in societyListSorted)
            {

                Console.WriteLine("Society with activity: " + society.Activity + "" +
                    " has cvr "
                    + society.Cvr
                    + " and address "
                    + society.SocAddress
                    + " and Chairman with name");

                foreach (var Chairmen in society.Chairmen)
                {
                    Console.WriteLine(Chairmen.ChairmanName);
                }

                Console.WriteLine("\n");
            }
        }

        static void bookedRooms(au674304Context dbContext)
        {
            var bookingoverviewList = from bookingoverview in dbContext.Set<Bookingoverview>()
                                      join room in dbContext.Set<Room>() on bookingoverview.RoomId equals room.RoomId
                                      join society in dbContext.Set<Society>() on bookingoverview.Cvr equals society.Cvr
                                      join chairman in dbContext.Set<Chairman>() on society.Cvr equals chairman.Cvr
                                      select new { bookingoverview, room, society, chairman };

            foreach (var booking in bookingoverviewList)
            {
              
                Console.WriteLine("Society has cvr "
                                  + booking.society.Cvr
                                  + " and has chairman "
                                  + booking.chairman.ChairmanName
                                  + " has booked room with ID "
                                  + booking.room.RoomId
                                  + "\n on address"
                                  + booking.room.RoomAddress
                                  + " from "
                                  + booking.bookingoverview.BookingStart
                                  + " to "
                                  + booking.bookingoverview.BookingEnd);

                Console.WriteLine("\n");
            }
        }

    }
}

