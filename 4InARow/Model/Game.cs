using System.Collections.Generic;

namespace _4InARow.Model
{
    public class Game
    {
        public int Id { get; set; }
        public Piece[] Pieces { get; set; }
        //public bool? Pieces { get; set; }

        public Game()
        {
            Pieces = new Piece[49];
        }
    }
}
