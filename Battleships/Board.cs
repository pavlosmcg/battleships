namespace Battleships;

public class Board
{
    private int _boardSizeX = 10;
    private int _boardSizeY = 10;
    public bool PlayerHasLost => false;

    public bool TryAddShip(Ship ship)
    {
        if (ship.Tiles.Any(t => !IsOnBoard(t.Position)))
        {
            return false;
        }
        return true;
    }

    private bool IsOnBoard((int x, int y) coordinates)
    {
        return coordinates.x > 0 && coordinates.x <= _boardSizeX &&
               coordinates.y > 0 && coordinates.y <= _boardSizeY;
    }
}