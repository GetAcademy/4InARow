using System.Collections.Generic;
using System.Linq;

namespace _4InARow.Model
{
    public class Game
    {
        public int Id { get; set; }
        public string Pieces { get; set; }

        public Game()
        {
            Pieces = string.Empty.PadLeft(49, ' ');
        }

        public void Move(int columnIndex)
        {
            var pieces = Pieces.ToCharArray();
            pieces[0] = '1';
            Pieces = new string(pieces);
        }
    }
}
