//крц, багліст
// 1) няправільна дадаецца хвост (трэба прапісваць накірунак ня толькі галавы)
// 2) проста часам нейкая фігня адбываецца
// (3) яблыкі могуць з'явіцца на месцы цела змяі і гэта не апрацоўваецца (здаецца выправіла, але ж)
// За шмат Player ва ўсіх класах. Глабальная пераменная? Статычны клас?
// Фдзін і той жа карыстальнік трымае некалькі радкоў у таблічцы
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
