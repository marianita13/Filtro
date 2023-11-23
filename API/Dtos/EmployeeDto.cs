using System;
namespace Api.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int ManagerCode { get; set; }
        public string Extention { get; set; }
        public int PersonId { get; set; }
        public int OfficeId { get; set; }
        public int PostalCodeId { get; set; }
    }
}