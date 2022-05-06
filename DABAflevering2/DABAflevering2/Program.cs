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
            var collectionBookingOverviews = database.GetCollection<BsonDocument>("BookingOverviews");
            var collectionRooms = database.GetCollection<BsonDocument>("Rooms");
            var collectionMunicipality = database.GetCollection<BsonDocument>("Municipality");
            var collectionSocieties = database.GetCollection<BsonDocument>("Societies");

            if (collectionRooms == null) //Ikke sikker på at det her er en god løsning.
            {
                
                //****************Municipality**************//
                var mun1 = new BsonDocument
                {
                    {"MunicipalityId", "1" },
                };

                var mun2 = new BsonDocument
                {
                    {"MunicipalityId", "2" },
                };

                collectionMunicipality.InsertOne(mun1);

                collectionMunicipality.InsertOne(mun2);


                //********************Key************************//
                var key1 = new BsonDocument
                {
                    { "keyId","1"},
                    { "keyLocation","Ceresbyen 5"}
                };

                var key2 = new BsonDocument
                {
                    { "keyId","2"},
                    { "keyLocation","Finlandsgade 32"}
                };

                //********************Property************************//
                var prop1 = new BsonDocument
                {
                    {"PropertyId","1"},
                    {"WiFi","true"},
                    {"Whiteboard","true"},
                    {"SoccerGoals","true"},
                    {"Coffee","true"}
                };

                var prop2 = new BsonDocument
                {
                    {"PropertyId","2"},
                    {"WiFi","false"},
                    {"Whiteboard","true"},
                    {"SoccerGoals","true"},
                    {"Coffee","true"}
                };

                //********************Rooms***************************//
                var room1 = new BsonDocument
                {
                    { "Roomlimit","10" },
                    { "TimespanStart", "2022, 3, 15"} ,
                    { "TimespanEnd", "2022, 3, 20" },
                    { "RoomAddress","Finlandsgade 12" },
                    { "AccessCode", 1234 },
                };

                room1.Add(mun1);
                room1.Add(key1);
                room1.Add(prop1);

                var room2 = new BsonDocument
                {
                    { "Roomlimit","20" },
                    { "TimespanStart", "2024, 7, 11"} ,
                    { "TimespanEnd", "2025, 6, 25" },
                    { "RoomAddress","Jægersgade 3" },
                    { "AccessCode", 4321 }
                };

                room2.Add(mun1);
                room2.Add(key2);
                room2.Add(prop2);

                collectionRooms.InsertOne(room1);
                collectionRooms.InsertOne(room2);


                //********************Chairmen***************************//
                var chair1 = new BsonDocument
                {
                    { "HomeAddress","Jyllandvej" },
                    { "ChairmanName", "Jens Jensen"} ,
                    { "Cpr", "5645" },
                };

                var chair2 = new BsonDocument
                {
                    { "HomeAddress","Sjællandvej" },
                    { "ChairmanName", "Chris Hansen"} ,
                    { "Cpr", "5795" },
                };

                //********************Members***************************//
                var mem1 = new BsonDocument
                {
                    { "Name", "Jorge"} ,
                    { "Cpr", "5426" },
                };
                var mem2 = new BsonDocument
                {
                    { "Name", "Graig"} ,
                    { "Cpr", "1342" },
                };

                //********************Societies***************************//
                var soci1 = new BsonDocument
                {
                    { "NumberOfMembers","3" },
                    { "Name", "ChessSociety"} ,
                    { "Activity", "Chess" },
                    { "CVR","1234" },
                    { "SocAddress", "Strandvejen 1"}
                };
                soci1.Add(mun1);
                soci1.Add(chair1);
                soci1.Add(mem1);


                var soci2 = new BsonDocument
                {
                    { "NumberOfMembers","30" },
                    { "Name", "FUT"} ,
                    { "Activity", "Drinking" },
                    { "CVR","3333" },
                    { "SocAddress", "Katrines Kælder?"}
                };
                soci2.Add(mun2);
                soci2.Add(chair2);
                soci2.Add(mem2);

                collectionSocieties.InsertOne(soci1);
                collectionSocieties.InsertOne(soci2);

                //********************Bookings***************************//
                var book1 = new BsonDocument
                {
                    { "SocietyCvr","1234" },
                    { "SocietyName", "ChessSociety"} ,
                    { "ChairmanName", "Jens Jensen" },
                    { "BookingStart","2022, 3, 16" },
                    { "BookingEnd","2022, 3, 18" }
                };
                book1.Add(room1);

                var book2 = new BsonDocument
                {
                    { "SocietyCvr","4321" },
                    { "SocietyName", "FUT"} ,
                    { "ChairmanName", "Chris Hansen" },
                    { "BookingStart","2024, 12, 16" },
                    { "BookingEnd","2025, 1, 1" }
                };
                book2.Add(room2);

                collectionBookingOverviews.InsertOne(book1);
                collectionBookingOverviews.InsertOne(book2);


            }

            Console.WriteLine("Enter 1 to get a list of alle Municipality information\n " +
                              "Enter 2 to get a list of all societies sorted by their activity\n" +
                              "Enter 3 to get a list of all the booked rooms, including the society name and chairman\n" +
                              "Enter 4 to get a list of all key-responsible people\n");

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

            string id = "1";

            var municipality = municipalityService.GetAsync(id);

            if (municipality.Result != null)
            {
                Console.WriteLine("Municipality with id: " + municipality.Result.MunicipalityId + " has");

                var rooms = municipalityService.GetAsync(municipality.Result);

                foreach (var room in rooms.Result)
                {
                    Console.WriteLine("Room with id: " + room.RoomId + " has address " + room.RoomAddress);
                }
            }

            Console.WriteLine("Det her er vildt");


        }

        static void SocietyActivity()
        {

            var options = new MunicipalityDatabaseSettings();
            var societyService = new SocietyService(options);

            var societyList = societyService.GetAsync();

            var societyListSorted = societyList.Result.OrderBy(s => s.Activity);


            foreach (var society in societyListSorted)
            {

                Console.WriteLine("Society with activity: " + society.Activity + "" +
                    " has cvr "
                    + society.Cvr
                    + " and address "
                    + society.SocAddress
                    + " and Chairman with name "
                    + society.Chairmen.ChairmanName
                    + "\n");

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
                                  + "\n on address"
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

            var keyResponsible = new KeyResponsible();
            keyResponsible.CPR = "1234";

            if (keyService.GetAsync(keyResponsible).Result !=null)
            {
                var bookedRooms = keyService.GetAsync();

                foreach (var booking in bookedRooms.Result)
                {

                    Console.WriteLine("Booked room with ID "
                                      + booking.Room.RoomId
                                      + " on address"
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
        }
    }
}

