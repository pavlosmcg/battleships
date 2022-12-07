﻿namespace Battleships;

public class Ship
{
    public Tile[] Tiles { get; }

    public Ship(Tile[] tiles)
    {
        Tiles = tiles;
    }

    public bool IsSunk => Tiles.All(t => t.HasBeenHit);

    public AttackResult Attack((int, int) guessCoordinates)
    {
        var result = AttackResult.Miss;
        foreach (var tile in Tiles)
        {
            if (tile.Attack(guessCoordinates) == AttackResult.Hit)
            {
                result = AttackResult.Hit;
            }
        }

        return result;
    }

    public bool IsWithinBoardBounds(int boardSizeX, int boardSizeY)
    {
        return Tiles.All(t => IsOnBoard(t.Position, boardSizeX, boardSizeY));
    }
    
    private bool IsOnBoard((int x, int y) coordinates, int boardSizeX, int boardSizeY)
    {
        return coordinates.x > 0 && coordinates.x <= boardSizeX &&
               coordinates.y > 0 && coordinates.y <= boardSizeY;
    }
}