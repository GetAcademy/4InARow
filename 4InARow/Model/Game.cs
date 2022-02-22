using System.Collections.Generic;
using System.Linq;

namespace _4InARow.Model
{
    public class Game
    {
        public int Id { get; set; }
        public char[] Pieces { get; set; }
        //public bool? Pieces { get; set; }

        public Game()
        {
            Pieces = Enumerable.Repeat(' ', 49).ToArray();
        }

        public void Move(int columnIndex)
        {
            Pieces[0] = '1';
        }
    }
}
