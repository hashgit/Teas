using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeaStall.Database.Models
{
    public class TeaBase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }
        public string BaseTea { get; set; }
        public double Price { get; set; }
    }
}