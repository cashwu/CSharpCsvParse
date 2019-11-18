namespace testCsv
{
    public class Automobile
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public AutomobileType Type { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public AutomobileComment Comment { get; set; }

        public override string ToString()
        {
            return $"{nameof(Make)}: {Make}, {nameof(Model)}: {Model}, {nameof(Type)}: {Type}, {nameof(Year)}: {Year}, {nameof(Price)}: {Price}, {nameof(Comment)}: {Comment.Comment}";
        }
    }

    public class AutomobileComment
    {
        public string Comment { get; set; }
    }

    public enum AutomobileType
    {
        None,
        Car,
        Truck,
        Motorbike
    }
}