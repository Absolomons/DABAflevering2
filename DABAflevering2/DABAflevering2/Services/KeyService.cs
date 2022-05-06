using DABAflevering2;
using DABAflevering2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DABAflevering2.Services;

public class KeyService
{
    private readonly IMongoCollection<KeyResponsible> _keyResponsibleCollection;
    private readonly IMongoCollection<Bookingoverview> _bookingOverviewCollection;


    public KeyService(
        MunicipalityDatabaseSettings municipalityDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            municipalityDatabaseSettings.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            municipalityDatabaseSettings.DatabaseName);

        _keyResponsibleCollection = mongoDatabase.GetCollection<KeyResponsible>(
            municipalityDatabaseSettings.MunicipalityCollectionName);

        _bookingOverviewCollection = mongoDatabase.GetCollection<Bookingoverview>(
            municipalityDatabaseSettings.MunicipalityCollectionName);
    }

    public async Task<KeyResponsible> GetAsync(KeyResponsible keyResponsible) =>
        await _keyResponsibleCollection.Find(x => x.CPR == keyResponsible.CPR).FirstOrDefaultAsync();

    public async Task<List<Bookingoverview>> GetAsync() =>
        await _bookingOverviewCollection.Find(x => x.Room.RoomId != null).ToListAsync();
}