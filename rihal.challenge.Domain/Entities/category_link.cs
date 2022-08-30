namespace rihal.challenge.Domain.Entities
{
    public class category_link
    {
        public int Id { get; set; }
        public int category_id { get; set; }
        public int product_id { get; set; }
        public int position { get; set; }
    }
}
