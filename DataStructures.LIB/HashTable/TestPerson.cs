using System;
namespace DataStructures.LIB.HashTable
{
    public class TestPerson
    {
        public string Name { get; private set; }
        public int Age { get; set; }
        public int Gender { get; set; }

        public TestPerson(string name, int age, int gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public override string ToString()
        {
            return $"{Name}({Age})";
        }

        public override int GetHashCode()
        {
            return Convert.ToInt32(Name[0]);
        }
    }
}
