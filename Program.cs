using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ezednevnik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Show();

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        ShowDetails();
                        break;
                    case ConsoleKey.LeftArrow:
                        LeftArrow();
                        Show();
                        break;
                    case ConsoleKey.RightArrow:
                        RightArrow();
                        Show();
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        static void Show()
        {

            Console.Clear();

            Console.WriteLine("Ежедневник - " + ChooseDate.ToShortDateString());
            Console.WriteLine("--------------------------");

           

            NoteChooseDate = notes.Where(n => n.Date.Date == ChooseDate.Date).ToList();

            if (NoteChooseDate.Count > 0)
            {

                for (int i = 0; i < NoteChooseDate.Count; i++)
                {
                    Notes note = NoteChooseDate[i];

                    Console.WriteLine(note.Title);
                }
            }
            else
            {
                Console.WriteLine("  ");
                Console.WriteLine("  Нет заметок.");
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("Чтобы переключаться по датам нажмите Space + стрелка лево/право");
            Console.WriteLine("Чтобы переключаться вверх/низ нажимайте стрелочки вверх/вниз");
            Console.WriteLine("Для отрытия подробностей заметки нажмите Space + Enter");
            Menu menu = new Menu();
            menu.Show();

         /*   do
            {

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");


                key = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");

                if (key.Key == ConsoleKey.UpArrow && pos != 1)
                {
                    pos--;
                    if (pos == 1)
                    {
                        pos = 3;
                    }
                }

                if (key.Key == ConsoleKey.DownArrow && pos != 5)
                {
                    pos++;
                    if (pos == 4)
                    {
                        pos = 2;
                    }
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    ShowDetails();
                    
                    
                }

                if (key.Key == ConsoleKey.LeftArrow)
                {
                    LeftArrow();
                   
                }


                if (key.Key == ConsoleKey.RightArrow)
                {
                    RightArrow();
                    
                }
                

               
                Console.SetCursorPosition(0, 10);


            } while (key.Key != ConsoleKey.Spacebar);*/
            


        }
        static void ShowDetails()
        {
            Console.Clear();
            Console.WriteLine("Детали(" + ChooseDate.ToShortDateString() + "):");

            if (NoteChooseDate.Count > 0)
            {
                Notes ChooseNote = NoteChooseDate[ChooseID];
                Console.WriteLine("--------------------");
                Console.WriteLine("Заголовок: " + ChooseNote.Title);
                Console.WriteLine("Описание: " + ChooseNote.Description);
            }
            else
            {
                Console.WriteLine("На выбранную дату нет заметок.");
            }

            Console.WriteLine("Нажмите любую клавишу.");

            Console.ReadKey();
            Show();
        }
    
        static void ObnovlenieNotes()
        {
            NoteChooseDate = notes.Where(n => n.Date.Date == ChooseDate.Date).ToList();
            ChooseID = 0;
        }
        static void RightArrow()
        {
            ChooseDate = ChooseDate.AddDays(1);
            ObnovlenieNotes();
        }

        static void LeftArrow()
        {
            ChooseDate = ChooseDate.AddDays(-1);
            ObnovlenieNotes();
        }

        


        static List<Notes> notes = new List<Notes>
        {

            new Notes("   Поесть", "Вкусно поесть", new DateTime(2023, 10, 17)),
            new Notes("   Тут ничего нет", "Тут ничего нет", new DateTime(2023, 10, 17)),
            new Notes("   Попить(желательно)", "Вкусно попить(Опционально)", new DateTime(2023, 10, 19)),
            new Notes("   Тут ничего нет", "Тут ничего нет", new DateTime(2023, 10, 19)),
            new Notes("   Что-то сейчас сделать", "Потом что-то произойдёт(пасхалка на 24 дате)", new DateTime(2023, 10, 21)),
            new Notes("   Тут ничего нет", "Тут ничего нет", new DateTime(2023, 10, 21)),
            new Notes("   Что?", "Каво?", new DateTime(2023, 10, 22)),
            new Notes("   Тут ничего нет", "Тут ничего нет", new DateTime(2023, 10, 22)),
            new Notes("   Я устал это делать", "Честное слово, я переделывал этот кусок дерьмо-костыля раз 6", new DateTime(2023, 10, 24)),
            new Notes("   Тут ничего нет", "Тут ничего нет", new DateTime(2023, 10, 24)),


        };


        static public DateTime ChooseDate = DateTime.Today;
        static public List<Notes> NoteChooseDate;
        static public int ChooseID = 0;
    }
}
