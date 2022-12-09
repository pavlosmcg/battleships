# battleships

### Building and running tests
With .Net >= 6 installed, build with `dotnet build`

Run the unit tests with `dotnet test`

### Example usage
To create a board for a single player:

`var board = new Board();`

To add a ship, you can specify the tiles/squares directly using the `Ship` and `Tile` constructors, or take the easy route with the `ShipBuilder` like so:

```
var ship = new ShipBuilder()
    .WithLength(5)
    .WithOrientation(Orientation.Vertical)
    .WithStartPosition((2, 2))
    .Build();
```

Then add the ship to the board with:

`board.TryAddShip(ship);`

Continue adding ships this way, and `TryAddShip` will return a boolean representing whether the ship was added (if its position was valid)

To take an attack, supply a tuple of coordinates (x,y) to the attack method like so:
`board.Attack((2, 5));`

Repeat until done. You'll be done when `board.PlayerHasLost;` returns `true`.
