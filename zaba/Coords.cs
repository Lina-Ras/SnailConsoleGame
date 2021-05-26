using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace zaba
{
    public class Coords
    {
        public int x { set; get;}
        public int y { set; get;}
        public Coords(int xa, int ya) { x=xa; y=ya; }
        public Coords() { }
        public void SetChar(char ch)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(ch);
            return;
        }
        public void DeleteChar()
        {
            SetChar(' ');
            return;
        }
    }
}