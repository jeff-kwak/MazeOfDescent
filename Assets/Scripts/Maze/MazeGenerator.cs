using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MazeGenerator : MonoBehaviour
{
  public Tilemap FloorTilemap;
  public Tilemap WallTilemap;
  public TileBase FloorTile;
  public TileBase WallTile;
  public int WallsPerFloor = 8;
  public int Rows = 5;
  public int Cols = 5;

  private Board board;

  private void Start()
  {
    Random.InitState(42);
    board = Generate(Cols, Rows);
    FloorTilemap.ClearAllTiles();
    WallTilemap.ClearAllTiles();
    DrawBoard(board);
  }

  private void DrawBoard(Board b)
  {
    for (int c = 0; c < b.Cols; c++)
    {
      for (int r = 0; r < b.Rows; r++)
      {
        FloorTilemap.SetTile(new Vector3Int(c, r, 0), FloorTile);
        var cell = b[c, r];
        DrawSouthWall(cell, c, r);
        DrawNorthWall(cell, c, r);
        DrawEastWall(cell, c, r);
        DrawWestWall(cell, c, r);
      }
    }
    FloorTilemap.SetTile(Vector3Int.zero, FloorTile);
    WallTilemap.SetTile(Vector3Int.zero, WallTile);
  }

  private void DrawSouthWall(Cell cell, int col, int row)
  {
    if (!cell.Links.Any(linkedCell => board.SouthOf(cell) == linkedCell))
    {
      for (int i = 0; i <= WallsPerFloor; i++)
      {
        WallTilemap.SetTile(new Vector3Int(col * WallsPerFloor + i, row * WallsPerFloor, 0), WallTile);
      }
    }
  }

  private void DrawNorthWall(Cell cell, int col, int row)
  {
    if (!cell.Links.Any(linkedCell => board.NorthOf(cell) == linkedCell))
    {
      for (int i = 0; i <= WallsPerFloor; i++)
      {
        WallTilemap.SetTile(new Vector3Int(col * WallsPerFloor + i, WallsPerFloor * (row + 1), 0), WallTile);
      }
    }
  }

  private void DrawEastWall(Cell cell, int col, int row)
  {
    if (!cell.Links.Any(linkedCell => board.EastOf(cell) == linkedCell))
    {
      for (int i = 0; i <= WallsPerFloor; i++)
      {
        WallTilemap.SetTile(new Vector3Int(WallsPerFloor * (col + 1), row * WallsPerFloor + i, 0), WallTile);
      }
    }
  }

  private void DrawWestWall(Cell cell, int col, int row)
  {
    if (!cell.Links.Any(linkedCell => board.WestOf(cell) == linkedCell))
    {
      for (int i = 0; i <= WallsPerFloor; i++)
      {
        WallTilemap.SetTile(new Vector3Int(WallsPerFloor * col, row * WallsPerFloor + i, 0), WallTile);
      }
    }
  }
  private Board Generate(int cols, int rows)
  {
    var board = new Board(cols, rows);

    var stack = new Stack<Cell>();
    stack.Push(board.RandomCell);

    while (stack.Any())
    {
      var current = stack.Peek();
      var unvisitedNeighbors = board.NeighborsOf(current).Where(n => !n.Links.Any());
      if (!unvisitedNeighbors.Any())
      {
        stack.Pop();
        continue;
      }

      var neighbor = unvisitedNeighbors.PickOne();
      current.Link(neighbor);
      stack.Push(neighbor);
    }

    return board;
  }
}
