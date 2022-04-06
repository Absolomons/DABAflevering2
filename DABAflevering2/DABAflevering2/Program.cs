using Microsoft.EntityFrameworkCore;

namespace DABAflevering2
{
    public class Program
    {
        public static void Main()
        {
            au674304Context dbContext = new au674304Context();

            var municipalityList = dbContext.Municipalities.Include(x => x.Rooms).ToList();

            Console.WriteLine("Enter 1 to get a list of alle Municipality information\n " +
                "Enter 2 to get a list of all societies sorted by their activity\n" +
                "Enter 3 to get a list of all the booked rooms, including the sociery name and chairman");

            var input = Console.ReadLine();            

            switch(input)
            {
                case "1":
                    Console.WriteLine("hey1");
                    break;

                case "2":
                    Console.WriteLine("hey2");
                    break;

                case "3":
                    Console.WriteLine("hey3");
                    break;
            }
                
            
           
            //Municipality information with rooms
            foreach (var municipality in municipalityList)
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

        }

    }
}

