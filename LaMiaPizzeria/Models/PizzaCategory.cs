using MessagePack;



namespace LaMiaPizzeria.Models
{
    public class PizzaCategory
    {
        
        public int Id { get; set; } 
        public string Title { get; set; }

        public List<Pizza> PizzaList{ get; set; }


        public PizzaCategory() { }


        public PizzaCategory( string title) 
        {
           Title = title;
           PizzaList = new List<Pizza>(); 
        
        
        
        }
    }
}
