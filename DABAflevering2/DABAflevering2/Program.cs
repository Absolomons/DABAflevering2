using DABAflevering2.Services;
using Microsoft.EntityFrameworkCore;
using DABAflevering2.Models;

using MongoDB.Bson;
using MongoDB.Driver;

namespace DABAflevering2
{
    public class Program
    {
        public static void Main()
        {

            MongoClient dbClient = new MongoClient();

            var database = dbClient.GetDatabase("Municipality");
            var collectionBookingOverviews = database.GetCollection<Bookingoverview>("BookingOverviews");
            var collectionRooms = database.GetCollection<Room>("Room");
            var collectionMunicipality = database.GetCollection<Municipality>("Municipality");
            var collectionSocieties = database.GetCollection<Society>("Societies");

            //****************Municipality**************//

        //    var mun1 = new Municipality
        //    {
        //        Name = "Randers"
        //};

        //    var mun2 = new Municipality
        //    {
        //        Name = "Horsens"
        //    };


        //     collectionMunicipality.InsertOne(mun1);

        //     collectionMunicipality.InsertOne(mun2);


        //    //********************Key************************//
        //    var key1 = new Key
        //        {
        //            keyId = "1",
        //            keyLocation = "Ceresbyen 5"
        //        };

        //    var key2 = new Key
        //    {
        //        keyId = "2",
        //        keyLocation = "Finlandsgade 32"
        //    };

        //    //********************Rooms***************************//
        //    var room1 = new Room
        //    {
        //        Roomlimit = 20,
        //        TimespanStart = DateTime.Now,
        //        TimespanEnd = DateTime.Now,
        //        RoomAddress = "Finlandsgade 12",
        //        AccessCode = 4321,
        //        Municipality = mun1,
        //        key = key1,
        //        Property = new Property
        //        {
        //            WiFi = true,
        //            Whiteboard = true,
        //            SoccerGoals = false,
        //            Coffee = true
        //        }
        //    };

        //    var room2 = new Room
        //    {
        //        Roomlimit = 20,
        //        TimespanStart = DateTime.Now,
        //        TimespanEnd = DateTime.Now,
        //        RoomAddress = "Jægersgade 3",
        //        AccessCode = 4321,
        //        Municipality = mun1,
        //        key = key2,
        //        Property = new Property
        //        {
        //            WiFi= false,
        //            Whiteboard = true,
        //            SoccerGoals = true,
        //            Coffee = true 
        //        }
        //    };
        //       collectionRooms.InsertOne(room1);

        //       collectionRooms.InsertOne(room2);

        //   // ********************Chairmen * **************************//
        //   var chair1 = new Chairman
        //    {
        //            HomeAddress = "Jyllandvej",
        //            ChairmanName = "Jens Jensen",
        //            Cpr = "5645"
        //    };

        //    var chair2 = new Chairman
        //        {
        //            HomeAddress = "Sjællandsvej",
        //            ChairmanName = "Chris Hansen",
        //            Cpr = "5795"
        //        };

        //    // //********************Members***************************//
        //    var mem1 = new Member
        //     {
        //        Name= "Jorge",
        //        Cpr = "5426"
        //     };
        //    var mem2 = new Member
        //     {
        //         Name = "Graig" ,
        //         Cpr = "1342"
        //     };

        //    // //********************Societies***************************//
        //    var soci1 = new Society
        //    {
        //        NumberOfMembers = 3,
        //        Name = "Chess Society",
        //        Activity = "Chess",
        //        Cvr = "1234",
        //        SocAddress = "Strandvejen 1",
        //        Municipality = mun1,
        //        Chairmen = chair1,
        //        keyResponsible = new KeyResponsible
        //        {
        //            CPR = chair1.Cpr,
        //            HomeAddress = chair1.HomeAddress,
        //            PhoneNumber = 56737282,
        //            Passport = 75757575
        //        }
        //    };

        //    //Hvordan tilføjer jeg members
        //    var soci2 = new Society{ 
        //        NumberOfMembers = 30,
        //        Name = "FUT",
        //        Activity = "Drinking",
        //        Cvr = "4321",
        //        SocAddress = "Katrines kældes",
        //        Municipality = mun1,
        //        Chairmen = chair2
        //      };

        //    collectionSocieties.InsertOne(soci1);
        //    collectionSocieties.InsertOne(soci2);

        //    //********************Bookings***************************//
        //    var book1 = new Bookingoverview
        //     {
        //        SocietyCvr = "1234",
        //        SocietyName = "ChessSociety",
        //        ChairmanName = "Jens Jensen",
        //        BookingStart = DateTime.Now,
        //        BookingEnd = DateTime.Now,
        //        Room =room1
        //     };

        //    var book2 = new Bookingoverview
        //     {
        //        SocietyCvr = "4321",
        //        SocietyName = "FUT",
        //        ChairmanName = "Cheis Hansen",
        //        BookingStart = DateTime.Now,
        //        BookingEnd = DateTime.Now,
        //        Room = room2

        //     };

        //    collectionBookingOverviews.InsertOne(book1);
        //    collectionBookingOverviews.InsertOne(book2);


            Console.WriteLine("Enter 1 to get a list of alle Municipality information\n " +
                              "Enter 2 to get a list of all societies sorted by their activity\n" +
                              "Enter 3 to get a list of all booked rooms, including the society name and chairman\n" +
                              "Enter 4 to get a list of alle future bookings for a key responsible\n");

            while (true)
            {
                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Municipality();
                        break;

                    case "2":
                        SocietyActivity();
                        break;

                    case "3":
                        BookedRooms();
                        break;
                    case "4":
                        KeyResponsibleQ();
                        break;
                }
            }
                
        
        }

