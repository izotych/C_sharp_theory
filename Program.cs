using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Numerics;
using System.Text.RegularExpressions;

namespace Kata_sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10] { 2, 6, -3, 11, 11, 0, 50, -4, 7, 5};
            
            Sort(array);
            Read(array);
        }

        public static void Sort(int[] mass)
        {
             //Перменная для обменов
             //Индекс максимального элемента в массиве
            for(int i = 0, indexMax = 0; i < mass.Length; i++) //Начинаем обходки массива
            {
                for(int j = 0, temp; j < mass.Length - i; j++)//Обход элементов в массиве
                {
                    if(mass[j] > mass[indexMax])//Находим индекс максимального значения в массиве, и записываем
                    {
                        indexMax = j;
                    }

                    if(j == mass.Length - 1 - i)//Помещаем максимальный элемент массива в конец
                    {
                        temp = mass[j];
                        mass[j] = mass[indexMax];
                        mass[indexMax] = temp;
                    }
                }
                indexMax = 0;
            }
        }
        public static void Read(int[] mass)
        {
            foreach(int elem in mass)
            {
                Console.WriteLine(elem);
            }
        }










    }
}