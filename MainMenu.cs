using System;
namespace zaba
{
    static public class MainMenu
    {
        public static Player player { set; get; } = new Player();
        static public void WriteBeginMenu()
        {
            Console.SetCursorPosition(cWnd.xmax/4, cWnd.ymin);
            
            Console.WriteLine("HI!! It's ZABA 1.0!!!");
            
            Console.Write("Please, enter your name: ");
            player._name = Console.ReadLine();
        }
        static public void WriteEndMenu()
        {
            RecordsTable.Logic(player);
            RecordsTable.WriteRecords();
        }
    }
}