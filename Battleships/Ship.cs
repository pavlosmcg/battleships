namespace Battleships;

public class Ship
{
    private readonly Tile[] _tiles;

    public Ship(Tile[] tiles)
    {
        _tiles = tiles;
    }

    public bool IsSunk => _tiles.All(t => t.HasBeenHit);

    public AttackResult Attack((int, int) guessCoordinates)
    {
        var result = AttackResult.Miss;
        foreach (var tile in _tiles)
        {
            if (tile.Attack(guessCoordinates) == AttackResult.Hit)
            {
                result = AttackResult.Hit;
            }
        }

        return result;
    }
}