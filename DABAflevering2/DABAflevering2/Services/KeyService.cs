using DABAflevering2;
using DABAflevering2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DABAflevering2.Services;

public class KeyService
{
    private readonly IMongoCollection<KeyResponsible> _keyResponsibleCollection;

    public KeyService(
        MunicipalityDatabaseSettings municipalityDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            municipalityDatabaseSettings.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            municipalityDatabaseSettings.DatabaseName);

        _keyCollection = mongoDatabase.GetCollection<KeyResponsible>(
            municipalityDatabaseSettings.MunicipalityCollectionName);
    }

    public async Task<KeyResponsible> GetAsync(KeyResponsible keyResponsible) =>
        await _keyCollection.Find(x => x.CPR == keyResponsible.CPR).FirstOrDefaultAsync();

    public async Task<List<Room>> GetAsync(Municipality municipality) =>
        await _roomCollection.Find(x => x.MunicipalityId == municipality.MunicipalityId).ToListAsync();
}