using System;

namespace zaba
{
    public class Apple
    {
        public Coords _coordA { set; get; } = new Coords();

        public Apple(){ }
        
        public void DrawApple()
        {
            _coordA.SetChar(CharTable.Apple);
        }
        public void AddApple()
        {
            Random rnd = new Random();
            _coordA.x = rnd.Next(2, cWnd.xmax - 2);
            _coordA.y = rnd.Next(4, cWnd.ymax - 3);
            return;
        }
    }
}