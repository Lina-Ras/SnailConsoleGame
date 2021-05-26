//крц, багліст
// 2) проста часам нейкая фігня адбываецца  (Console.Key пачытаць падрабязней)
// 4) За шмат Player ва ўсіх класах. Глабальная пераменная? Статычны клас?
// 5) Адзін і той жа карыстальнік трымае некалькі радкоў у таблічцы
using System;

namespace zaba
{
    class Program
    {   
        static Player player = new Player();
        static void Main(string[] args)
        {
            Console.SetWindowSize(cWnd.xmax + 1, cWnd.ymax + 1);
            Console.SetBufferSize(cWnd.xmax + 1, cWnd.ymax + 1);
            Console.CursorVisible = false;

            MainMenu.WriteBeginMenu();
            player = MainMenu.player;
            
            GamePlay.Play(player);
            player = GamePlay.PlayerInfo();
            
            MainMenu.player = player;
            MainMenu.WriteEndMenu();
            Console.ReadKey();
        }
    }
}
