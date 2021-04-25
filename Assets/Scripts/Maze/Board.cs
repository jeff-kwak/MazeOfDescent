using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board
{
  public int Cols { get; }
  public int Rows { get; }
  
  private Cell[] cells;

  public Board(int cols, int rows)
  {
    Rows = rows;
    Cols = cols;
    cells = new Cell[rows * cols];
    for (int r = 0; r < rows; r++)
    {
      for (int c = 0; c < cols; c++)
      {
        cells[IndexOf(c, r)] = new Cell(c, r);
      }
    }
  }

  public Cell RandomCell => cells[Random.Range(0, Rows * Cols)];

  public int IndexOf(int col, int row) => row * Cols + col; 

  public Cell this[int x, int y]
  {
    get
    {
      if (x < 0 || x >= Cols) return null;
      if (y < 0 || y >= Rows) return null;

      return cells[IndexOf(x, y)];
    }
  }

  public Cell NorthOf(Cell c) => this[c.Col, c.Row + 1];
  public Cell SouthOf(Cell c) => this[c.Col, c.Row - 1];
  public Cell EastOf(Cell c) => this[c.Col + 1, c.Row];
  public Cell WestOf(Cell c) => this[c.Col - 1, c.Row];

  public IEnumerable<Cell> NeighborsOf(Cell c)
  {
    return new[] { NorthOf(c), SouthOf(c), EastOf(c), WestOf(c) }.Where(c => c != null);
  }
}
