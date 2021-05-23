//дзіўны баг пры павароце з лева ўверх ці ўніз

using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;

namespace zaba
{
    class Program
    {

        static Timer time;
        static Snake snake = new Snake();
        static Apple apple = new Apple();
        static void WriteScore()
        {
            Console.SetCursorPosition(cWnd.xmin, cWnd.ymin-2);

            var builder = new StringBuilder();
            builder.Append("Score: ");
            builder.Append(snake.lenght).ToString();

            Console.WriteLine(builder);
            return;
        }
        static void SetBorders() 
        {
            Coords point1 = new Coords(1, cWnd.ymin);
            Coords point2 = new Coords(1, cWnd.ymax);
            for(int i = 1; i <= cWnd.xmax; ++i)   //horizontal
            {
                point1.x = i;
                point2.x = i;
                point1.SetChar(CharTable.Wall);
                point2.SetChar(CharTable.Wall);
            }
            point1.x = cWnd.xmin;   //vertical
            point2.x = cWnd.xmax;
            for (int i = 2; i < cWnd.ymax; ++i)
            {
                point1.y = i;
                point2.y = i;
                point1.SetChar(CharTable.Wall);
                point2.SetChar(CharTable.Wall);
            }
            return;
        }
        public static void Eat ()
        {
            if (snake.body[0].x == apple.coordA.x && snake.body[0].y == apple.coordA.y)
            {
                apple.AddApple();
                snake.Grow();
            }
            return;
        }
        static void Loop(object obj)
        {
            snake.Moving();
            snake.DrawSnake();
            Eat();
            WriteScore();
            if (snake.Bite() || snake.Wall() )
            {
                snake.IsAlive = false;
                time.Change(Timeout.Infinite, Timeout.Infinite);
            }
            return;
        }
        static void Main(string[] args)
        {
            Console.SetWindowSize(cWnd.xmax + 1, cWnd.ymax + 1);
            Console.SetBufferSize(cWnd.xmax + 1, cWnd.ymax + 1);
            Console.CursorVisible = false;
            
            SetBorders();
            apple.AddApple();

            if (snake.IsAlive == true)
            {
                TimerCallback timeCB = new TimerCallback(Loop);
                Timer time = new Timer(timeCB, null, 500, 250);
                while (true) {
                    if (Console.KeyAvailable)
                    {
                        ConsoleKeyInfo key = Console.ReadKey();
                        snake.Rotation(key.Key);
                    }
                }
            }
            
            Console.Clear();
            Console.Write("You lose!");
        }
    }
}
