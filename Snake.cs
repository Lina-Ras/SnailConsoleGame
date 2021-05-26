using System;
using System.Collections.Generic;

namespace zaba
{
    public class Snake
        {
            public List<Coords> _body = new List<Coords>() { };  //0 - head, lenght-1 = tail
            public int _lenght { set; get;}
            Direction _direction;
            public bool _isAlive { set; get; } = true;

            public Snake() {
                for (int fy = 0; fy < StartCoords.lenght; ++fy)
                {
                    Coords a = new Coords(StartCoords.xPos, StartCoords.yPos-fy);
                    _body.Add(a);
                }
                _lenght = _body.Count;
                _direction = Direction.DOWN;
                _isAlive = true;
            }
            public void DrawSnake()
            {
                _body[0].SetChar(CharTable.Head);
                for (int i = 1; i<_lenght; ++i)
                {
                    _body[i].SetChar(CharTable.Body);
                }
                return;
            }

            public int NewY()
            {
                int ky = 0;
                switch (_direction)
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
                switch (_direction)
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
                _body[_lenght-1].DeleteChar();
                _body.RemoveAt(_lenght-1);
                Coords head = new Coords();
                head.x = _body[0].x + kx;
                head.y = _body[0].y + ky;
                _body.Insert(0, head);
                return;
            }

            public void Grow()
            {
                Coords tail = new Coords();
                tail.x = _body[_lenght-1].x;
                tail.y = _body[_lenght-1].y;
                _body.Insert(_lenght-1, tail);
                ++_lenght;
            }
            
            public void Eat(Apple apple)                                        
            {                                                                                       
                if (_body[0].x == apple._coordA.x && _body[0].y == apple._coordA.y)     
                {
                    apple.AddApple();
                    foreach (Coords s in _body)  //Праверка: ці не дадаўся яблык на цела змяі
                    {
                        if (s.x == apple._coordA.x && s.y == apple._coordA.y)
                        {
                            apple.AddApple();
                        }
                    }
                    Grow();                                                                   
                }                                                                                   
                                                                                        
                return;                                                                             
            }                                                                                       
            public bool Bite()
            {
                for (int i = 1; i < _lenght; ++i)
                {
                    if (_body[0].x == _body[i].x && _body[0].y == _body[i].y)
                    {
                        return true;
                    }
                }
                return false;
            }
            public bool Wall()
            {
                if (_body[0].x == cWnd.xmin || _body[0].x == cWnd.xmax
                    || _body[0].y == cWnd.ymin || _body[0].y == cWnd.ymax)
                    {
                        return true;
                    }
                return false;
            }
            public void Rotation(ConsoleKey key) {
                switch (_direction)
                {
                    case Direction.RIGHT:
                    case Direction.LEFT:
                    {
                        if (key == ConsoleKey.DownArrow)
                            _direction = Direction.DOWN;
                        else if (key == ConsoleKey.UpArrow)
                            _direction = Direction.UP;
                        break;
                    }
                    case Direction.UP:
                    case Direction.DOWN:
                    {
                        if (key == ConsoleKey.LeftArrow)
                            _direction = Direction.LEFT;
                        else if (key == ConsoleKey.RightArrow)
                            _direction = Direction.RIGHT;
                        break;
                    }
                }
                return;
            }
        }
}