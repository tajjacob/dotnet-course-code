namespace HelloWorld.Models // define the namespace for the Computer class
{
    public class Computer
    {
        public string Motherboard { get; set; } = ""; //auto-implemented properties. for non-nullable reference types, you must initialize them
        public int CPUCores { get; set; } // get - Retrieves (reads) the value, set - Assigns (writes) the value
        public bool HasWifi { get; set; }
        public bool HasLTE { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string VideoCard { get; set; } = "";
    }
}