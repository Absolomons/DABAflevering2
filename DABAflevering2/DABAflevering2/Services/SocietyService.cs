using DABAflevering2;
using DABAflevering2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DABAflevering2.Services;

public class SocietyService
{
    private readonly IMongoCollection<Society> _societyCollection;

    public SocietyService(
        IOptions<MunicipalityDatabaseSettings> municipalityDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            municipalityDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            municipalityDatabaseSettings.Value.DatabaseName);

        _societyCollection = mongoDatabase.GetCollection<Society>(
            municipalityDatabaseSettings.Value.MunicipalityCollectionName);
    }

    public async Task<Society> GetAsync(string activity) =>
        await _societyCollection.Find(x => x.Activity == activity).FirstOrDefaultAsync();
}