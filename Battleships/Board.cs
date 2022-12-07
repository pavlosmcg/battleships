namespace Battleships;

public class Board
{
    private readonly int _boardSizeX = 10;
    private readonly int _boardSizeY = 10;
    private readonly List<Ship> _ships;

    public Board()
    {
        _ships = new List<Ship>();
    }

    public bool PlayerHasLost => _ships.Any() && _ships.All(s => s.IsSunk);

    public bool TryAddShip(Ship ship)
    {
        if (!ship.IsWithinBoardBounds(_boardSizeX, _boardSizeY))
        {
            return false;
        }
        
        _ships.Add(ship);
        return true;
    }

    public void Attack((int, int) guessCoordinates)
    {
        foreach (var ship in _ships)
        {
            ship.Attack(guessCoordinates);
        }
    }
}