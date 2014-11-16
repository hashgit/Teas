using System;

namespace TeaStall.Services.Models
{
    public class CustomerDto
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }
    }
}