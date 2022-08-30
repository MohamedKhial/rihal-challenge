using System.Collections.Generic;

namespace rihal.challenge.Domain.Entities
{
    public class ExtensionAttribute
    {
        public ICollection<Label> labels { get; set; }
        public ICollection<category_link> category_links { get; set; }
        public int Id { get; set; }
        public string url_base { get; set; }
        public bool in_stock { get; set; }
        public bool is_prescription { get; set; }
        public string thumbnail { get; set; }
        public string loyalty_points { get; set; }
        public string offer_text { get; set; }
        public double price_after { get; set; }
        public double price_before { get; set; }
        public int hide_price { get; set; }
        public int min_amount_inc { get; set; }
        public string min_amount_text { get; set; }
        public string perfect_corp_try_out { get; set; }
        public string makeup_effect { get; set; }

        //public int EnglishProductId { get; set; }
        //public EnglishProduct EnglishProduct { get; set; }

        //public int ArabicProductId { get; set; }
        //public ArabicProduct ArabicProduct { get; set; }

    }

}
