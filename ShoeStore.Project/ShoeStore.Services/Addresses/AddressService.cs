using ShoeStore.Data;
using ShoeStore.Data.Entities;
using ShoeStore.Services.Addresses.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Services.Addresses
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> addressRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<User> userRepository;

        public AddressService(IRepository<Address> addressRepository, IUnitOfWork unitOfWork,
            IRepository<User> userRepository)
        {
            this.addressRepository = addressRepository;
            this.unitOfWork = unitOfWork;
            this.userRepository = userRepository;
        }
        public AddressDto GetAddress(int id)
        {
            if (id < 1) throw new ArgumentException(nameof(id));

            var address = addressRepository.Get(id);

            if (address == null) return null;
            var addressDto = new AddressDto
            {
                Id = address.Id,
                City = address.City,
                Country = address.Country,
                PostalCode = address.PostalCode
            };
            return addressDto;
        }

        public AddressDto GetAdressByUserID(int id)
        {
            if (id < 0) throw new ArgumentException(nameof(id));
            var address = addressRepository.Get(id);
            var user = userRepository.Get(id);
            if (address == null) return null;
            if (user == null) return null;

            var addresUserDto = new AddressDto
            {
                Id = address.Id,
                UserId = user.Id,
                City = address.City,
                Country = address.Country,
                PostalCode = address.PostalCode

            };
            return addresUserDto;
        }
    }
}
