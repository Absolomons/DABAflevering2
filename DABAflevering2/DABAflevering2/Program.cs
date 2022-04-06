using Microsoft.EntityFrameworkCore;

namespace DABAflevering2
{
    public class Program
    {
        public static void Main()
        {
            au674304Context dbContext = new au674304Context();

            var municipalityList = dbContext.Municipalities.Include(x => x.Rooms).ToList();


            //Municipality information with rooms
            foreach(var municipality in municipalityList)
            { 

                Console.WriteLine("Municipality with id: " + municipality.MunicipalityId + " has");

                foreach (var Rooms in municipality.Rooms)
                {
                    Console.WriteLine("Room with id: " + Rooms.RoomId + " has address "+ Rooms.RoomAddress);
                }

                Console.WriteLine("\n");
            }

            var societyList = dbContext.Societies.Include(x => x.Chairmen).ToList();

            var societyListSorted = societyList.OrderBy(s => s.Activity);


            //Get all societies
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
                    Console.WriteLine(Chairmen.ChairmanName );
                }
      
                Console.WriteLine("\n");
            }


            var bookingoverviewList = from bookingoverview in dbContext.Set<Bookingoverview>()
                join room in dbContext.Set<Room>() on bookingoverview.RoomId equals room.RoomId
                join society in dbContext.Set<Society>() on bookingoverview.Cvr equals society.Cvr
                join chairman in dbContext.Set<Chairman>() on society.Cvr equals chairman.Cvr
                select new {bookingoverview, room, society,chairman};

            foreach (var booking in bookingoverviewList)
            {
                Console.WriteLine("Society with activity: " + booking.society.Activity + "" +
                                  " has cvr "
                                  + booking.society.Cvr
                                  + " and has chairman "
                                  + booking.chairman.ChairmanName
                                  + " has booked room with ID\n "
                                  + booking.room.RoomId
                                  + " on address \n"
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

