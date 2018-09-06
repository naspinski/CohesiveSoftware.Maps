namespace CohesiveSoftware.Maps.Models
{
    public class Territory
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }

        public Territory()
        {
            Name = string.Empty;
            Abbreviation = string.Empty;
        }

        public Territory(string name, string abbreviation)
        {
            Name = name;
            Abbreviation = abbreviation;
        }
    }
}
