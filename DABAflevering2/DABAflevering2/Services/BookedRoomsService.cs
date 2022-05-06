using DABAflevering2;
using DABAflevering2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DABAflevering2.Services;

public class MunicipalityService
{
    private readonly IMongoCollection<Society> _societyCollection;
    private readonly IMongoCollection<Room> _roomCollection;
    private readonly IMongoCollection<Bookingoverview> _bookingOverviewCollection;
    private readonly IMongoCollection<Municipality> _municipalityCollection;

    public MunicipalityService(
        IOptions<MunicipalityDatabaseSettings> municipalityDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            municipalityDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            municipalityDatabaseSettings.Value.DatabaseName);

        _societyCollection = mongoDatabase.GetCollection<Society>(
            municipalityDatabaseSettings.Value.MunicipalityCollectionName);

        _municipalityCollection = mongoDatabase.GetCollection<Municipality>(
           municipalityDatabaseSettings.Value.MunicipalityCollectionName);

        _roomCollection = mongoDatabase.GetCollection<Room>(
            municipalityDatabaseSettings.Value.MunicipalityCollectionName);

        _bookingOverviewCollection = mongoDatabase.GetCollection<Bookingoverview>(
            municipalityDatabaseSettings.Value.MunicipalityCollectionName);
    }

    public async Task<Municipality> GetAsync(int id) =>
        await _municipalityCollection.Find(x => x.MunicipalityId == id).FirstOrDefaultAsync();

    public async Task<List<Room>> GetAsync(Municipality municipality) =>
        await _roomCollection.Find(x => x.MunicipalityId == municipality.MunicipalityId).ToListAsync();

    public async Task<List<Bookingoverview>> GetAsync(Room room) =>
    await _bookingOverviewCollection.Find(x => x.RoomId == room.RoomId).ToListAsync();

    public async Task<List<Society>> GetAsync(Bookingoverview bookingoverview) =>
    await _societyCollection.Find(x => x.Cvr == bookingoverview.Cvr).ToListAsync();
}
}
