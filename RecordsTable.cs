using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace zaba
{
    static public class RecordsTable
    {
        static List<Player> _playersList = new List<Player>(20) { };

        static void ReadFile()
        {
            string path= @"Records.txt";
   
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Player tmp = new Player(line, true);
                    AddPlayer(tmp);
                }
            }
            return;
        }

        static void AddPlayer(Player player)
        {
            if (_playersList.Count == _playersList.Capacity && player._score > _playersList.Last()._score)
            {
                    _playersList.Remove(_playersList.Last());
            }
            _playersList.Add(player);
            _playersList.Sort((x, y) => y._score.CompareTo(x._score));
            for (int i = 0; i < _playersList.Count && i < _playersList.Capacity; ++i)
            {
                _playersList[i]._place = i + 1;
            }
            return;
        }
        
        static void SaveFile()
        {
            string path= @"Records.txt";
   
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                for (int i = 0; i < _playersList.Count && i<_playersList.Capacity; ++i)
                {
                    sw.WriteLine(_playersList[i].toString());
                }
                sw.Close();
            }
            return;
        }

        static public void Logic(Player player)
        {
            ReadFile();
            AddPlayer(player);
            SaveFile();
        }
        
        public static void WriteRecords()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(cWnd.xmax/2, cWnd.ymin + 3);
            Console.WriteLine("You lose!");
            Console.WriteLine("Records: ");
            for (int i = 0; i < _playersList.Count && i < _playersList.Capacity; ++i)
            {
                Console.SetCursorPosition(cWnd.xmin + 2, cWnd.ymin + 5 +i);
                Console.WriteLine(_playersList[i].toString());
            }
            return;
        }
    }
}