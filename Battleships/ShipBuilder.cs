namespace Battleships;

public class ShipBuilder
{
    private List<Tile> _tiles = new() { new Tile((1, 1)) };
    private (int x, int y) _startPosition = (1, 1);

    public ShipBuilder WithStartPosition((int x, int y) start)
    {
        _startPosition = start;
        _tiles = new() { new Tile(start) };
        return this;
    }
    
    public ShipBuilder WithLength(int lengthOfTiles)
    {
        _tiles = new List<Tile>();
        for (int i = 0; i < lengthOfTiles; i++)
        {
            _tiles.Add(new Tile((_startPosition.x + i, _startPosition.y)));
        }
        return this;
    }

    public Ship Build()
    {
        return new Ship(_tiles.ToArray());
    }
}