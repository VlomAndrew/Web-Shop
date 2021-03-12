using System.ComponentModel.DataAnnotations;

namespace Web_Shop.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Display(Name = "Название товара")]
        public string Name { get; set; }
        [Display(Name = "Цена товара")]
        public double Price { get; set; }
        [Display(Name = "Количество на складе")]
        public uint Count { get; set; }
        [Display(Name = "Описание товара")]
        public string Description { get; set; }
        [Display(Name = "Путь к изображению")]
        public string ImagePath { get; set; }
    }
}