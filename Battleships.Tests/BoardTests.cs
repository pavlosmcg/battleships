using static Battleships.Orientation;

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
    public void PlayerHasLost_ReturnsFalse_WhenThereAreShipsRemaining()
    {
        // arrange
        var unit = new Board();
        var ship = new Ship(new[] { new Tile((1, 1)) });
        unit.TryAddShip(ship);
        
        // act
        var result = unit.PlayerHasLost;

        // assert
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void PlayerHasLost_ReturnsTrue_WhenAllShipsHaveBeenSunk()
    {
        // arrange
        var unit = new Board();
        var ship = new Ship(new[] { new Tile((1, 1)) });
        unit.TryAddShip(ship);
        
        // act
        unit.Attack((1, 1));
        var result = unit.PlayerHasLost;

        // assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void TryAddShip_ReturnsTrue_WhenShipIsOnBoard()
    {
        // arrange
        var ship = new ShipBuilder()
            .WithStartPosition((2, 2))
            .WithLength(6)
            .Build();
        var unit = new Board();

        // act
        var result = unit.TryAddShip(ship);

        // assert
        Assert.That(result, Is.True);
    }
    
    [Test]
    public void TryAddShip_ReturnsFalse_WhenShipIsOutOfBounds()
    {
        // arrange
        var ship = new ShipBuilder()
            .WithStartPosition((8, 8))
            .WithLength(6)
            .Build();
        var unit = new Board();

        // act
        var result = unit.TryAddShip(ship);

        // assert
        Assert.That(result, Is.False);
    }
    
    [Test]
    public void TryAddShip_ReturnsFalse_WhenShipOverLapsAnExistingShip()
    {
        // arrange
        var firstShip = new ShipBuilder() // first to place, so OK
            .WithStartPosition((1, 1))
            .WithOrientation(Horizontal)
            .WithLength(5)
            .Build();
        var secondShip = new ShipBuilder() // overlaps with first ship and third ship
            .WithStartPosition((3, 1))
            .WithOrientation(Vertical)
            .WithLength(5)
            .Build();
        var thirdShip = new ShipBuilder() // does not overlap with first ship
            .WithStartPosition((1, 2))
            .WithOrientation(Horizontal)
            .WithLength(5)
            .Build();
        var unit = new Board();

        // act
        var firstShipPlaced = unit.TryAddShip(firstShip);
        var secondShipPlaced = unit.TryAddShip(secondShip);
        var thirdShipPlaced = unit.TryAddShip(thirdShip);

        // assert
        Assert.That(firstShipPlaced, Is.True);
        Assert.That(secondShipPlaced, Is.False);
        Assert.That(thirdShipPlaced, Is.True);
    }
}