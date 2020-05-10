using ShoeStore.Services.Addresses.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Services.Addresses
{
    public interface IAddressService
    {
        AddressDto GetAddress(int id);
        AddressDto GetAdressByUserID(int id);
    }
}
