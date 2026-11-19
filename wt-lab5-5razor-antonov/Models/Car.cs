using System.ComponentModel.DataAnnotations;

namespace wt_lab5_5razor_antonov.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        public string Brand { get; set; } = "";

        public string Model { get; set; } = "";

        public int Year { get; set; }

        public decimal PricePerDay { get; set; }

        public bool IsAvailable { get; set; }

        // НОВОЕ ПОЛЕ ДЛЯ ЛР8
        public string Description { get; set; } = "";
    }
}