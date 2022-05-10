using DABAflevering2;
using DABAflevering2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DABAflevering2.Services;

public class MunicipalityService
{
    private readonly IMongoCollection<Municipality> _municipalityCollection;
    private readonly IMongoCollection<Room> _roomCollection;

    public MunicipalityService(
        MunicipalityDatabaseSettings municipalityDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            municipalityDatabaseSettings.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            municipalityDatabaseSettings.DatabaseName);

         _municipalityCollection = mongoDatabase.GetCollection<Municipality>(
            municipalityDatabaseSettings.MunicipalityCollectionName);

        _roomCollection = mongoDatabase.GetCollection<Room>(
            municipalityDatabaseSettings.RoomCollectionName);
    }

    public async Task<Municipality> GetAsync(string name) =>
        await _municipalityCollection.Find(x => x.Name == name).FirstOrDefaultAsync();

    public async Task<List<Room>> GetAsync(Municipality municipality) =>
        await _roomCollection.Find(x => x.Municipality.Name == municipality.Name).ToListAsync();
}