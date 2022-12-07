namespace Battleships.Tests;

public class BoardTests
{
    [Test]
    public void PlayerHasLost_ReturnsFalse_ForANewGame()
    {
        // arrange
        var unit = new Board();

        // act
        var result = unit.PlayerHasLost;

        // assert
        Assert.That(result, Is.False);
    }
    
    [Test]
    [TestCase(1,1)]
    [TestCase(5,5)]
    [TestCase(10,10)]
    public void TryAddShip_ReturnsTrue_WhenShipIsOnBoard(int tileX, int tileY)
    {
        // arrange
        var unit = new Board();
        var ship = new Ship(new[] { new Tile((tileX, tileY)) });

        // act
        var result = unit.TryAddShip(ship);

        // assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    [TestCase(0,0)]
    [TestCase(0,1)]
    [TestCase(5,11)]
    public void TryAddShip_ReturnsFalse_WhenShipIsOutOfBounds(int tileX, int tileY)
    {
        // arrange
        var unit = new Board();
        var ship = new Ship(new[] { new Tile((tileX, tileY)) });

        // act
        var result = unit.TryAddShip(ship);

        // assert
        Assert.That(result, Is.False);
    }
}