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
        IOptions<MunicipalityDatabaseSettings> municipalityDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            municipalityDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            municipalityDatabaseSettings.Value.DatabaseName);

        _municipalityCollection = mongoDatabase.GetCollection<Municipality>(
            municipalityDatabaseSettings.Value.MunicipalityCollectionName);

        _roomCollection = mongoDatabase.GetCollection<Room>(
            municipalityDatabaseSettings.Value.MunicipalityCollectionName);
    }

    public async Task<Municipality> GetAsync(int id) =>
        await _municipalityCollection.Find(x => x.MunicipalityId == id).FirstOrDefaultAsync();

    public async Task<List<Room>> GetAsync(Municipality municipality) =>
        await _roomCollection.Find(x => x.MunicipalityId == municipality.MunicipalityId).ToListAsync();
}