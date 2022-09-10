using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceProgram.EFCore
{
    [Table("spaceSystem")]
    public class SpaceSystem
    {
        [Key, Required]
        public int id { get; set; }
        
        public string name { get; set; } = string.Empty;
        public int age { get; set; }
    }
}
