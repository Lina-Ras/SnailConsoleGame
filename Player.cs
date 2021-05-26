using System;
using System.Collections.Generic;
using System.Text;
namespace zaba
{
    public class Player
    {
        public int _place { set; get; }
        public string _name { set; get; }
        public int _score { set; get; }

        public  Player(){}
        public Player(string NameScore, bool flag) {
        string[] line = NameScore.Split(new char[] { ' ' });

        _place = int.Parse(line[0]);
        _name = line[1];
        _score = int.Parse(line[2]);
        }
        
        public Player(string name) {
            _place = 0;
            _name = name;
            _score = 7;
        }

        public string toString()
        {
            string[] values = new string[] { _place.ToString(), _name, _score.ToString()};
            String res = String.Join(" ", values);
            return res;
        }
    }
}