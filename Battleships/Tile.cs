namespace Battleships;

public class Tile
{
    public Tile((int x, int y) position)
    {
        Position = position;
        HasBeenHit = false;
    }
    
    public (int x, int y) Position { get; }

    public bool HasBeenHit { get; private set; }

    public AttackResult Attack((int x, int y) guessCoordinates)
    {
        if (guessCoordinates == Position)
        {
            HasBeenHit = true;
            return AttackResult.Hit;
        }

        return AttackResult.Miss;
    }
}