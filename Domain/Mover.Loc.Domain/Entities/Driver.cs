using IET.Common.ValueObjects.MongoDb;

namespace Mover.Loc.Domain.Entities
{
    public class Driver : Entity
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime DtBirth { get; set; }
        public long NumberCnh { get; set; }
        public string CnhType { get; set; }
        public string CnhImage { get; set; }
        public Rental Rental { get; set; }
        
        [MongoDB.Bson.Serialization.Attributes.BsonIgnore]
        public byte[] CnhImageByte { get; set; }
    }
}