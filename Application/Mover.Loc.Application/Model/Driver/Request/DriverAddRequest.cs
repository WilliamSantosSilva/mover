namespace Mover.Loc.Application.Model.Driver.Request
{
    public class DriverAddRequest
    {
        public string Name { get; set; }
        public string Cnpj { get; set; }
        public DateTime DtBirth { get; set; }
        public long NumberCnh { get; set; }
        public string CnhType { get; set; }
        public byte[] CnhPhoto { get; set; }
    }
}