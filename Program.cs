//крц, багліст
// 2) проста часам нейкая фігня адбываецца  (Console.Key пачытаць падрабязней)
// 4) За шмат Player ва ўсіх класах. Глабальная пераменная? Статычны класc
using System;

namespace zaba
{
    class Program
    {   
        static Player player = new Player();
        static void NewGame()
        {
            GamePlay.Play(player);
            player = GamePlay.PlayerInfo();
            WriteEndMenu();
        }
        static void WriteBeginMenu()
        {
            Console.Clear();
            Console.SetCursorPosition(cWnd.xmax/4, cWnd.ymin);
            
            Console.WriteLine("HI!! It's ZABA 1.0!!!");
            
            Console.Write("Please, enter your name: ");
            player._name = Console.ReadLine();
        }
        
        static void WriteEndMenu()
        {
            Console.Clear();
            RecordsTable.Logic(player);
            RecordsTable.WriteRecords();
        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(cWnd.xmax + 1, cWnd.ymax + 1);
            Console.SetBufferSize(cWnd.xmax + 1, cWnd.ymax + 1);
            Console.CursorVisible = false;
            WriteBeginMenu();
            
            NewGame();

            WriteEndMenu();
            Console.ReadKey();
            return;
        }
    }
}
