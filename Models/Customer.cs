using System;

namespace SampleApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int? BirthMonth { get; set; }
        public int? BirthYear { get; set; }

        public static implicit operator int(Customer v)
        {
            throw new NotImplementedException();
        }

        public object GetAllCustomer(object p1, object p2)
        {
            throw new NotImplementedException();
        }

        public object GetCutomer(object p1, object p2)
        {
            throw new NotImplementedException();
        }

        public object Id(object p1, object p2)
        {
            throw new NotImplementedException();
        }

        public object LastName(object p1, object p2)
        {
            throw new NotImplementedException();
        }
    }
}
