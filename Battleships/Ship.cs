namespace Battleships;

public class Ship
{
    private readonly Tile[] _tiles;

    public Ship(Tile[] tiles)
    {
        _tiles = tiles;
    }

    public bool IsSunk => _tiles.All(t => t.HasBeenHit);

    public void Attack((int, int) guessCoordinates)
    {
        foreach (var tile in _tiles)
        {
            tile.Attack(guessCoordinates);
        }
    }
}