using System;
using System.Timers;

namespace zaba
{
    public class GamePlay
    {
        static Timer _time = new Timer(TimerSpeed.deltaNormal);
        static Snake _snake = new Snake();
        static Apple _apple = new Apple();
        static Player _player = new Player();
        static void WriteScore()
        {
            Console.SetCursorPosition(cWnd.xmin, cWnd.ymin - 2);
            Console.Write($"Score: {_snake._lenght}");
            return;
        }
        
        static void WritePlayersName()
        {
            Console.SetCursorPosition(cWnd.xmax - _player._name.Length - 5, cWnd.ymin - 1);
            Console.Write($"Hi, {_player._name}");
            return;
        }

        static void SetBorders()
        {
            Coords point1 = new Coords(1, cWnd.ymin);
            Coords point2 = new Coords(1, cWnd.ymax);
            for (int i = 1; i <= cWnd.xmax; ++i) //horizontal
            {
                point1.x = i;
                point2.x = i;
                point1.SetChar(CharTable.Wall);
                point2.SetChar(CharTable.Wall);
            }

            point1.x = cWnd.xmin; //vertical
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
        
        static void SetTimer()
        {
            _time.Elapsed += RepGame;
            _time.AutoReset = true;
            _time.Enabled = true;
        }
        
        public static Player PlayerInfo()
        {
            _player._score = _snake._lenght;
            return _player;
        }

        static void RepGame(object obj,  ElapsedEventArgs e)
        {
            _snake.Moving();
            if (_snake.Bite() || _snake.Wall())
            {
                _snake._isAlive = false;
                _time.Enabled = false;
            }
            _snake.Eat(_apple);
            _snake.DrawSnake();
            _apple.DrawApple();
            WriteScore();
            return;
        }

        public static void Play(Player player)
        {
            Console.Clear();
            _player = player;
            WritePlayersName();
            SetBorders();
            _apple.AddApple();
            SetTimer();
            while (_snake._isAlive == true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    _snake.Rotation(key.Key);
                }
            }
            _time.Stop();
            _time.Dispose();
            
            Console.Clear();
        }
    }
}