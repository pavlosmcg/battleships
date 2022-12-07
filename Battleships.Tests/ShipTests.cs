using static Battleships.AttackResult;

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
    public void Attack_ReturnsHit_WhenGuessHitsATile()
    {
        // arrange
        var tiles = new[] { new Tile((1, 1)) };
        var unit = new Ship(tiles);

        // act
        var result = unit.Attack((1, 1));

        // assert
        Assert.That(result, Is.EqualTo(Hit));
    }
    
    [Test]
    public void Attack_ReturnsMiss_WhenGuessMissesAllTiles()
    {
        // arrange
        var tiles = new[] { new Tile((1, 1)) };
        var unit = new Ship(tiles);

        // act
        var result = unit.Attack((5, 5));

        // assert
        Assert.That(result, Is.EqualTo(Miss));
    }
    
    [Test]
    public void IsSunk_ReturnsTrue_WhenAllTilesHaveBeenHit()
    {
        // arrange
        var tiles = new[] { new Tile((1, 1)) };
        var unit = new Ship(tiles);

        // act
        unit.Attack((1, 1));

        // assert
        Assert.That(unit.IsSunk, Is.True);
    }
    
    [Test]
    public void IsSunk_ReturnsFalse_WhenOnlySomeTilesHaveBeenHit()
    {
        // arrange
        var tiles = new[] { new Tile((1, 1)), new Tile((1, 2)) };
        var unit = new Ship(tiles);

        // act
        unit.Attack((1, 1));

        // assert
        Assert.That(unit.IsSunk, Is.False);
    }

    [Test]
    [TestCase(1,1, true)]
    [TestCase(10,10, true)]
    [TestCase(0,0, false)]
    [TestCase(1,-99, false)]
    public void IsWithinBoardBounds_ReturnsExpectedResult(int x, int y, bool expected)
    {
        // arrange
        var tiles = new[] { new Tile((x, y)) };
        var unit = new Ship(tiles);

        // act
        var result = unit.IsWithinBoardBounds(10, 10);

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }
}