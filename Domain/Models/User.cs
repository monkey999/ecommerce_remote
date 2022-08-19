using System;
using System.Collections.Generic;

#nullable disable

namespace Domain
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
