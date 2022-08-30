using System.Collections.Generic;

namespace rihal.challenge.Application.Models.DTOs.Category
{
    public class AddCategoryDTO
    {
        public int id { get; set; }
        public int parent_id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public string category_icon { get; set; }
        public string category_color { get; set; }
        public string rectangle_background_image { get; set; }
        public string square_background_image { get; set; }
        public string category_name_text_color { get; set; }
        public string additional_text_color { get; set; }
        public bool is_active { get; set; }
        public int position { get; set; }
        public int product_count { get; set; }
        public string include_in_menu { get; set; }
        public List<AddCategoryDTO> children_data { get; set; }

    }
}
