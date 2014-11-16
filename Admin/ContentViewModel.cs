namespace Admin
{
    public class ContentViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}