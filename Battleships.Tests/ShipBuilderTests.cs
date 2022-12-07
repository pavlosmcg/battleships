namespace Battleships.Tests;

public class ShipBuilderTests
{
    [Test]
    public void Build_ReturnsDefaultSingleTileShipAtOrigin_WhenNoPropertiesAreSpecified()
    {
        // arrange
        var unit = new ShipBuilder();
        
        // act
        var result = unit.Build();
        
        // assert
        Assert.That(result.Tiles.Length, Is.EqualTo(1));
        Assert.That(result.Tiles[0].Position.x, Is.EqualTo(1));
        Assert.That(result.Tiles[0].Position.y, Is.EqualTo(1));
    }
    
    [Test]
    [TestCase(1)]
    [TestCase(5)]
    [TestCase(10)]
    public void Build_ReturnsShipWithExpectedLength_WhenLengthIsSpecified(int length)
    {
        // arrange
        var unit = new ShipBuilder();
        
        // act
        unit.WithLength(length);
        var result = unit.Build();
        
        // assert
        Assert.That(result.Tiles.Length, Is.EqualTo(length));
        Assert.That(result.Tiles.Last().Position.x, Is.EqualTo(length));
    }
    
    [Test]
    [TestCase(1,1)]
    [TestCase(5,5)]
    [TestCase(7,8)]
    public void Build_ReturnsShipWithExpectedStartPosition_WhenStartPositionIsSpecified(int startX, int startY)
    {
        // arrange
        var unit = new ShipBuilder();
        
        // act
        unit.WithStartPosition((startX, startY));
        var result = unit.Build();
        
        // assert
        Assert.That(result.Tiles[0].Position.x, Is.EqualTo(startX));
        Assert.That(result.Tiles[0].Position.y, Is.EqualTo(startY));
    }
    
    [Test]
    [TestCase(1,1,5)]
    [TestCase(9,9,2)]
    [TestCase(1,10,1)]
    public void Build_ReturnsShipWithExpectedLengthAndStartPosition_WhenBothAreSpecified(int startX, int startY, int length)
    {
        // arrange
        var unit = new ShipBuilder();
        
        // act
        unit.WithStartPosition((startX, startY));
        unit.WithLength(length);
        var result = unit.Build();
        
        // assert
        Assert.That(result.Tiles.Length, Is.EqualTo(length));
        Assert.That(result.Tiles.Last().Position.x, Is.EqualTo(startX + length - 1));
        Assert.That(result.Tiles.Last().Position.y, Is.EqualTo(startY));
    }
    
    [Test]
    [TestCase(1,1,5)]
    [TestCase(9,9,2)]
    [TestCase(1,10,1)]
    public void Build_ReturnsShipWithExpectedProperties_WhenOrientationIsVertical(int startX, int startY, int length)
    {
        // arrange
        var unit = new ShipBuilder();
        
        // act
        unit.WithStartPosition((startX, startY));
        unit.WithLength(length);
        unit.WithOrientation(Orientation.Vertical);
        var result = unit.Build();
        
        // assert
        Assert.That(result.Tiles.Length, Is.EqualTo(length));
        Assert.That(result.Tiles.Last().Position.x, Is.EqualTo(startX));
        Assert.That(result.Tiles.Last().Position.y, Is.EqualTo(startY + length - 1));
    }

    [Test]
    public void WithLength_ThrowsArgumentOutOfRangeException_WhenLengthOfShipIsZeroOrSmaller()
    {
        // arrange
        var unit = new ShipBuilder();
        
        // act
        void Action() => unit.WithLength(-4);
        
        // assert
        Assert.Throws<ArgumentOutOfRangeException>(Action);
    }
}