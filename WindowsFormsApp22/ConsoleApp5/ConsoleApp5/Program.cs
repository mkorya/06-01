using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var flat = new Flat();
           
            var auto= new Autorasp();
            Console.WriteLine("товары");
            Console.WriteLine("кол-во товаров");
            var tovarCountStr = Console.ReadLine();
            if (int.TryParse(tovarCountStr, out int tovarCount))
            {
                for (int i = 0; i <tovarCount+1; i++)
                {
                    if (i == 0)
                    {
                        
                        var name = "23";

                        Console.WriteLine("Введите оптовую цену для проверки: ");
                        var costi = Console.ReadLine();
                        if (!float.TryParse(costi, out float cost))
                        {
                            Console.WriteLine($"Invalid square: {costi}");
                            break;
                        }
                        
                        var articul = "1";
                        if (!int.TryParse(articul, out int art))
                        {
                            Console.WriteLine($"Invalid square: {articul}");
                            break;
                        }

                        Console.WriteLine("Категория для проверки: ");
                        var kateg = Console.ReadLine();


                        var room = new Room(name, cost, art, kateg);
                        
                        flat.AddRoom(room);
                        
                    }
                    else
                    {
                        Console.WriteLine($"введите подробности по поводу товара N {i }");

                        Console.WriteLine("Наименование товара: ");
                        var name = Console.ReadLine();

                        Console.WriteLine("Введите оптовую цену: ");
                        var costi = Console.ReadLine();
                        if (!float.TryParse(costi, out float cost))
                        {
                            Console.WriteLine($"Invalid square: {costi}");
                            break;
                        }
                        Console.WriteLine("Введите артикул: ");
                        var articul = Console.ReadLine();
                        if (!int.TryParse(articul, out int art))
                        {
                            Console.WriteLine($"Invalid square: {articul}");
                            break;
                        }

                        Console.WriteLine("Категория: ");
                        var kateg = Console.ReadLine();

                        var room = new Room(name, cost, art, kateg);
                        
                        flat.AddRoom(room);
                       
                    }
                    
                }
                
                Console.ReadKey();
                Console.WriteLine("Список товаров" +flat.GetTotalSquare());
                Console.WriteLine("Сумма товаров "+flat.Livingsquare());
                Console.WriteLine("MIN "+flat.Naitiminsena());
                Console.WriteLine("увеличенные "+flat.Get());
               
            }

            Console.WriteLine("Машины");
            Console.WriteLine("кол-во Машин");

            tovarCountStr = Console.ReadLine();
            if (int.TryParse(tovarCountStr, out  tovarCount))
            {
                for (int i = 0; i < tovarCount + 1; i++)
                {
                    if (i == 0)
                    {
                        Console.WriteLine("Введите марку для проверки");
                        var name = Console.ReadLine();

                        Console.WriteLine("Введите оптовую цену для проверки: ");
                        var costi = Console.ReadLine();
                        if (!float.TryParse(costi, out float cost))
                        {
                            Console.WriteLine($"Invalid square: {costi}");
                            break;
                        }

                        var articul = "1";
                        if (!int.TryParse(articul, out int art))
                        {
                            Console.WriteLine($"Invalid square: {articul}");
                            break;
                        }

                       


                        
                        var room1 = new Avtomobil(name, cost, art);
                       
                        auto.dovav(room1);
                    }
                    else
                    {
                        Console.WriteLine($"введите подробности по поводу товара N {i}");

                        Console.WriteLine("Наименование товара: ");
                        var name = Console.ReadLine();

                        Console.WriteLine("Введите оптовую цену: ");
                        var costi = Console.ReadLine();
                        if (!float.TryParse(costi, out float cost))
                        {
                            Console.WriteLine($"Invalid square: {costi}");
                            break;
                        }
                        Console.WriteLine("Введите артикул: ");
                        var articul = Console.ReadLine();
                        if (!int.TryParse(articul, out int art))
                        {
                            Console.WriteLine($"Invalid square: {articul}");
                            break;
                        }

                        

                        
                        var room1 = new Avtomobil(name, cost, art);
                       
                        auto.dovav(room1);
                    }

                }

                
                Console.WriteLine("список машин " + auto.GetTotalSquare());
                Console.WriteLine("кол-во машин" + auto.Livingsquare());
                Console.WriteLine("MAX " + auto.Naitiminsena());
            }
            Console.ReadKey();
        }
    }
}
