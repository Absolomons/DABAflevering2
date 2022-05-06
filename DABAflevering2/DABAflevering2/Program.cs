﻿using DABAflevering2.Services;
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
            
            
            //**************Dummy data Rooms***************************//
            collectionRooms.InsertMany(

                )


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
                        //KeyResponsible();
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
                                  + booking.RoomId
                                  + "\n on address"
                                  + booking.Room.RoomAddress
                                  + " from "
                                  + booking.BookingStart
                                  + " to "
                                  + booking.BookingEnd);

                Console.WriteLine("\n");
            }
        }
    }
}

