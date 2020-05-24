using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOP_Lab_6._1
{
    interface IBank
    {
        void MaxInput(int n, Bank[] b);
        

        
    }
    public class Bank : IBank 
    {
        public DateTime data;
        public string name;
        public string LastName;
        public string number;
        public float input;
        public float output;
        public float GetCash;
        public float OutCash;
        public float Cash;
        public Bank(DateTime data, string name, string LastName, string number, float input, float output, float GetCash, float OutCash, float Cash)
        {
            this.data = data;
            this.name = name;
            this.LastName = LastName;
            this.number = number;
            this.input = input;
            this.output = output;
            this.GetCash = GetCash;
            this.OutCash = OutCash;
            this.Cash = Cash;
        }
        public void MaxInput(int n, Bank[] b)
        {
            float max1 = 0;
            float max2 = 0;
            float max3 = 0;
            int[] m = new int[3];
            Bank[] bk = new Bank[3];

            for (int i = 0; i < n; i++)
            {
                if (b[i].input >= max1)
                {
                    m[0] = i + 1;
                    max1 = b[i].input;
                    bk[0] = b[i];

                }
            }
            for (int i = 0; i < n; i++)
            {
                if (b[i].input >= max2 && b[i].input != max1)
                {
                    m[1] = i + 1;
                    max2 = b[i].input;
                    bk[1] = b[i];

                }
            }
            for (int i = 0; i < n; i++)
            {
                if (b[i].input >= max3 && b[i].input != max1 && b[i].input != max2)
                {
                    m[2] = i + 1;
                    max3 = b[i].input;
                    bk[2] = b[i];

                }
            }
            Console.WriteLine("\n*************************************\nКлієнт який має найбільшу суму безготівкового отримання коштів на рахунок.");
            Console.WriteLine("{0,-5} {1, -30} {2, -10} {3, -20} {4, -15} {5,-30} {6,-40}{7,-20}{8,-20}{9,-20}", "№", "Дата", "Ім'я", "прізвище", "№ рахунку", "сума безготівкового отримання", "сума безготівкового переведення", "отримано готівкою", "видано готівкою", "залишок вкладу");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0,-5} {1, -30} {2, -10} {3, -20} {4, -15} {5,-40} {6,-30}{7,-30}{8,-10}{9,-15}", m[i], bk[i].data, bk[i].name, bk[i].LastName, bk[i].number, bk[i].input, bk[i].output, bk[i].GetCash, bk[i].OutCash, bk[i].Cash);
            }
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Введіть кількість клієнтів: ");
            int n = int.Parse(Console.ReadLine());
            Bank[] b = new Bank[n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Клієнт №" + (i + 1));
                Console.Write("дата проведення операції: ");
                DateTime data = new DateTime(2020, 12, 12);
                Console.WriteLine(data.ToString());
                Console.Write("Iм’я: ");
                string name = Console.ReadLine();
                Console.Write("прізвище: ");
                string LastName = Console.ReadLine();
                Console.Write("№ рахунку: ");
                string number = Console.ReadLine();
                Console.Write("сума безготівкового отримання: ");
                float input = float.Parse(Console.ReadLine());
                Console.Write("сума безготівкового переведення: ");
                float output = float.Parse(Console.ReadLine());
                Console.Write("отримано готівкою: ");
                float GetCash = float.Parse(Console.ReadLine());
                Console.Write("видано готівкою: ");
                float OutCash = float.Parse(Console.ReadLine());
                Console.Write("залишок вкладу: ");
                float Cash = float.Parse(Console.ReadLine());

                b[i] = new Bank(data, name, LastName, number, input, output, GetCash, OutCash, Cash);

            }

            b[0].MaxInput(n, b);
         

        }
    }
}
