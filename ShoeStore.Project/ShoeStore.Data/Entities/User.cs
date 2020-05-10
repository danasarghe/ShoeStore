using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeStore.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Address> Addresses { get; set; }
        public Role Role { get; set; }
    }
}
