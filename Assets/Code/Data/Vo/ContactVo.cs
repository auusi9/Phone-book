using System;
using Code.Data.Dto;

namespace Code.Data.Vo
{
    [Serializable]
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

        public ContactVo(int id, ContactVo contactVo)
        {
            Id = id;
            Name = contactVo.Name;
            LastName = contactVo.LastName;
            Description = contactVo.Description;
            PhoneNumber = contactVo.PhoneNumber;
            Email = contactVo.Email;
            TwitterHandle = contactVo.TwitterHandle;
            DateAdded = DateTime.Now;
        }
        
        public ContactVo()
        {
            Id = -1;
            Name = LastName = Description = PhoneNumber = Email = TwitterHandle = string.Empty;
        }

        public ContactMissingRequiredDetailsDto GetMissingDetails()
        {
            bool name = false;
            bool lastName = false;
            bool phone = false;
            
            if (string.IsNullOrWhiteSpace(Name))
            {
                name = true;
            }
            
            if (string.IsNullOrWhiteSpace(LastName))
            {
                lastName = true;
            }  
            
            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                phone = true;
            }
            
            return new ContactMissingRequiredDetailsDto(name, lastName, false, phone, false, false);
        }

        public bool IsValid()
        {
            return !GetMissingDetails().IsAnythingMissing();
        }

        public static ContactVo Empty()
        {
            return new ContactVo();
        }
    }

    public class ContactMissingRequiredDetailsDto
    {
        public bool Name { get; }
        public bool LastName { get; }
        public bool Description { get; }
        public bool PhoneNumber { get; }
        public bool Email { get; }
        public bool TwitterHandle { get; }

        public ContactMissingRequiredDetailsDto(bool name, bool lastName, bool description, bool phoneNumber, bool email, bool twitterHandle)
        {
            Name = name;
            LastName = lastName;
            Description = description;
            PhoneNumber = phoneNumber;
            Email = email;
            TwitterHandle = twitterHandle;
        }

        public bool IsAnythingMissing()
        {
            return Name || LastName || Description || PhoneNumber || Email || TwitterHandle;
        }
    }
}