        static void Municipality()
        {
            var options = new MunicipalityDatabaseSettings();
            var municipalityService = new MunicipalityService(options);

            string id = "Randers";

            var municipality = municipalityService.GetAsync(id);

            if (municipality.Result != null)
            {
                Console.WriteLine("Municipality with name " + municipality.Result.Name +" has ");

                var rooms = municipalityService.GetAsync(municipality.Result);

                foreach (var room in rooms.Result)
                {
                    Console.WriteLine("Room with id: " + room.RoomId + " has address " + room.RoomAddress);
                }
                Console.WriteLine("\n");
           }
            else
            {
                Console.WriteLine("Ingen municipalities fundet");
            }


        }

        static void SocietyActivity()
        {

            var options = new MunicipalityDatabaseSettings();
            var societyService = new SocietyService(options);

            var societyList = societyService.GetAsync();

            if(societyList.Result == null)
            {
                Console.WriteLine("Der er ingen societies");
            }
            else
            {
                var societyListSorted = societyList.Result.OrderBy(s => s.Activity);


                foreach (var society in societyListSorted)
                {

                    Console.WriteLine("Society with activity: " + society.Activity + "" +
                        " has cvr "
                        + society.Cvr
                        + " and address "
                        + society.SocAddress
                        + " and Chairman with name "
                        + society.Chairmen.ChairmanName);
                }
                Console.WriteLine("\n");
            }
        }

        static void BookedRooms()
        {
            var options = new MunicipalityDatabaseSettings();
            var bookedRoomsService = new BookedRoomsService(options);

            var bookedRooms = bookedRoomsService.GetAsync();

            foreach (var booking in bookedRooms.Result)
            {

                Console.WriteLine("Society has cvr "
                                  + booking.SocietyCvr
                                  + " and has chairman "
                                  + booking.ChairmanName
                                  + " has booked room with ID "
                                  + booking.Room.RoomId
                                  + "\n on address "
                                  + booking.Room.RoomAddress
                                  + " from "
                                  + booking.BookingStart
                                  + " to "
                                  + booking.BookingEnd);

                Console.WriteLine("\n");
            }
        }

        static void KeyResponsibleQ()
        {
            var options = new MunicipalityDatabaseSettings();
            var keyService = new KeyService(options);

            string CPR = "5645";

            var society = keyService.GetAsync(CPR); 

            var bookings = keyService.GetAsync(society.Result);

            if (keyService.GetAsync(CPR).Result !=null)
            {
                Console.WriteLine("Keyresponsible with CPR "
                                      + CPR
                                      + " belongs to society "
                                      + society.Result.Name
                                      + ".\n\n Here is list of bookings\n");

                foreach (var booking in bookings.Result)
                {

                    Console.WriteLine("Booked room on address "
                                      + booking.Room.RoomAddress
                                      + " is booked from "
                                      + booking.BookingStart
                                      + " to "
                                      + booking.BookingEnd
                                      + ".\n The room has access code: "
                                      + booking.Room.AccessCode
                                      + "\n and has key location: "
                                      + booking.Room.key.keyLocation
                                      );
                    Console.WriteLine("\n");
                }
            }
            else
            Console.WriteLine("Der er ingen keyResponsibles");
        }
    }
}

