using Chessuniverse.Library;
using ChessUniverse;
using ChessUniverse.Library;
using ChessUniverse.Library.Pieces;
using System.Collections;
using static System.Console;

ChessBoard chessboard = new ChessBoard();
chessboard.SetStartPosition();
PrintBaord(chessboard);
Input();

void PrintBaord(ChessBoard chessBoard)
{

    Console.WriteLine("   a  b  c  d  e  f  g  h");
    for (int row = 0; row < 8; row++)
    {
        {
            Write($"{8 - row} ");
            for (int col = 0; col < 8; col++)
            {
                bool isLightSquare = (row + col) % 2 == 0;
                Console.BackgroundColor = isLightSquare ? ConsoleColor.Gray : ConsoleColor.DarkGray;
                Console.ForegroundColor = isLightSquare ? ConsoleColor.Black : ConsoleColor.White;
                var piece = chessboard[row, col];
                char symbol = piece?.GetSymbol() ?? '.';

                Write($" {symbol} ");

            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}

void Input()
{
    WriteLine("Enter the start position");
    string source = Console.ReadLine();
    WriteLine("Enter the end position");
    string target = Console.ReadLine();
    Coordinate start = new Coordinate((Letter)source[0] - 'A', (Numbers)('8' - source[1]));
    Coordinate end = new Coordinate((Letter)target[0] - 'A', (Numbers)('8' - target[1]));
    switch (chessboard[(int)start.Number, (int)start.Letter])
    {
        case Bishop:
            BishopMove(start, end);
            break;
        case King:
            KingMove(start, end);
            break;
        case Knight:
            KnightMove(start, end);
            break;
        case Pawn:
            PawnMove(start, end);
            break;
        case Queen:
            QueenMove(start, end);
            break;
        case Rook:
            RookMove(start, end);
            break;
        default:
            WriteLine("There is no piece at the starting position.");
            break;
    }
}
#region bishop_move
void BishopMove(Coordinate start, Coordinate end)
{

    var piece = chessboard[(int)start.Number, (int)start.Letter];


    if (piece is Bishop bishop)
    {
        if (bishop.Move(start, end, chessboard))
        {
            Console.Clear();
            PrintBaord(chessboard);
            WriteLine("Bishop moved.");
        }
    }
    else
    {
        Console.WriteLine("There is no Bishop at the starting position.");
    }
}
#endregion

#region king_move
void KingMove(Coordinate start, Coordinate end)
{
    var piece = chessboard[(int)start.Number, (int)start.Letter];
    if (piece is King king)
    {
        if (king.Move(start, end, chessboard))
        {
            Console.Clear();
            PrintBaord(chessboard);
            WriteLine("King moved.");
        }
    }
    else
    {
        Console.WriteLine("There is no King at the starting position.");
    }
}

#endregion

#region
void KnightMove(Coordinate start, Coordinate end)
{
    var piece = chessboard[(int)start.Number, (int)start.Letter];
    if (piece is Knight knight)
    {
        if (knight.Move(start, end, chessboard))
        {
            Console.Clear();
            PrintBaord(chessboard);
            WriteLine("Knight moved.");
        }
    }
    else
    {
        Console.WriteLine("There is no Knight at the starting position.");
    }
}

#endregion


#region pawn_move
void PawnMove(Coordinate start, Coordinate end)
{
    var piece = chessboard[(int)start.Number, (int)start.Letter];
    if (piece is Pawn pawn)
    {
        if (pawn.Move(start, end, chessboard))
        {
            Console.Clear();
            PrintBaord(chessboard);
            WriteLine("Pawn moved.");
        }
    }
    else
    {
        Console.WriteLine("There is no Pawn at the starting position.");
    }
}
#endregion

#region queen_move
void QueenMove(Coordinate start, Coordinate end)
{
    var piece = chessboard[(int)start.Number, (int)start.Letter];
    if (piece is Queen queen)
    {
        if (queen.Move(start, end, chessboard))
        {
            Console.Clear();
            PrintBaord(chessboard);
            WriteLine("Queen moved.");
        }
    }
    else
    {
        Console.WriteLine("There is no Queen at the starting position.");
    }
}
#endregion

#region rook_move
void RookMove(Coordinate start, Coordinate end)
{
    var piece = chessboard[(int)start.Number, (int)start.Letter];
    if (piece is Rook rook)
    {
        if (rook.Move(start, end, chessboard))
        {
            Console.Clear();
            PrintBaord(chessboard);
            WriteLine("Rook moved.");
        }
    }
    else
    {
        Console.WriteLine("There is no Rook at the starting position.");
    }
}
#endregion