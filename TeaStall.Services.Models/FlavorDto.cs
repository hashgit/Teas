using System.Data.Common;

namespace TeaStall.Services.Models
{
    public class FlavorDto
    {
        public string Id { get; set; }
        public string Flavor { get; set; }
        public double Price { get; set; }
    }
}