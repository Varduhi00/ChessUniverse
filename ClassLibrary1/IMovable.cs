using Chessuniverse.Library;

namespace ChessUniverse.Library;
public interface IMovable
{
    bool Move(Coordinate start, Coordinate end, ChessBoard board);
}
