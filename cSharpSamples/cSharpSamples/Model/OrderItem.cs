using System;

namespace cSharpSamples.Model
{
    public enum Publication
    {
        Microsoft, Apress, Wrox
    }

    public class OrderItem
    {
        public Guid ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public Publication Publication { get; set; }
    }
}