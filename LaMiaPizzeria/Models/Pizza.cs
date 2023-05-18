using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LaMiaPizzeria.Models
{
    public class Pizza
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Il campo URL dell'immagine è obbligatorio")]
        [Url(ErrorMessage = "L'URL inserito non è un url valido!")]
        [StringLength(300, ErrorMessage = "Il campo URL immagine può contenere al massimo 300 caratteri")]
        public string Image { get; set; }


        [Required(ErrorMessage = "Il campo nome è obbligatorio!")]
        [StringLength(100, ErrorMessage = "Il campo nome può essere lungo al massimo 100 caratteri")]
        public string Name { get; set; }

        
   
        [Required(ErrorMessage = "Il campo description è obbligatorio!")]
        [StringLength(500, ErrorMessage = "Il campo description può essere lungo al massimo 500 caratteri")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Il campo prezzo è obbligatorio!")]
        [Range(10.00, 999.99)]
        public float Price { get; set; }

        public Pizza(string image, string name, string description, float price)
        {
           Image = image;
            Name = name;
            Description = description;
            Price = price;

        }

        public Pizza() { }




    }
}
