using static Battleships.AttackResult;
using static Battleships.Orientation;

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
    [TestCase(1,1, 1, true)]
    [TestCase(1,1, 10, true)]
    [TestCase(1,2, 10, false)]
    [TestCase(1,1, 11, false)]
    [TestCase(5,8, 5, false)]
    [TestCase(10,10, 1, true)]
    [TestCase(0,0, 1, false)]
    [TestCase(0,3, 5, false)]
    [TestCase(1,-99, 5, false)]
    public void IsWithinBoardBounds_ReturnsExpectedResult(int startX, int startY, int length, bool expected)
    {
        // arrange
        var unit = new ShipBuilder()
            .WithStartPosition((startX, startY))
            .WithOrientation(Vertical)
            .WithLength(length)
            .Build();

        // act
        var result = unit.IsWithinBoardBounds(10, 10);

        // assert
        Assert.That(result, Is.EqualTo(expected));
    }
}