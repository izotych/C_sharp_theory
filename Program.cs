﻿using System;
using System.Collections.Generic;


namespace Boxing_and_unboxing
//Упаковка и распаковка объектов
//Упаковка представляет собой процесс преобразования типа значения в тип object
//или в любой другой тип интерфейса,реализуемый этим типом значения.
//Когда тип значения упаковывается общеязыковой средой выполнения (CLR),
//он инкапсулирует значение внутри экземпляра System.Object и сохраняет его в управляемой куче.
//Операция распаковки извлекает тип значения из объекта. Упаковка является неявной; распаковка является явной.
//Подобные преобразования возможны потому, что значение любого типа является наследником класса object.

//Код выполнять отдельными блоками

{

    class Program
    {
        static void Main(string[] args)
        {
            //Операция упаковки. операция упаковки i целочисленной переменной, которая присвоена объекту o.
            //Упаковка представляет собой неявное преобразование типа значения в тип object или
            //в любой другой тип интерфейса, реализуемый этим типом значения.
            //При упаковке типа значения в куче выделяется экземпляр объекта и выполняется копирование значения в этот новый объект.
            int i = 123;
            // i упаковывается в объект (boxing)
            object o = i;
            //Результат этого оператора создает ссылку на объект o в стеке, которая ссылается на значение типа int в куче.
            //Это значение является копией значения типа значения, присвоенного переменной i.

            //__________________________________________________________________________________________________________________________________________________

            int i = 123;

            // Boxing copies the value of i into object o. (упаковка копирует значение i в объект o)
            object o = i;

            // Change the value of i. (меняем значение i)
            i = 456;

            // The change in i doesn't affect the value stored in o. (изменение значения i не повлияло на значение, хранящееся в объекте o)

            Console.WriteLine("The value-type value = {0}", i); //The value-type value = 456
            Console.WriteLine("The object-type value = {0}", o); // The object-type value = 123



            //___________________________________________________________________________________________________________________________________________________

            //Операция распаковки объекта o и присвоение его целочисленной переменной i.

            o = 123;
            i = (int)o;  // Распаковка (unboxing)

            //Распаковка является явным преобразованием из типа object в тип значения или из типа интерфейса в тип значения, реализующего этот интерфейс.
            //Операция распаковки состоит из следующих действий:
            //1) проверка экземпляра объекта на то, что он является упакованным значением заданного типа значения;
            //2) копирование значения из экземпляра в переменную типа значения.

            //Для успешной распаковки типов значений во время выполнения необходимо, чтобы экземпляр, который распаковывается,
            //был ссылкой на объект, предварительно созданный с помощью упаковки экземпляра этого типа значения.
            //Попытка распаковать null создает исключение NullReferenceException.
            //Попытка распаковать ссылку на несовместимый тип значения создает исключение InvalidCastException.

            //В следующем примере показан случай недопустимой распаковки, в результате чего создается исключение InvalidCastException.
            //В случае использования try и catch при возникновении ошибки выводится сообщение.

            int i = 123;
            object o = i;  // implicit boxing (неявная упаковка)

            try
            {
                int j = (short)o;  // attempt to unbox (попытка распаковки)

                System.Console.WriteLine("Unboxing OK.");
            }
            catch (System.InvalidCastException e)
            {
                System.Console.WriteLine("{0} Error: Incorrect unboxing.", e.Message);
            }

            //При выполнении этой операции в консоль выведется: Specified cast is not valid. Error: Incorrect unboxing.

            //
            int i = 123;
            object o = i;  

            try
            {
                int j = (int)o;  // чтобы распаковка прошла корректно, необходимо корректно указать тип. (меняем short на int)

                System.Console.WriteLine("Unboxing OK.");
            }
            catch (System.InvalidCastException e)
            {
                System.Console.WriteLine("{0} Error: Incorrect unboxing.", e.Message);
            }

            //В консоль выведет: Unboxing OK.

            //Необходимо помнить что, по сравнению с простыми операциями присваивания операции упаковки и распаковки являются весьма затратными процессами с точки зрения вычислений.
            //При выполнении упаковки типа значения необходимо создать и разместить новый объект.
        }
    }
}