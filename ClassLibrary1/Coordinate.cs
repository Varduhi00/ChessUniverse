using ChessUniverse.Library;

namespace Chessuniverse.Library;

public struct Coordinate(Letter letter, Numbers number)
{
    public Letter Letter = letter;
    public Numbers Number = number;
}