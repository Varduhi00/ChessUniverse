using Chessuniverse.Library;
using System.ComponentModel.Design;

namespace ChessUniverse.Library.Pieces;

public class King(PieceColor color) : Piece(color, PieceType.King), IMovable
{
    public override char GetSymbol()
    {
        return color == PieceColor.White ? 'K' : 'k';
    }
    public bool Move(Coordinate start, Coordinate end, ChessBoard board)
    {
        bool canMove = Math.Abs(start.Letter - end.Letter) <= 1 && Math.Abs(start.Number - end.Number) <= 1;
        if (canMove)
        {
            int DifOfLetters = Math.Abs(end.Letter - start.Letter);
            int DifOfNumbers = Math.Abs(end.Number - start.Number);
            if (DifOfLetters > 1 || DifOfNumbers > 1) return false;
            if (board[(int)end.Number, (int)end.Letter] != null && board[(int)end.Number, (int)end.Letter].Color == this.Color)
            {
                Console.WriteLine("King Can't move to a square occupied by a piece of the same color");
                return false;
                
            }
            board[(int)end.Number, (int)end.Letter] = this;
            board[(int)start.Number, (int)start.Letter] = null;
            return true;
        }
        return false;
    }

}

