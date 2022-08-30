namespace rihal.challenge.Domain.Entities
{
    public class EnglishProduct
    {
        public int ProductId { get; set; }
        public int id { get; set; }
        public int defaultCategoryId { get; set; }
        public int parentCategoryId { get; set; }
        public int childCategoryId { get; set; }
        public string sku { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int status { get; set; }
        public int visibility { get; set; }
        public string type_id { get; set; }
        public int weight { get; set; }

        public ExtensionAttribute extension_attributes { get; set; }
    }
}
