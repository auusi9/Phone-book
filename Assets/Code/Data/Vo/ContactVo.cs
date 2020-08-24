using System;

namespace Code.Data.Vo
{
    public class ContactVo
    {
        public int Id { get; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TwitterHandle { get; set; }
        public DateTime DateAdded { get; set; }

        public ContactVo(int id, string name, string lastName, string description, string phoneNumber, string email, string twitterHandle, DateTime dateAdded)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Description = description;
            PhoneNumber = phoneNumber;
            Email = email;
            TwitterHandle = twitterHandle;
            DateAdded = dateAdded;
        }
    }
}