namespace AzureLab.JsonTest
{
    public class Ask
    {
        public decimal Price {get;set;}
        public int Size {get;set;}

        public override string ToString()
        {
            return Price.ToString() + " x " + Size.ToString();
        }
    }
}