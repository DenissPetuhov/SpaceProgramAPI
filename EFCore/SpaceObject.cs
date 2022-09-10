using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceProgram.EFCore
{
    [Table("spaceObject")]
    public class SpaceObject
    {   [Key,Required]
        public int id { get; set; }
        public int SpaceSystemid { get; set; }
        public int type { get; set; }
        public string name { get; set; } = string.Empty;
        public int age { get; set; }
        public int diameter { get; set; }
        public int mass { get; set; }

    }
}
