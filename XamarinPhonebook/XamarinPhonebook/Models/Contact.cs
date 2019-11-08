namespace XamarinPhonebook.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => LastName + " " + FirstName;
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PhotoThumbnailUrl { get; set; }
        public string PhotoMediumUrl { get; set; }
        public string PhotoLargeUrl { get; set; }
    }
}