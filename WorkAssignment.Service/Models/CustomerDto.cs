using System;

namespace WorkAssignment.Service.Models
{
    public class CustomerDto
    {
        public string ContactNumber { get; set; }
        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Language { get; set; }
        public bool LoyaltyProgram { get; set; }
        public string DiscountType { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
