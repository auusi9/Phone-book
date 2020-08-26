namespace Code.Data.Dto
{
    public class ContactDto
    {
        public int Id { get; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TwitterHandle { get; set; }

        public ContactDto(int id, string name, string lastName, string description, string phoneNumber, string email, string twitterHandle)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Description = description;
            PhoneNumber = phoneNumber;
            Email = email;
            TwitterHandle = twitterHandle;
        }
    }
}