using Chessuniverse.Library;

namespace ChessUniverse.Library;

public class Knight(PieceColor color) : Piece(color, PieceType.Knight), IMovable
{
    public override char GetSymbol()
    {
        return color == PieceColor.White ? 'N' : 'n';
    }
    public bool Move(Coordinate start, Coordinate end, ChessBoard board)
    {
        bool CanMove= ((Math.Abs(start.Letter - end.Letter) == 1) && (Math.Abs(start.Number - end.Number) == 2)) ||
            ((Math.Abs(start.Letter - end.Letter) == 2) && (Math.Abs(start.Number - end.Number) == 1));
        if (CanMove)
        {
            if (board[(int)end.Number, (int)end.Letter] != null &&
                 board[(int)end.Number, (int)end.Letter].Color == this.Color)
            {
                Console.WriteLine("Knight Can't move to a square occupied by a piece of the same color");
                return false;
            }
            board[(int)end.Number, (int)end.Letter] = this;
            board[(int)start.Number, (int)start.Letter] = null;
            return true;
        }
        return false;
    }
}
