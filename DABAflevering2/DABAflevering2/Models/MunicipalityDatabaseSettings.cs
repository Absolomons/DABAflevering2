using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DABAflevering2.Models
{
   
    public class MunicipalityDatabaseSettings
    {
        public string ConnectionString = "mongodb://localhost:27017";

        public string DatabaseName = "Municipality";

        public string MunicipalityCollectionName ="Municipality";

        public string RoomCollectionName = "Rooms";

        public string SocietyCollectionName = "Societies";

        public string BookingOverviewCollectionName = "Bookingoverviews";
    }
}
