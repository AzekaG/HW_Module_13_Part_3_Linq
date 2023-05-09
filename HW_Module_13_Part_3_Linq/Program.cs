using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
#region
/*
 Задание 1:
Создайте пользовательский тип Телефон. Необходимо хранить
такую информацию:
 Название телефона
 Производитель
 Цена
 Дата выпуска
Для массива телефонов выполните следующие задания,
используя агрегатные операции из LINQ:
 Посчитайте количество телефонов
 Посчитайте количество телефонов с ценой больше 100
 Посчитайте количество телефонов с ценой в диапазоне от
400 до 700
 Посчитайте количество телефонов конкретного
производителя
 Найдите телефон с минимальной ценой
 Найдите телефон с максимальной ценой
 Отобразите информацию о самом старом телефоне
 Отобразите информацию о самом свежем телефоне
 Найдите среднюю цену телефона
 */
/*
 Добавьте к первому заданию новую функциональность:
 Отобразите пять самых дорогих телефонов
 Отобразите пять самых дешевых телефонов
 Отобразите три самых старых телефона
 Отобразите три самых новых телефона
Для реализации задания используйте семейство методов Skip,
Take.
*/

/*
 Добавьте к первому заданию новую функциональность:
 Отобразите статистику по количеству телефонов каждого
производителя. Например: Sony – 3, Samsung – 4, Apple – 5
и т. д.
 Отобразите статистику по количеству моделей телефонов.
Например: IPhone 13 – 12, IPhone 10 – 11, Galaxy S22 – 8
 Отобразите статистику телефонов по годам. Например: 2021
– 10, 2022 – 5, 2019 – 3 
 */
#endregion



namespace HW_Module_13_Part_3_Linq
{




    class PhoneStory
    {
        public List<TelePhone> Phones;
        public PhoneStory() { }
        public PhoneStory(List<TelePhone> phones)
        {
            Phones = phones;
            Random random = new Random();
            foreach(var el  in Phones)
                el.Amount = random.Next(0, 30);
        }
        
    }

    class TelePhone
    {


        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
        public int ProduceDate { get; set; }
        public int Amount { get; set; }


        public TelePhone() { }
        public TelePhone(string Model, string Manufacturer, int Price, int ProduceDate) 
        {
            this.Model = Model;
            this.Price = Price;
            this.Manufacturer = Manufacturer;
            this.ProduceDate = ProduceDate;    
        }
        public void OutputInfo()
        {
            Console.WriteLine("Produce by "+ Manufacturer);
            Console.WriteLine("Model " + Model);
            Console.WriteLine("Price " + Price);
            Console.WriteLine("Produce Date " +  ProduceDate);
            Console.WriteLine();
        }

    }



     class IniList
    {
          public static List<TelePhone> XiaomiIni()
        {
            List<TelePhone> Res = new List<TelePhone>();
            string[] Model = { "Mi 10", "Mi 10 Pro", "Mi 10T", " Note 10 JE", "Note 10T", "Redmi 9T", "Redmi Note 9S", "Redmi Pad" };
            string Manufacturer = "Xiaomi";
            int[] DateProd = { 2021, 2020, 2020, 2021, 2022, 2016, 2018, 2020 };
            int[] Price = { 110, 230, 220, 216, 500, 430, 440, 600 };
            for (int i = 0; i < 8; i++)
                Res.Add(new TelePhone(Model[i], Manufacturer , Price[i], DateProd[i]));
            return Res;
        }

