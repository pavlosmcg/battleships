namespace Battleships;

public class Tile
{
    public Tile((int x, int y) coordinates)
    {
        X = coordinates.x;
        Y = coordinates.y;
        HasBeenHit = false;
    }
    
    public int X { get; }
    public int Y { get; }
    
    public bool HasBeenHit { get; private set; }

    public void Attack((int x, int y) guessCoordinates)
    {
        if (guessCoordinates.x == X && guessCoordinates.y == Y)
        {
            HasBeenHit = true;
        }
    }
}