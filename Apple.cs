using System;
using System.Dynamic;

namespace zaba
{
    public class Apple
    {
        public Coords coordA { set; get; } = new Coords();

        private bool exist { set; get; }

        public Apple(){ }
        
        public void DrawApple()
        {
            coordA.SetChar(CharTable.Apple);
        }
        public void AddApple()
        {
            Random rnd = new Random();
            coordA.x = rnd.Next(2, cWnd.xmax - 2);
            coordA.y = rnd.Next(4, cWnd.ymax - 3);
            DrawApple();
            exist = true;
            return;
        }
    }
}