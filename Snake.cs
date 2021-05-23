using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Text;

namespace zaba
{
    public class Snake
        {
            public List<Coords> body = new List<Coords>() { };  //0 - head, lenght-1 = tail
            public int lenght { set; get;}
            Direction direction;
            public bool IsAlive { set; get; } = true;

            public Snake() {
                for (int fy = 0; fy < StartCoords.lenght; ++fy)
                {
                    Coords a = new Coords(StartCoords.xPos, StartCoords.yPos-fy);
                    body.Add(a);
                }
                lenght = body.Count;
                direction = Direction.DOWN;
                IsAlive = true;
            }
            public void DrawSnake()
            {
                body[0].SetChar(CharTable.Head);
                for (int i = 1; i<lenght; ++i)
                {
                    body[i].SetChar(CharTable.Body);
                }
                return;
            }

            public int NewY()
            {
                int ky = 0;
                switch (direction)
                {
                    case Direction.DOWN:
                    {
                        ky = 1;
                        break;
                    }
                    case Direction.UP:
                    {
                        ky = -1;
                        break;
                    }
                }
                return ky;
            }
            public int NewX()
            {
                int kx = 0;
                switch (direction)
                {
                    case Direction.LEFT:
                    {
                        kx = -1;
                        break;
                    }
                    case Direction.RIGHT:
                    {
                        kx = 1;
                        break;
                    }
                }
                return kx;
            }
            public void Moving()
            {
                int ky = NewY(); 
                int kx = NewX();
                body[lenght-1].DeleteChar();
                body.RemoveAt(lenght-1);
                Coords head = new Coords();
                head.x = body[0].x + kx;
                head.y = body[0].y + ky;
                body.Insert(0, head);
                return;
            }

            public void Grow()
            {
                int ky = NewY(); 
                int kx = NewX();
                Coords tail = new Coords();
                tail.x = body[lenght-1].x + kx;
                tail.y = body[lenght-1].y + ky;
                body.Insert(lenght-1, tail);
                ++lenght;
            }
            public bool Bite()
            {
                for (int i = 1; i < lenght; ++i)
                {
                    if (body[0].x == body[i].x && body[0].y == body[i].y)
                    {
                        return true;
                    }
                }
                return false;
            }
            public bool Wall()
            {
                if (body[0].x == cWnd.xmin || body[0].x == cWnd.xmax
                    || body[0].y == cWnd.ymin || body[0].y == cWnd.ymax)
                    {
                        return true;
                    }
                return false;
            }
            public void Rotation(ConsoleKey key) {
                switch (direction)
                {
                    case Direction.RIGHT:
                    case Direction.LEFT:
                    {
                        if (key == ConsoleKey.DownArrow)
                            direction = Direction.DOWN;
                        else if (key == ConsoleKey.UpArrow)
                            direction = Direction.UP;
                        break;
                    }
                    case Direction.UP:
                    case Direction.DOWN:
                    {
                        if (key == ConsoleKey.LeftArrow)
                            direction = Direction.LEFT;
                        else if (key == ConsoleKey.RightArrow)
                            direction = Direction.RIGHT;
                        break;
                    }
                }
                return;
            }
        }
}