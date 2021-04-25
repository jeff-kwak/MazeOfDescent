using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
  public GameObject Player;
  public GameObject Maze;

  private PlayerController player;
  private MazeGenerator maze;

  private void Awake()
  {
    player = Player.GetComponent<PlayerController>();
    maze = Maze.GetComponent<MazeGenerator>();
  }

  private void Start()
  {
    maze.ResetBoard(5, 5);
    player.Go(maze.RandomCellPosition());
  }
}
