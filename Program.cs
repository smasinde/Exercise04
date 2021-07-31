using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Exercise04
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfShapes = new List<Shape>
            {
                new Circle { Colour = "Red", Radius = 2.5},
                new Rectangle {Colour = "Blue", Height = 20.0, Width = 10.0},
                new Circle { Colour = "Green", Radius = 8.0},
                new Circle { Colour = "Purple", Radius = 12.3},
                new Rectangle {Colour = "Blue", Height = 45.0, Width = 18.0},
            };

            Console.WriteLine("Writing XML file in the current directory...");

            XmlSerializer serializerXml =
                new XmlSerializer(typeof(List<Shape>));

            var path = Environment.CurrentDirectory + "-shapes.xml";
            FileStream file = File.Create(path);

            serializerXml.Serialize(file, listOfShapes);
            file.Close();

            Console.WriteLine("Creating XML finished...🚀\n");

            StreamReader reader = new StreamReader(path);
            List<Shape> loadedShapesXml = serializerXml.Deserialize(reader) as List<Shape>;
            reader.Close();

            foreach (Shape item in loadedShapesXml)
            {
                Console.WriteLine("{0} is {1} and has an area of {2:N2}", item.GetType().Name, item.Colour, item.Area);
            }
        }
    }
}