using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OO_Kurs_1
{


    //En grundläggande klass
    public class Car
    {

        //Test
        private string registrationNumber { get; set; }
        private DateTime registrationDate { get; set; }

        private bool isActiveInTraffic { get; set; }

        public Car(string registrationNumber, DateTime registrationDate, bool isActiveInTraffic)
        {
            this.registrationNumber = registrationNumber;
            this.registrationDate = registrationDate;
            this.isActiveInTraffic = isActiveInTraffic;
        }

        public string GetCarInformation()
        {
            return "RegNr: " + registrationNumber + " Register Date: " + registrationDate.ToString() + " IsActive in traffic: " + isActiveInTraffic;
        }
    }





    public abstract class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual void Eat()
        {
            Console.WriteLine("Jag äter allt som djur äter!");
        }

        public void Sleep()
        {
            Console.WriteLine("zzzZZ  zzzz");
        }
    }

    public class Dog : Animal
    {
        public override void Eat()
        {
            Console.WriteLine("Jag äter bara det hundar äter");
        }
    }

    public class Cat : Animal
    {

    }

    class ObjectOrientedExamples
    {
        static void Main(string[] args)
        {

            Car mazdaCX5 = new Car("AZZ939", DateTime.Parse("2010-10-02"), true);

            Console.WriteLine(mazdaCX5.GetCarInformation());


            var lassie = new Dog();
            var kissekatten = new Cat();
            lassie.Eat();
            kissekatten.Eat();

            Console.ReadKey();
        }
    }
}
