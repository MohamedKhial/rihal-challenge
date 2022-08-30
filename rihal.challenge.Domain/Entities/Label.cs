namespace rihal.challenge.Domain.Entities
{
    public class Label
    {
        public int Id { get; set; }
        public int cat_pos { get; set; }
        public string cat_label_color { get; set; }
        public string cat_txt { get; set; }
        public string cat_color { get; set; }
        public ExtensionAttribute ExtensionAttribute { get; set; }
    }

}
