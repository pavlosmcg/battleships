namespace Battleships;

public class Ship
{
    public Tile[] Tiles { get; }

    public Ship(Tile[] tiles)
    {
        Tiles = tiles;
    }

    public bool IsSunk => Tiles.All(t => t.HasBeenHit);

    public AttackResult Attack((int, int) guessCoordinates)
    {
        var result = AttackResult.Miss;
        foreach (var tile in Tiles)
        {
            if (tile.Attack(guessCoordinates) == AttackResult.Hit)
            {
                result = AttackResult.Hit;
            }
        }

        return result;
    }
}