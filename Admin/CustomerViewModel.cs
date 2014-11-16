using System;

namespace Admin
{
    public class CustomerViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DoB { get; set; }

        public void Reset()
        {
            Id = FirstName = LastName = string.Empty;
            DoB = DateTime.Now;
        }
    }
}