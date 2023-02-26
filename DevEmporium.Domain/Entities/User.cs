using Chevalier.Utility.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEmporium.Domain.Entities
{
    public class User
    {
        public int Id { get; }
        public string Username { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public HashedPassword Password { get; }

        public List<Product> orders;

        public User(int id, string username, string name, string email, string address, HashedPassword password, List<Product> orders)
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
            Address = address;
            Password = password;
            this.orders = orders;
        }

        public User(int id, string username, string name, string email, string address, HashedPassword password)
        {
            Id = id;
            Name = name;
            Username = username;
            Email = email;
            Address = address;
            Password = password;
        }
        public User(int id, User user) : this(id, user.Username, user.Name, user.Email, user.Address, user.Password)
        { }

        public override string ToString()
        {
            return $"Username : {Username} " +
                   $"Name : {Name} " +
                   $"Email : {Email} " +
                   $"Address : {Address} ";
        }
    }
}
