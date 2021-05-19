namespace SModel
{
    public class Bread
    {
        public Bread(){

        }
        public Bread(int id)
        {
            BreadID = id;
        }
        
        public Bread(string type, float price){
            Breadtype = type;
            Price = price;
        }

        public Bread(int id, string type, double price)
        {
            this.BreadID = id;
            this.Breadtype = type;
            this.Price = price;
        }
        public Bread(int id, string type, double price, int stock)
        {
            this.BreadID = id;
            this.Breadtype = type;
            this.Price = price;
            this.Stock = stock;
        }

        /// <summary>
        /// Contains the ID key for Bread types in the database
        /// </summary>
        /// <value></value>
        public int BreadID{ get; set; }

        /// <summary>
        /// Contains a string containing the type of bread i.e Wheat
        /// </summary>
        /// <value></value>
        public string Breadtype{ get; set; }

        /// <summary>
        /// contains the price of this individual bread type
        /// </summary>
        /// <value></value>
        public double Price{ get; set; }

        public int Stock{get; set;}

        /// <summary>
        /// Override of the two string method used to print out bread info
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return $"Bread ID: {BreadID}, Type: {Breadtype}, Price: {Price}, In Stock:{Stock}";
        }
    }
}