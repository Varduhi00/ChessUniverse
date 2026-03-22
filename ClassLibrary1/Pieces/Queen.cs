using Chessuniverse.Library;
using ChessUniverse.Library;

namespace ChessUniverse.Library.Pieces;

public class Queen(PieceColor color) : Piece(color, PieceType.Queen), IMovable
{
    public override char GetSymbol()
    {
        return color == PieceColor.White ? 'Q' : 'q';
    }

    public bool Move(Coordinate start, Coordinate end, ChessBoard board)
    {
       
        bool isDiagonal = Math.Abs(start.Letter - end.Letter) == Math.Abs(start.Number - end.Number);
        bool isStraight = start.Letter == end.Letter || start.Number == end.Number;

        if (!isDiagonal && !isStraight)
        {
            Console.WriteLine("Invalid move for Queen");
            return false;
        }

     
        int rowStep = (end.Number == start.Number) ? 0 : (end.Number > start.Number ? 1 : -1);
        int colStep = (end.Letter == start.Letter) ? 0 : (end.Letter > start.Letter ? 1 : -1);

        int currentRow = (int)start.Number + rowStep;
        int currentCol = (int)start.Letter + colStep;
        while (currentRow != (int)end.Number || currentCol != (int)end.Letter)
        {
            if (board[currentRow, currentCol] != null)
            {
                Console.WriteLine("Path is blocked");
                return false;
            }
            currentRow += rowStep;
            currentCol += colStep;
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
}