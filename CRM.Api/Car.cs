namespace CRM.Api
{
    public class Car
    {
        public Car()
        {
            SilindiKapi = new List<int>();
        }
        public int ID { get; set; }
        public string Name { get; set; }

        public List<int> SilindiKapi { get; set; }
    }
}
