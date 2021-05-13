namespace SModel
{
    public class Bread
    {
        public Bread(){

        }
        public Bread(string type, bool gluten, bool sliced){
            Breadtype = type;
            HasGluten = gluten;
            IsSliced = sliced;
        }

        public string Breadtype{ get; set; }
        public bool HasGluten{ get; set; }
        public bool IsSliced{ get; set; }
    }
}