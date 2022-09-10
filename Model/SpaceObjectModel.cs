namespace SpaceProgram.Model
{
    public class SpaceObjectModel
    {
        public int id { get; set; }
        public int spaceSystem_id { get; set; }
        public int type { get; set; }
        public string name { get; set; } = string.Empty;
        public int age { get; set; }
        public int diameter { get; set; }
        public int mass { get; set; }
    }
}
