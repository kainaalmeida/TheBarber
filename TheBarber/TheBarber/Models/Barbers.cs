namespace TheBarber.Models
{
    public class Barbers
    {
        public Barbers(string name, string location, string img, int id)
        {
            Name = name;
            Location = location;
            Img = img;
            Id = id;
        }

        public string Name { get; private set; }
        public string Location { get; private set; }
        public string Img { get; private set; }
        public int Id { get; private set; }
        public string Note => "4/5";
    }
}
