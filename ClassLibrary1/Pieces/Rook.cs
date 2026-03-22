using Chessuniverse.Library;

namespace ChessUniverse.Library.Pieces;

public class Rook(PieceColor color) : Piece(color, PieceType.Rook), IMovable
{
    public override char GetSymbol()
    {
        return color == PieceColor.White ? 'R' : 'r';
    }
    public bool Move(Coordinate start, Coordinate end, ChessBoard board)
    {
        bool CanMove = start.Letter == end.Letter || start.Number == end.Number;
        if (CanMove)
        {
            int rowstep = 0;
            int colstep = 0;   
            if (end.Number != start.Number)
            {
                 rowstep = (start.Number > end.Number) ? -1 : 1;
            }
            if (end.Letter != start.Letter)
            {
                 colstep = (start.Letter > end.Letter) ? -1 : 1;
            }
               
            int currentCol = (int)start.Letter + colstep;
            int currentRow = (int)start.Number + rowstep;
            while (currentCol != (int)end.Letter || currentRow != (int)end.Number)
            {
                if (board[currentRow, currentCol] != null)
                {
                    Console.WriteLine("Path is blocked");
                    return false;
                }
                currentRow = currentRow + rowstep;
                currentCol = currentCol + colstep;
            }
            var targetPiece = board[(int)end.Number, (int)end.Letter];
            if (targetPiece != null && targetPiece.Color == this.Color)
            {
                Console.WriteLine("Cannot capture own piece");
                return false;
            }
            board[(int)end.Number, (int)end.Letter] = this;
            board[(int)start.Number, (int)start.Letter] = null;
            return true;
        }
        else
        {
            Console.WriteLine("Invalid move for Rook");
            return false;
        }
    }
}
