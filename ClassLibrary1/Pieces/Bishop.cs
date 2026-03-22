using Chessuniverse.Library;
using System.ComponentModel.Design;
using System.Threading.Channels;

namespace ChessUniverse.Library.Pieces;

public class Bishop(PieceColor color) : Piece(color, PieceType.Bishop), IMovable
{
    public override char GetSymbol()
    {
        return color == PieceColor.White ? 'B' : 'b';
    }
    public bool Move(Coordinate start, Coordinate end, ChessBoard board)
    {
        bool CanMove = (Math.Abs(start.Letter - end.Letter) == Math.Abs(start.Number - end.Number));
        if (board[(int)start.Number, (int)start.Letter] == null)
        {
            Console.WriteLine("There is no piece in the start position");
            return false;
        }
        if (CanMove)
        {

            int rowstep = (start.Number < end.Number) ? 1 : -1;
            int colstep = (start.Letter < end.Letter) ? 1 : -1;
            int currentrow = (int)start.Number + rowstep;
            int currentcol = (int)start.Letter + colstep;
            while (currentrow != (int)end.Letter && currentcol != (int)end.Number)
            {
                if (board[currentrow, currentcol] != null)
                {
                    Console.WriteLine("There is a piece in the way");
                    return false;
                }
                currentrow += rowstep;
                currentcol += colstep;
            }
            var targetPiece = board[(int)end.Letter, (int)end.Number];
            if (targetPiece != null && targetPiece.Color == this.Color)
            {
                Console.WriteLine("cannot capture your own piece");
            }
            board[(int)end.Number, (int)end.Letter] = this;
            board[(int)start.Number, (int)start.Letter] = null;
            return true;
        }
        else
        {
            return false;
        }
    }
}
