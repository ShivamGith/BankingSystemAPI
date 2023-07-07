using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace CalculateEMI.Controllers.Models
{
    //A model class
    public class Loan
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public double Principal { get; set; }
        public float rate { get; set; }
        public int installments { get; set; }
        public double EMI { get; set; }
    }
}