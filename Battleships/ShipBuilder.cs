namespace Battleships;

public class ShipBuilder
{
    private (int x, int y) _startPosition = (1, 1);
    private int _length = 1;
    private Orientation _orientation = Orientation.Horizontal;

    public ShipBuilder WithStartPosition((int x, int y) start)
    {
        _startPosition = start;
        return this;
    }
    
    public ShipBuilder WithLength(int lengthOfTiles)
    {
        if (lengthOfTiles <= 0)
            throw new ArgumentOutOfRangeException(nameof(lengthOfTiles), "Ship length must be a positive number");
        
        _length = lengthOfTiles;
        return this;
    }

    public ShipBuilder WithOrientation(Orientation orientation)
    {
        _orientation = orientation;
        return this;
    }
    
    public Ship Build()
    {
        var tiles = new List<Tile>();
        for (int i = 0; i < _length; i++)
        {
            if (_orientation == Orientation.Horizontal)
            {
                tiles.Add(new Tile((_startPosition.x + i, _startPosition.y)));
            }
            else
            {
                tiles.Add(new Tile((_startPosition.x, _startPosition.y + i)));
            }
        }
        
        return new Ship(tiles.ToArray());
    }
}