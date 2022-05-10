using DABAflevering2;
using DABAflevering2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DABAflevering2.Services;

public class BookedRoomsService
{
    private readonly IMongoCollection<Bookingoverview> _bookingOverviewCollection;

    public BookedRoomsService(
        MunicipalityDatabaseSettings municipalityDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            municipalityDatabaseSettings.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            municipalityDatabaseSettings.DatabaseName);

        _bookingOverviewCollection = mongoDatabase.GetCollection<Bookingoverview>(
            municipalityDatabaseSettings.BookingOverviewCollectionName);
    }

    public async Task<List<Bookingoverview>> GetAsync() =>
        await _bookingOverviewCollection.Find(x => true).ToListAsync();
    }
