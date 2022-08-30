﻿using System.Collections.Generic;

namespace rihal.challenge.Application.Models.DTOs.Category
{
    public class DisplayCategoryDTO
    {
        public int Id { get; set; }
        public int? parent_id { get; set; }
        public DisplayCategoryDTO Parent { get; set; }
        public List<DisplayCategoryDTO> children_data { get; set; }
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
    }
}
