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
        var ship = new ShipBuilder().Build();
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
        unit.TryAddShip(new ShipBuilder().WithStartPosition((1, 1)).Build());
        unit.TryAddShip(new ShipBuilder().WithStartPosition((4, 4)).Build());
        
        // act
        unit.Attack((1, 1));
        unit.Attack((4, 4));
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
    public void TryAddShip_ReturnsExpectedResult_WhenShipOverLapsAnExistingShip()
    {
        // arrange
        var firstShip = new ShipBuilder().WithStartPosition((1, 1)).WithOrientation(Horizontal).WithLength(5).Build();
        var secondShip = new ShipBuilder().WithStartPosition((3, 1)).WithOrientation(Vertical).WithLength(5).Build();
        var thirdShip = new ShipBuilder().WithStartPosition((1, 2)).WithOrientation(Horizontal).WithLength(5).Build();
        var unit = new Board();

        // act
        var firstShipPlaced = unit.TryAddShip(firstShip);  // first to place, so OK
        var secondShipPlaced = unit.TryAddShip(secondShip); // overlaps with first ship
        var thirdShipPlaced = unit.TryAddShip(thirdShip); // overlaps with the second ship

        // assert
        Assert.That(firstShipPlaced, Is.True); // successfully added first
        Assert.That(secondShipPlaced, Is.False);
        Assert.That(thirdShipPlaced, Is.True); // successfully added third, since the second was not added
    }

    [Test]
    [TestCase(1,1,true)]
    [TestCase(3,1,true)]
    [TestCase(8,8,true)]
    [TestCase(4,8,true)]
    [TestCase(10,10,false)]
    [TestCase(5,5,false)]
    public void Attack_ReturnsExpectedResult(int guessX, int guessY, bool expectedHit)
    {
        // arrange
        var unit = new Board();
        unit.TryAddShip(new ShipBuilder().WithStartPosition((1, 1)).WithLength(5).Build());
        unit.TryAddShip(new ShipBuilder().WithStartPosition((1, 8)).WithLength(10).Build());
        
        // act
        var result = unit.Attack((guessX, guessY));

        // assert
        Assert.That(result == AttackResult.Hit, Is.EqualTo(expectedHit));
    }
    
}