using Newtonsoft.Json;
using System.Text.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace AddressBookDay29_2
{
    class Person
    {
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipcode { get; set; }
        public long mobnum { get; set; }
    }
    internal class File15
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            string path = @"C:\Users\Dell\source\repos\AddressBook29\AddressBookDay29_2\Address2.csv";
            Console.Write("How many Contact You Have To Add:");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Person p = new Person();
                //Accepting Details From User
                Console.WriteLine("Enter Details For " + i + " Contact");
                Console.Write("Enter First Name:");
                p.firstname = Console.ReadLine();

                Console.Write("Enter Last Name:");
                p.lastname = Console.ReadLine();

                Console.Write("Enter Address:");
                p.address = Console.ReadLine();

                Console.Write("Enter City:");
                p.city = Console.ReadLine();

                Console.Write("Enter State:");
                p.state = Console.ReadLine();

                Console.Write("Enter ZipCode:");
                p.zipcode = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Mobile Number:");
                p.mobnum = Convert.ToInt64(Console.ReadLine());

                //Adding Details to list
                list.Add(p);
                Console.WriteLine("Contact Added");
                Console.WriteLine("\n");
            }
            //writing list data in file given using third party library
            JsonSerializer js = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                js.Serialize(jw, list);
            }
            Console.WriteLine("---------------------------------Data Inside File Is---------------------------------");
            //displaying data in file using third party library
            JsonSerializer js1 = new JsonSerializer();
            using (StreamReader sr = new StreamReader(path))
            using (JsonReader jr = new JsonTextReader(sr))
            {
                js1.Deserialize(jr);
            }
        }
    }
}
