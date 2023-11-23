using System;

namespace Api.Dtos
{
    public class ClientDto
    {
        public int Id { get; set; }
        public int Phone { get; set; }
        public int Fax { get; set; }
        public string LineAdress {get; set; }
        public string LineAdress2 {get; set; }
        public int CreditLimit { get; set; }
        public int PersonId { get; set; }
        public int EmployeeId { get; set; }
        public int PostalCodeId { get; set; }
    }
}