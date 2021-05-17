namespace SModel
{
    public class Bread
    {
        public Bread(){

        }
        public Bread(string type, double price){
            Breadtype = type;
            Price = price;
        }

        public string Breadtype{ get; set; }
        public bool HasGluten{ get; set; }
        public bool IsSliced{ get; set; }
        public double Price{ get; set; }
        

    }
}