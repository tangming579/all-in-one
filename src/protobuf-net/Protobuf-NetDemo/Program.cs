using ProtoBuf;
using System;
using System.IO;

namespace Protobuf_NetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Methond1();
            Methond2();

            Console.WriteLine("Hello World!");
        }

        public static void Methond1()
        {
            var person = new Person
            {
                Id = 12345,
                Name = "Fred",
                Address = new Address
                {
                    Line1 = "Flat 1",
                    Line2 = "The Meadows"
                }
            };
            using (var file = File.Create("person.bin"))
            {
                Serializer.Serialize(file, person);
            }

            Person newPerson;
            using (var file = File.OpenRead("person.bin"))
            {
                newPerson = Serializer.Deserialize<Person>(file);
            }
        }

        public static void Methond2()
        {
            var person = new Person
            {
                Id = 12345,
                Name = "Fred",
                Address = new Address
                {
                    Line1 = "Flat 1",
                    Line2 = "The Meadows"
                }
            };
            var byt = GetByte(person);

            var instance = GetInstance<Person>(byt);
        }

        public static byte[] GetByte<T>(T item) where T : class, new()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                Serializer.Serialize(ms, item);
                byte[] actual = ms.ToArray();
                return actual;
            }
        }
        public static T GetInstance<T>(byte[] item) where T : class, new()
        {
            using (MemoryStream ms = new MemoryStream(item))
            {
                var instance = Serializer.Deserialize<T>(ms);
                return instance;
            }
        }
    }

    [ProtoContract]
    class Person
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        [ProtoMember(3)]
        public Address Address { get; set; }
    }
    [ProtoContract]
    class Address
    {
        [ProtoMember(1)]
        public string Line1 { get; set; }
        [ProtoMember(2)]
        public string Line2 { get; set; }
    }
}
