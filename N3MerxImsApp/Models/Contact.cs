namespace N3MerxImsApp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int ContactTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime DateUpdated { get; set; }
        public bool IsActive { get; set; }
    }
}
