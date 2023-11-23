using System;

namespace Api.Dtos
{
    public class OfficeDto
    {
        public int Phone { get; set; }
        public string OfficeCode { get; set; }
        public string AdressLine { get; set; }
        public string AdressLine2 { get; set; }
        public int CityId { get; set; }
        public int Id { get; set; }
    }
}