using DABAflevering2;
using DABAflevering2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DABAflevering2.Services;

public class SocietyService
{
    private readonly IMongoCollection<Society> _societyCollection;

    public SocietyService(
        MunicipalityDatabaseSettings municipalityDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            municipalityDatabaseSettings.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            municipalityDatabaseSettings.DatabaseName);

        _societyCollection = mongoDatabase.GetCollection<Society>(
            municipalityDatabaseSettings.SocietyCollectionName);
    }

    public async Task<List<Society>> GetAsync() =>
        await _societyCollection.Find(x => x.Activity != null).ToListAsync();
}