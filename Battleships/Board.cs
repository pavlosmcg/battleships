using static Battleships.AttackResult;

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
        var isValidPlacement = ship.IsWithinBoardBounds(_boardSizeX, _boardSizeY)
                      && !ShipOverlapsExistingShips(ship);
        
        if (isValidPlacement)
            _ships.Add(ship);
        
        return isValidPlacement;
    }
    
    private bool ShipOverlapsExistingShips(Ship newShipToAdd)
    {
        var existingTiles = _ships.SelectMany(s => s.Tiles);
        return newShipToAdd.Tiles.Any(t => existingTiles.Any(ot => ot.Position == t.Position));
    }

    public AttackResult Attack((int, int) guessCoordinates)
    {
        return _ships.Any(s => s.Attack(guessCoordinates) == Hit) ? Hit : Miss;
    }
}