using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace jokamakarok
{
    class Program
    {
        static Coords cWnd = new Coords(60,30);
        static CharTable ch = new CharTable('█', 'o', '█');
        static StartCoords startCoords = new StartCoords(30, 10, 3);

        static Timer time;
        static Snake snake = new Snake();
        class CharTable
        {
            public char Wall { get; }
            public char Apple { get; }
            public char Body { get; }

            public CharTable(char wall, char apple, char body) { Wall = wall; Apple = apple; Body = body;}
        }
        class StartCoords
        {
            public int xPos { get; }
            public int yPos { get; }
            public int lenght { get; }
            public StartCoords(int x, int y, int l) { xPos = x; yPos = y; lenght = l; }
        }
        
        class Coords
        {
            public int x { set; get;}
            public int y { set; get;}
            public Coords(int xa, int ya) { x=xa; y=ya; }
            public Coords() { }
            public void SetChar(char ch)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(ch);
            }
            public void DeleteChar()
            {
                SetChar(' ');
            }
        }
        static void WriteScore()
        {
            Console.SetCursorPosition(1, 2);

            var builder = new StringBuilder();
            builder.Append("Score: ");
            builder.Append(snake.lenght).ToString();

            Console.WriteLine(builder);
        }
        static void SetBorders() 
        {
            Coords point1 = new Coords(1, 3);
            Coords point2 = new Coords(1, cWnd.y);
            for(int i = 1; i <= cWnd.x; ++i)   //horizontal
            {
                point1.x = i;
                point2.x = i;
                point1.SetChar(ch.Wall);
                point2.SetChar(ch.Wall);
            }
            point1.x = 1;   //vertical
            point2.x = cWnd.x;
            for (int i = 2; i < cWnd.y; ++i)
            {
                point1.y = i;
                point2.y = i;
                point1.SetChar(ch.Wall);
                point2.SetChar(ch.Wall);
            }
        }
        static void AddApples()
        {
            Coords point = new Coords();
            Random rnd = new Random();
            point.x = rnd.Next(2, cWnd.x-2);
            point.y = rnd.Next(4, cWnd.y-3);
            point.SetChar(ch.Apple);

        }

        enum Direction 
        {
            UP,
            DOWN,
            LEFT,
            RIGHT
        }
        class Snake
        {
            List<Coords> body = new List<Coords>() { };
            public int lenght { get; }
            Coords tail;
            Coords head;
            Direction direction;

            public Snake() {
                for (int fy = 0; fy < startCoords.lenght; ++fy)
                {
                    Coords a = new Coords(startCoords.xPos, startCoords.yPos-fy);
                    body.Add(a);
                }
                lenght = body.Count;
                tail = body[lenght-1]; 
                head = body[0];
                direction = Direction.DOWN;
            }
            public void DrawSnake()
            {
                foreach (Coords i in body)
                {
                    i.SetChar(ch.Body);
                }
                return;
            }

            public void OneMove()
            {
                tail.DeleteChar();
                head.SetChar(ch.Body);
                body.Remove(tail);
                body.Add(head);
                tail.x = body[lenght - 1].x;
                tail.y = body[lenght - 1].y;
                return;
            }
            public void Moving()
            {
                switch (direction)
                {
                    case Direction.DOWN:
                    {
                        ++head.y;
                        OneMove();
                        break;
                    }
                    case Direction.UP:
                    {
                        --head.y;
                        OneMove();
                        break;
                    }
                    case Direction.LEFT:
                    {
                        --head.x;
                        OneMove();
                        break;
                    }
                    case Direction.RIGHT:
                    {
                        --head.x;
                        OneMove();
                        break;
                    }
                }
                return;
            }
        }

        private static int k = 0;
        static void Loop(object obj)
        {
            k++;
            snake.Moving();
            return;
        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(cWnd.x + 1, cWnd.y + 1);
            Console.SetBufferSize(cWnd.x + 1, cWnd.y + 1);
            Console.CursorVisible = false;

            WriteScore();
            SetBorders();
            snake.DrawSnake();
            

            TimerCallback timeCB = new TimerCallback(Loop);
            Timer time = new Timer(timeCB, null, 100, 1000);
            Console.ReadLine();
            Console.Clear();
            Console.Write("You lose!");
        }
    }
}
