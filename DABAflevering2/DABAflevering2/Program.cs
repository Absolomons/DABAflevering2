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

        }

    }
}

