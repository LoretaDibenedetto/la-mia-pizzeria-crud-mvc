using System.ComponentModel.DataAnnotations;

namespace LaMiaPizzeria.Models
{
    public class Review
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }



    public Review( string name, string description)
    {
        Name = name;    
        Description = description;
    }

     public Review() { }


    }


}
