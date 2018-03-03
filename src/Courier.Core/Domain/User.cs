using System;
using System.Collections.Generic;
using System.Text;

namespace Courier.Core.Domain
{
    public class User
    {
        // id, imie, nazwisko, email, haslo, address i rola
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public Address Address { get; set; }
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public User(string email, string firstName, string lastName, Role role = Role.User)
        {
            Id = Guid.NewGuid();
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Role = role;
            CreatedAt = DateTime.UtcNow;
        }
    }
     
}
