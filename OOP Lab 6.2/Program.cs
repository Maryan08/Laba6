using System;
using System.IO;



namespace OOP_Lab_6._2
{
    interface ISite
    {
        void Number();
        void Maxday();
        void Ser();
    }
    abstract class Site : ISite
    {
        public string name;
        public string URL;
        abstract public void Number();
        abstract public void Maxday();
        abstract public void Ser();
    }
    class Visiting : Site
    {
        public DateTime date;
        public int host;
        public int download;
        public  Visiting(string name, string URL, DateTime date, int host, int download)
        {
            this.name = name;
            this.URL = URL;
            this.date = date;
            this.host = host;
            this.download = download;
        }
        public override void Number()
        {
            Console.WriteLine("Введіть значення співвідношення хостів до сторінок: ");
            float spv = float.Parse(Console.ReadLine());
            int n = 0;
            for (int i = 0; i < Program.visit.Length; ++i)
            {
                if (Program.visit[i] != null)
                {
                    if ((Program.visit[i].host / Program.visit[i].download) >= spv)
                    {
                        n++;
                        Console.WriteLine("{0,-30} {1, -30} {2, -30} {3, -15} {4, -15}", Program.visit[i].name, Program.visit[i].URL, Program.visit[i].date, Program.visit[i].host, Program.visit[i].download);
                    }
                }

            }
            Console.WriteLine("Кількість днів, коли співвідношення хостів до сторінок перевищує задане значення: {0}", n);

        }
        public override void Maxday()
        {
            int max1 = -1;
            int max2 = -1;
            int max3 = -1;
            int day1 = 0;
            int day2 = 0;
            int day3 = 0;
            for (int i = 0; i < Program.visit.Length; ++i)

            {

                if (Program.visit[i] != null)
                {
                    if (Program.visit[i].download >= max1)
                    {
                        day1 = i;
                        max1 = Program.visit[i].download;
                    }

                }

            }
            for (int i = 0; i < Program.visit.Length; ++i)

            {

                if (Program.visit[i] != null)
                {
                    if (Program.visit[i].download >= max2 && Program.visit[i].download != max1)
                    {
                        day2 = i;
                        max2 = Program.visit[i].download;
                    }

                }


            }
            for (int i = 0; i < Program.visit.Length; ++i)

            {

                if (Program.visit[i] != null)
                {
                    if (Program.visit[i].download >= max3 && Program.visit[i].download != max1 && Program.visit[i].download != max2)
                    {
                        day3 = i;
                        max3 = Program.visit[i].download;
                    }

                }


            }
            Console.WriteLine("{0,-30} {1, -30} {2, -30} {3, -15} {4, -15}", Program.visit[day1].name, Program.visit[day1].URL, Program.visit[day1].date, Program.visit[day1].host, Program.visit[day1].download);
            Console.WriteLine("{0,-30} {1, -30} {2, -30} {3, -15} {4, -15}", Program.visit[day2].name, Program.visit[day2].URL, Program.visit[day2].date, Program.visit[day2].host, Program.visit[day2].download);
            Console.WriteLine("{0,-30} {1, -30} {2, -30} {3, -15} {4, -15}", Program.visit[day3].name, Program.visit[day3].URL, Program.visit[day3].date, Program.visit[day3].host, Program.visit[day3].download);
        }
        public override void Ser()
        {
            Console.Write("Введіть період\nВід: ");
            string ddate1 = Console.ReadLine();
            DateTime date1 = Convert.ToDateTime(ddate1);
            Console.Write("До: ");
            string ddate2 = Console.ReadLine();
            DateTime date2 = Convert.ToDateTime(ddate2);
            int m = 0;
            int n = 0;
            for (int i = 0; i < Program.visit.Length; ++i)
            {
                if (Program.visit[i] != null)
                {
                    if (Program.visit[i].date >= date1 && Program.visit[i].date <= date2)
                    {
                        n++;
                        m += Program.visit[i].host;
                        Console.WriteLine("{0,-30} {1, -30} {2, -30} {3, -15} {4, -15}", Program.visit[i].name, Program.visit[i].URL, Program.visit[i].date, Program.visit[i].host, Program.visit[i].download);

                    }
                }


            }
            Console.WriteLine("Середня кількість хостів в день за період: {0}", m / n);


        }
    }


