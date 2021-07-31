using System;

namespace Exercise04
{
    [System.Xml.Serialization.XmlInclude(typeof(Circle))]
    [System.Xml.Serialization.XmlInclude(typeof(Rectangle))]
    [System.Xml.Serialization.XmlRoot(ElementName = "Shape")]
    public class Shape
    {
        public string Colour { get; set; }
        public virtual double Area { get; }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
        public override double Area { get { return Math.Pow(this.Radius, 2) * Math.PI; } }
    }

    public class Rectangle : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public override double Area { get { return this.Width * this.Height; } }
    }
}