        public static List<TelePhone> SamsungIni()
        {
            List<TelePhone> Res = new List<TelePhone>();
            string[] Model = { "Galaxy A14", "Galaxy A34", "Galaxy A54", " Galaxy S23+", "Galaxy F54", " Galaxy A31", "Galaxy s20+", "Galaxy zFlip" };
            string Manufacturer = "Samsung";
            int[] DateProd = { 2022, 2022, 2022, 2022, 2022, 2021, 2018, 2020 };
            int[] Price = { 200, 280, 220, 950, 800, 430, 680, 1100 };
            for (int i = 0; i < 8; i++)
                Res.Add(new TelePhone(Model[i], Manufacturer, Price[i], DateProd[i]));
            return Res;

        }
        public static List<TelePhone> AppleIni()
        {
            List<TelePhone> Res = new List<TelePhone>();
            string[] Model = { "7", "7 Plus", "XS Max" , "11" , "11 Pro" , "11 Pro Max" , "13" , "13 mini"};
            string Manufacturer = "Apple";
            int[] DateProd = { 2016, 2016, 2017, 2018, 2018, 2018, 2022, 2022 };
            int[] Price = { 200, 280, 320, 450, 560, 580, 680, 1100 };
            for (int i = 0; i < 8; i++)
                Res.Add(new TelePhone(Model[i], Manufacturer, Price[i], DateProd[i]));
            return Res;

        }



    }

  
    class InterfaceClient
    {
        PhoneStory phoneStory;
       public InterfaceClient(PhoneStory phoneStory) { this.phoneStory = phoneStory; }
        int choice;
        public void Menu()
        {
            int choice;
            do
            {
                Console.WriteLine("Choose an option : ");
                Console.WriteLine("(Task 1)   1-Amount of Mobile Phone ");
                Console.WriteLine("2-Amount of Mobile Phone with Price > 100$");
                Console.WriteLine("3-Amount of MobilePhone with 400 < Price < 700");
                Console.WriteLine("4-Amount Mobile of Firm");
                Console.WriteLine("5-Phones with Lower Price : ");
                Console.WriteLine("6-Phones with Max Price : ");
                Console.WriteLine("7-Info about newest Mobiles");
                Console.WriteLine("8-Info about the Oldest phone");
                Console.WriteLine("9-Mid Price of Phone");
                Console.WriteLine("(Task 2)   10- 5 the most expensive Phones");
                Console.WriteLine("11 -  5 the  cheapest Phones");
               
                Console.WriteLine("12 - 3 the Oldest Phones");
                Console.WriteLine("13 - 3 the newest Phones");
                Console.WriteLine("(Task 3) 14 - Display statistics on the number of phones of eachmanufacturer.");
                Console.WriteLine("15- Display statistics on the number of phone models ");
                Console.WriteLine("16 - Display statistic by years");
                Console.WriteLine("0-Exit");
                choice = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (choice)
                {
                    case 1:
                        {
                            
                            var request = from el in phoneStory.Phones
                                          select el;
                            int summ = 0;
                            foreach (var el in request)
                                summ += el.Amount;
                            Console.WriteLine("Amount of Phones in store = " + summ);

                        }
                        break;
                    case 2:
                        {

                            int summ = 0;
                            var request = from el in phoneStory.Phones
                                          where el.Price > 100
                                          select el;
                            foreach (var el in request)
                                summ += el.Amount;
                            Console.WriteLine("Amount of Phones with Price > 100   =  " + summ);

                        }
                        break;
                    case 3:
                        {
                            int summ = 0;
                            var request = from el in phoneStory.Phones
                                          where el.Price > 400 && el.Price < 700
                                          select el;
                            foreach (var el in request)
                                summ += el.Amount;
                            Console.WriteLine("Amount of Phones with Price > 100   =  " + summ);
                        }
                        break;
                    case 4:
                        {



                            int count = 0;
                            Console.WriteLine("Choose a Firm : ");

                            var tempRequest = from el in phoneStory.Phones
                                              group el by el.Manufacturer into g
                                              select g.Key;

                            foreach (var g in tempRequest)
                                Console.WriteLine(++count + " : " + g);
                            int choiceLocal = int.Parse(Console.ReadLine());
                            count = 0;                                           //возник вопрос по етому моменту , как избежать етого длинного кода? 
                            string res = "";
                            foreach (var g in tempRequest)                      //мне кажется должэно быть проще 
                            {
                                ++count; if (count == choiceLocal) { res = g; break; }
                            }

                            var request = from el in phoneStory.Phones
                                          where el.Manufacturer == res
                                          select el;
                            int amountOfModel = 0;
                            foreach (var g in request)
                                ++amountOfModel;
                            Console.WriteLine("Amount of model : " + amountOfModel);

                        }
                        break;
                    case 5:
                        {
                            var request1 = phoneStory.Phones.Min(p => p.Price);
                            var request = phoneStory.Phones.Where(p => p.Price == request1);
                            Console.WriteLine("The cheapest Telephone cost : ");
                            foreach (var p in request) p.OutputInfo();

                        }
                        break;
                    case 6:
                        {

                            var request1 = phoneStory.Phones.Max(p => p.Price);
                            var request = phoneStory.Phones.Where(p => p.Price == request1);
                            Console.WriteLine("The most expencieve Telephone cost : " );
                            foreach (var p in request) p.OutputInfo();
                        }
                        break;

                    case 7:
                        {
                            var request1 = phoneStory.Phones.Max(p => p.ProduceDate);
                            var request = phoneStory.Phones.Where(p => p.ProduceDate == request1);
                            foreach (var p in request) p.OutputInfo();
                        }
                        break;
                    case 8:
                        {
                            var request1 = phoneStory.Phones.Min(p => p.ProduceDate);
                            var request = phoneStory.Phones.Where(p => p.ProduceDate == request1);
                            foreach (var p in request) p.OutputInfo();
                        }
                        break;
                    case 9:
                        {
                            var request = phoneStory.Phones.Average(p => p.Price);
                            Console.WriteLine("Average price is : " + (int)request);
                        }
                        break;
                    case 10:
                        {

                            var el = (phoneStory.Phones.OrderByDescending(p => p.Price)).Take(5);
                            foreach (var p in el) p.OutputInfo();

                        }
                        break;
                    case 11:
                        {
                            var el = (phoneStory.Phones.OrderBy(p => p.Price)).Take(5);
                            foreach (var p in el) p.OutputInfo();

                        }
                        break;
                    case 12:
                        {
                            var el = (phoneStory.Phones.OrderBy(p => p.ProduceDate)).Take(3);
                            foreach (var p in el) p.OutputInfo();
                        }
                        break;
                    case 13:
                        {
                            var el = (phoneStory.Phones.OrderByDescending(p => p.ProduceDate)).Take(3);
                            foreach (var p in el) p.OutputInfo();
                        }
                        break;
                    
                    case 14:
                        {
                            var el = from p in phoneStory.Phones
                                     group p by p.Manufacturer into g
                                     select g;
                            foreach (var elements in el)
                            {
                                Console.WriteLine(elements.Key + " " + elements.Count());
                            }
                        }
                        break;
                    case 15:
                        {
                            var el = from p in phoneStory.Phones
                                     group p by new
                                     {
                                         Model = p.Manufacturer + " " + p.Model,
                                         Amount = p.Amount
                                     };

                            foreach (var elements in el)
                            {
                                Console.WriteLine(elements.Key.Model + "   =  " + elements.Key.Amount);
                            }
                        }
                        break;
                    case 16:
                        {
                            var el = from p in phoneStory.Phones
                                     orderby p.ProduceDate
                                     group p by p.ProduceDate;



                            foreach (var elements in el)
                            {
                                int summ = 0;
                                foreach (var element in elements)
                                {
                                    summ += element.Amount;
                                }
                                Console.WriteLine(elements.Key + " = " + summ);
                            }

                        }
                        break;


                }

            } while (choice != 0);

        }
    }
 
 

    internal class Program
    {
        IniList IniList = new IniList();
        static void Main(string[] args)
        {
            List<TelePhone> telePhones = new List<TelePhone>();
            telePhones.AddRange(IniList.XiaomiIni());
            telePhones.AddRange(IniList.SamsungIni());
            telePhones.AddRange(IniList.AppleIni());
            InterfaceClient iMenu = new  InterfaceClient(new PhoneStory(telePhones));
            iMenu.Menu();










        }
    }
}