    class Output
    {
        public static void Write(Visiting[] v)
        {


            for (int i = 0; i < v.Length; ++i)
            {
                if (v[i] != null)
                {
                    Console.WriteLine("{0,-30} {1, -20} {2, -30} {3, -15} {4,-15}", Program.visit[i].name, Program.visit[i].URL, Program.visit[i].date, Program.visit[i].host, Program.visit[i].download);
                }
            }
        }
    }
    class Input
    {


        public static void Key()
        {
            Work.Parse(Read(), false);

            Console.WriteLine("Додавання записiв: +");
            Console.WriteLine("Редагування записiв: E");
            Console.WriteLine("Знищення записiв: -");
            Console.WriteLine("Середня кількість хостів в день за період: F");
            Console.WriteLine("Дні з максимальною кількістю завантажених сторінок: S");
            Console.WriteLine("Кількість днів, коли співвідношення хостів до сторінок перевищує задане значення: K");
            Console.WriteLine("Виведення записiв: Enter");

            Console.WriteLine("Вихiд: Esc");

            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.OemPlus:
                    Console.WriteLine();
                    Work.Add();
                    break;

                case ConsoleKey.E:
                    Console.WriteLine();
                    Work.Edit();
                    break;

                case ConsoleKey.OemMinus:
                    Console.WriteLine();
                    Work.Remove();
                    break;

                case ConsoleKey.Enter:
                    Console.WriteLine();
                    Output.Write(Program.visit);
                    Key();
                    break;
                case ConsoleKey.F:
                    Console.WriteLine();
                    Program.visit[0].Ser();
                    break;
                case ConsoleKey.S:
                    Console.WriteLine();
                    Program.visit[0].Maxday();
                    break;
                case ConsoleKey.K:
                    Console.WriteLine();
                    Program.visit[0].Number();
                    break;



                case ConsoleKey.Escape:
                    return;
            }
        }
        public static string[] Read()
        {
            StreamReader fromFile = new StreamReader("text.txt");

            return fromFile.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        }
    }
    class Work
    {
       
        public static void Add()
        {
            Console.WriteLine("Введiть данi");

            Console.Write("Назва: ");
            string str = Console.ReadLine();
            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", str);

            Console.Write("URL: ");
            string URL1 = Console.ReadLine();
            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", URL1);

            Console.Write("Дата: ");
            string ddate = Console.ReadLine();

            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", ddate);

            Console.Write("Кількість хостів: ");
            string host1 = Console.ReadLine();
            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", host1);

            Console.Write("Кількість завантажень: ");
            string down1 = Console.ReadLine();
            File.AppendAllText("text.txt", "\n");
            File.AppendAllText("text.txt", down1);

            Output.Write(Program.visit);

            Input.Key();

        }

        public static void Remove()
        {
            Console.Write("Виконавець: ");

            string name = Console.ReadLine();

            bool[] write = new bool[Program.visit.Length];

            for (int i = 0; i < Program.visit.Length; ++i)
            {
                if (Program.visit[i] != null)
                {
                    if (Program.visit[i].name == name)
                    {
                        Console.WriteLine("{0,-30} {1, -30} {2, -30} {3, -15} {4, -15}", Program.visit[i].name, Program.visit[i].URL, Program.visit[i].date, Program.visit[i].host, Program.visit[i].download);

                        Console.WriteLine("Видалити? (Y/N)\n");

                        var key = Console.ReadKey().Key;

                        if (key == ConsoleKey.Y)
                        {

                            Program.visit[i] = null;
                            Program.delete[i] = true;
                            Output.Write(Program.visit);



                        }
                        else
                        {
                            Program.delete[i] = false;
                        }
                    }
                }
            }
        }

        public static void Edit()
        {

            Console.WriteLine("Що ви хочете редагувати");
            string what = Console.ReadLine();
            switch (what)
            {
                case "name":
                    Console.WriteLine("Що саме");
                    string name1 = Console.ReadLine();
                    for (int i = 0; i < Program.visit.Length; ++i)
                    {
                        if (Program.visit[i] != null)
                        {
                            if (Program.visit[i].name == name1)
                            {
                                Console.WriteLine("{0,-30} {1, -20} {2, -30} {3, -15} {4, -15}", Program.visit[i].name, Program.visit[i].URL, Program.visit[i].date, Program.visit[i].host, Program.visit[i].download);


                                Console.WriteLine("Введiть нову назву");

                                string str = Console.ReadLine();

                                Program.visit[i].name = str;

                                Output.Write(Program.visit);
                            }
                        }

                    }
                    break;
                case "URL":
                    Console.WriteLine("Що саме");
                    string URL1 = Console.ReadLine();



                    for (int i = 0; i < Program.visit.Length; ++i)
                    {
                        if (Program.visit[i] != null)
                        {
                            if (Program.visit[i].name == URL1)
                            {
                                Console.WriteLine("{0,-30} {1, -20} {2, -30} {3, -15} {4, -15}", Program.visit[i].name, Program.visit[i].URL, Program.visit[i].date, Program.visit[i].host, Program.visit[i].download);


                                Console.WriteLine("Введiть нову URL");

                                string str = Console.ReadLine();

                                Program.visit[i].URL = str;

                                Output.Write(Program.visit);
                            }
                        }

                    }
                    break;
                case "date":
                    Console.WriteLine("Що саме");
                    string name2 = Console.ReadLine();
                    for (int i = 0; i < Program.visit.Length; ++i)
                    {
                        if (Program.visit[i] != null)
                        {
                            if (Program.visit[i].name == name2)
                            {
                                Console.WriteLine("{0,-30} {1, -20} {2, -30} {3, -15} {4, -15}", Program.visit[i].name, Program.visit[i].URL, Program.visit[i].date, Program.visit[i].host, Program.visit[i].download);


                                Console.WriteLine("Введiть нову дату");

                                string str = Console.ReadLine();

                                Program.visit[i].date = Convert.ToDateTime(str);

                                Output.Write(Program.visit);
                            }
                        }

                    }
                    break;
                case "host":
                    Console.WriteLine("Що саме");
                    string name3 = Console.ReadLine();
                    for (int i = 0; i < Program.visit.Length; ++i)
                    {
                        if (Program.visit[i] != null)
                        {
                            if (Program.visit[i].name == name3)
                            {
                                Console.WriteLine("{0,-30} {1, -20} {2, -30} {3, -15} {4, -15}", Program.visit[i].name, Program.visit[i].URL, Program.visit[i].date, Program.visit[i].host, Program.visit[i].download);


                                Console.WriteLine("Введiть нову кількість хостів");

                                int str = int.Parse(Console.ReadLine());

                                Program.visit[i].host = str;

                                Output.Write(Program.visit);
                            }
                        }

                    }
                    break;

                case "download":
                    Console.WriteLine("Що саме");
                    string name4 = Console.ReadLine();
                    for (int i = 0; i < Program.visit.Length; ++i)
                    {
                        if (Program.visit[i] != null)
                        {
                            if (Program.visit[i].name == name4)
                            {
                                Console.WriteLine("{0,-30} {1, -20} {2, -30} {3, -15} {4, -15}", Program.visit[i].name, Program.visit[i].URL, Program.visit[i].date, Program.visit[i].host, Program.visit[i].download);


                                Console.WriteLine("Введiть нову кількість завантажених сторінок");

                                int str = int.Parse(Console.ReadLine());

                                Program.visit[i].download = str;

                                Output.Write(Program.visit);
                            }
                        }

                    }
                    break;

            }


        }




        private static void Save(Visiting m)
        {
            StreamWriter save = new StreamWriter("text.txt", true);

            save.WriteLine(m.name);
            save.WriteLine(m.URL);
            save.WriteLine(m.date);
            save.WriteLine(m.host);
            save.WriteLine(m.download);

            save.Close();
        }

        public static void Parse(string[] elements, bool save)
        {
            int counter = 0;

            while (Program.visit[counter] != null)
            {
                ++counter;
            }

            for (int i = 0; i < elements.Length; i += 5)
            {
                Program.visit[counter + i / 5] = new Visiting(elements[i], elements[i + 1], DateTime.Parse(elements[i + 2]), int.Parse(elements[i + 3]), int.Parse(elements[i + 4]));

                if (save)
                {
                    Save(Program.visit[counter + i / 5]);
                }
            }
        }
        public static string[] Read()
        {
            StreamReader fromFile = new StreamReader("text.txt");

            return fromFile.ReadToEnd().Split("\r\n", StringSplitOptions.RemoveEmptyEntries);
        }




    }


    class Program
    {
        public static Visiting[] visit = new Visiting[1000000];
        public static bool[] delete = new bool[1000000];
        static void Main(string[] args)
        {
            Input.Key();
        }
    }
}
