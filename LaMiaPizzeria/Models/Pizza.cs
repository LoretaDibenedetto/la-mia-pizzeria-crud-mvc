using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LaMiaPizzeria.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Image { get; set; }


        [MaxLength(100)]
        public string Name { get; set; }


        [MaxLength(400)]
        public string Description { get; set; }
        public float Price { get; set; }

        public Pizza(string image, string name, string description, float price)
        {
           Image = image;
            Name = name;
            Description = description;
            Price = price;

        }




    }
}
