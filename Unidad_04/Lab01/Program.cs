using System;
using System.IO;
using System.Xml;

namespace Lab01
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Select an option\n1) Read agenda.txt\n2) Write agenda.txt\n3) Write and read agenda.xml\n\nOption: ");
            string option = Console.ReadLine();
            

            switch (option)
            {
                case "1":
                    read();
                    Console.ReadKey();
                    break;

                case "2":
                    write();
                    break;

                case "3":
                    Console.WriteLine("Press any key to generate agendaxml.xml file");
                    Console.ReadKey();
                    writeXML();
                    Console.WriteLine("The agendaxml.xml file has been created successfully\n\nPress any key to see its content");
                    Console.ReadKey();
                    Console.WriteLine();
                    readXML();
                    Console.ReadKey();
                    break;

                default:
                    break;
                    

            }

        }

        private static void read()
        {
            StreamReader reader = File.OpenText("agenda.txt");
            string line;
            Console.WriteLine("Nombre\tApellido\temail\t\t\tTelefono");

            do
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    string[] values = line.Split(';');
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", values[0], values[1], values[2], values[3]);
                }
            }
            while (line != null);

            reader.Close();
            Console.ReadKey();
        }


        private static void write()
        {
            StreamWriter writer = File.AppendText("agenda.txt");
            Console.WriteLine("Add a new contacts");
            string option = "s";

            while(option == "s")
            {
                Console.WriteLine("Input name");
                string name = Console.ReadLine();
                Console.WriteLine("Input surname");
                string surname = Console.ReadLine();
                Console.WriteLine("Input email");
                string email = Console.ReadLine();
                Console.WriteLine("Input phone number");
                string phoneNumber = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();

                writer.WriteLine(name + ";" + surname + ";" + email + ";" + phoneNumber);

                Console.Write("Add another contact?  (s/n)");
                option = Console.ReadLine();

            }

            writer.Close();

        }


        public static void writeXML()
        {
            XmlTextWriter writerXML = new XmlTextWriter("agenda.xml", null);
            writerXML.Formatting = Formatting.Indented;
            writerXML.WriteStartDocument(true);
            writerXML.WriteStartElement("DocumentElement");
            StreamReader reader = File.OpenText("agenda.txt");
            string line;

            do
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    string[] values = line.Split(';');
                    writerXML.WriteStartElement("Contacts");

                    writerXML.WriteStartElement("name");
                    writerXML.WriteValue(values[0]);
                    writerXML.WriteEndElement();

                    writerXML.WriteStartElement("surname");
                    writerXML.WriteValue(values[1]);
                    writerXML.WriteEndElement();

                    writerXML.WriteStartElement("email");
                    writerXML.WriteValue(values[2]);
                    writerXML.WriteEndElement();

                    writerXML.WriteStartElement("phone-number");
                    writerXML.WriteValue(values[3]);
                    writerXML.WriteEndElement();
                }
            } while (line != null);

            writerXML.WriteEndElement();
            writerXML.WriteEndDocument();
            writerXML.Close();

            reader.Close();
        }


        public static void readXML()
        {
            XmlTextReader readerXML = new XmlTextReader("agenda.xml");
            string tagAnterior = "";

            while (readerXML.Read())
            {
                if (readerXML.NodeType == XmlNodeType.Element)
                {
                    tagAnterior = readerXML.Name;
                }
                else if (readerXML.NodeType == XmlNodeType.Text)
                {
                    Console.WriteLine(tagAnterior + ": " + readerXML.Value);
                }
            }
        }

    }
}
