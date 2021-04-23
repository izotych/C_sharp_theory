using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modifiers_as_is
{
    //Модификаторы as is typeof
    /*
        оператор is – проверяет, совпадает ли тип выражения с заданным типом данных;
        оператор as – предназначен для избежания возникновения исключительной ситуации в случае неудачного приведения типов;
        оператор typeof – используется для получения информации о заданном типе (классе);
        общая форма оператора is имеет следующий вид:

        выражение is тип

        где выражение есть обозначением некоторого выражения, описывающего объект;
        тип – некоторый тип, с которым сравнивается тип выражения.
        Если выражение и тип имеют одинаковый тип данных, то результат операции будет true.
        В противном случае, результат операции is будет false.
        Чаще всего оператор is используется в условии оператора if.
        В этом случае, общая форма оператора if с оператором is имеет следующий вид:
        if (выражение is тип)
        {
            // операции, которые нужно выполнить, если типы совпадают
        }
        else
        {
            // операции, которые нужно выполнить, если типы не совпадают
        }     
     */
}
namespace Using_IS_examples
{
    class Program
    {
        public static void Method(Person p)
        {
            if (p is Client)
            {
                Console.WriteLine("Действия с клиентом");
            }
            else if (p is Employee)
            {
                Console.WriteLine("Действия с сотрудником");
            }
            else if (p is Person)
            {
                Console.WriteLine("Действия с Person");
            }
            else
            {
                Console.WriteLine("Это не Person");
            }
        }
        static void Main(string[] args)
        {

            /*
             * С помощью оператора is определяется принадлежность объекта класса заданному типу и совместимость объекта класса с заданным типом.
             */
            Console.WriteLine("Примеры использования оператора is");
            Person person1 = new Person();
            Client client1 = new Client();
            Employee employee1 = new Employee("Bank");
            Person client2 = new Client();
            Person employee2 = new Employee("Bank");
            Method(client2); // Проверит является ли объект класса Person ещё и объектом класса Client
            Method(employee2); // Проверит является ли объект класса Person ещё и объектом класса Empluyee
            Method(person1); // Проверка на класс Person

            //С помощью оператора is мы можем уточнять, что именно нам поступило в метод. Все объекты класса Client и Employee являются также объектами класса Person.
            //Так мы можем проверить, а каким именно из класса Person является поступивший в метод объект.
            //Соответственно можно прописать разную логику для объектов типа Client и объектов типа Employee.



            //Оператор as. С его помощью программа пытается преобразовать выражение к определенному типу, при этом не выбрасывает исключение.
            //В случае неудачного преобразования выражение будет содержать значение null.
            Console.WriteLine("Примеры использования оператора as");
            Employee emp = person1 as Employee; //Преобразование не пройдёт, в emp запишется значение Null
            if (emp == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                Console.WriteLine(emp.Company);
            }
            Employee emp2 = employee2 as Employee; //Преобразование пройдёт успешно, выведется название компании (Company)
            if (emp == null)
            {
                Console.WriteLine("Преобразование прошло неудачно");
            }
            else
            {
                Console.WriteLine(emp.Company);
            }



            //Оператор typeof получает экземпляр System.Type для указанного типа.
            //Оператор typeof принимает в качестве аргумента имя типа или параметр типа, как показано в следующем примере:
            Console.WriteLine("Примеры использования оператора typeof");
            void PrintType<T>() => Console.WriteLine(typeof(T));

            Console.WriteLine(typeof(List<string>));
            PrintType<int>();
            PrintType<System.Int32>();
            PrintType<Dictionary<int, char>>();
            // Output:
            // System.Collections.Generic.List`1[System.String]
            // System.Int32
            // System.Int32
            // System.Collections.Generic.Dictionary`2[System.Int32,System.Char]
        }
    }

    // базовый класс
    class Person
    { 
    }

    // производный класс от базового класса
    class Client : Person
    {
    }
    class Employee : Person
    { 
        public string Company { get; set; }
        public Employee (string comp)
        {
            Company = comp;
        }

    }

}
