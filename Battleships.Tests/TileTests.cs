using static Battleships.AttackResult;

namespace Battleships.Tests;

public class TileTests
{
    [Test]
    public void Attack_ReturnsHit_WhenTileHasBeenAttackedWithCorrectCoordinates()
    {
        // arrange
        var tile = new Tile((1, 1));
        
        // act
        var result = tile.Attack((1, 1));

        // assert
        Assert.That(result, Is.EqualTo(Hit));
        Assert.That(tile.HasBeenHit, Is.True);
    }
    
    [Test]
    public void Attack_ReturnsMiss_WhenTileHasBeenMissed()
    {
        // arrange
        var tile = new Tile((1, 1));
        
        // act
        var result = tile.Attack((5, 5));

        // assert
        Assert.That(result, Is.EqualTo(Miss));
        Assert.That(tile.HasBeenHit, Is.False);
    }
    
    [Test]
    public void Attack_ReturnsMiss_WhenTileHasBeenHitAlready_ButNowMissed()
    {
        // arrange
        var tile = new Tile((1, 1));
        
        // act
        tile.Attack((1, 1)); // hit
        var result = tile.Attack((5, 5));

        // assert
        Assert.That(result, Is.EqualTo(Miss));
        Assert.That(tile.HasBeenHit, Is.True); // still true because it was hit earlier
    }
    
    [Test]
    public void HasBeenHit_ReturnsFalse_WhenTileHasNotBeenAttacked()
    {
        // arrange
        var tile = new Tile((1, 1));
        
        // act
        // do nothing - no attacks yet

        // assert
        Assert.That(tile.HasBeenHit, Is.False);
    }
    
    [Test]
    public void HasBeenHit_ReturnsFalse_WhenTileHasBeenMissed()
    {
        // arrange
        var tile = new Tile((1, 1));
        
        // act
        tile.Attack((5, 5)); // missed
        tile.Attack((7, 7)); // missed

        // assert
        Assert.That(tile.HasBeenHit, Is.False);
    }
    
    [Test]
    public void HasBeenHit_ReturnsTrue_WhenTileHasBeenMissed_ThenSubsequentlyHit()
    {
        // arrange
        var tile = new Tile((1, 1));
        
        // act
        tile.Attack((5, 5)); // first miss
        tile.Attack((1, 1)); // then hit

        // assert
        Assert.That(tile.HasBeenHit, Is.True);
    }
    
    [Test]
    public void HasBeenHit_ReturnsTrue_WhenTileHasBeenHit_ThenSubsequentlyMissed()
    {
        // arrange
        var tile = new Tile((1, 1));
        
        // act
        tile.Attack((1, 1)); // hit
        tile.Attack((5, 5)); // miss
        tile.Attack((7, 7)); // miss

        // assert
        Assert.That(tile.HasBeenHit, Is.True);
    }
    
    [Test]
    public void HasBeenHit_ReturnsTrue_WhenTileHasBeenHitMultipleTimes()
    {
        // arrange
        var tile = new Tile((1, 1));
        
        // act
        tile.Attack((1, 1)); // hit
        tile.Attack((1, 1)); // hit

        // assert
        Assert.That(tile.HasBeenHit, Is.True);
    }
}