using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Services.Addresses.Dto
{
   public  class AddressDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
