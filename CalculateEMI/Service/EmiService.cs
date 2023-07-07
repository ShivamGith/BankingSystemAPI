
using MongoDB.Driver;

namespace CalculateEMI.Controllers.Models
{
    public class EmiService
    {
        private readonly IMongoCollection<Loan> _loanCollection;

        public EmiService()
        {
            var mongoClient = new MongoClient("mongodb://localhost:27017");

            var mongoDatabase = mongoClient.GetDatabase("BankingSystemLF");

            _loanCollection = mongoDatabase.GetCollection<Loan>("Details");
        }

    }
}