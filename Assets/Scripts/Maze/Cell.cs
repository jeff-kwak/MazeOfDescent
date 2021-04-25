using System.Collections.Generic;

public class Cell
{
  public int Col { get; }
  public int Row { get; }
  public IList<Cell> Links { get; }

  public Cell(int col, int row)
  {
    Col = col;
    Row = row;
    Links = new List<Cell>();
  }

  public void Link(Cell otherCell)
  {
    Links.Add(otherCell);
    otherCell.Links.Add(this);
  }
} 
