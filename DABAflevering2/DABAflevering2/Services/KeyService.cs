using DABAflevering2;
using DABAflevering2.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DABAflevering2.Services;

public class KeyService
{
    private readonly IMongoCollection<Bookingoverview> _bookingOverviewCollection;
    private readonly IMongoCollection<Society> _societyCollection;
    private readonly IMongoCollection<Municipality> _municipalityCollection;


    public KeyService(
        MunicipalityDatabaseSettings municipalityDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            municipalityDatabaseSettings.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            municipalityDatabaseSettings.DatabaseName);

        _bookingOverviewCollection = mongoDatabase.GetCollection<Bookingoverview>(
            municipalityDatabaseSettings.BookingOverviewCollectionName);

        _societyCollection = mongoDatabase.GetCollection<Society>(
           municipalityDatabaseSettings.SocietyCollectionName);
    }

    public async Task<Society> GetAsync(string CPR) =>
    await _societyCollection.Find(x => x.keyResponsible.CPR == CPR).FirstOrDefaultAsync();

    public async Task<List<Bookingoverview>> GetAsync(Society society) =>
        await _bookingOverviewCollection.Find(x => x.SocietyCvr == society.Cvr).ToListAsync();
}