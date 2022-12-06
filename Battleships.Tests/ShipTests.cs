namespace Battleships.Tests;

public class ShipTests
{
    [Test]
    public void IsSunk_ReturnsFalse_WhenShipIsNewlyCreated()
    {
        // arrange
        var tiles = new[] { new Tile((1, 1)) };
        var unit = new Ship(tiles);

        // act
        var result = unit.IsSunk;

        // assert
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void IsSunk_ReturnsTrue_WhenAllTilesHaveBeenHit()
    {
        // arrange
        var tiles = new[] { new Tile((1, 1)) };
        var unit = new Ship(tiles);

        // act
        unit.Attack((1, 1));
        var result = unit.IsSunk;

        // assert
        Assert.That(result, Is.True);
    }
}