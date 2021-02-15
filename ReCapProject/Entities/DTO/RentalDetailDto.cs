using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class RentalDetailDto
    {
        public int RentId { get; set; }
        public string CarName { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CompanyName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
