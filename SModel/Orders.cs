namespace SModel
{
    public class Orders
    {
        public Orders()
        {

        }
        public Orders(Bread name, string detail)
        {
            loaf = name;
            details = detail;
        }

        public Bread loaf{ get; set; } 
        public string details{ get; set; }
    
    }
}