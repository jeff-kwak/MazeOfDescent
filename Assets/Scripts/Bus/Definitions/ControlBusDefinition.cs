using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ControlBusDefinition : ScriptableObject
{
  public event BusHandler<Vector2> Moved;

  public void Move(Vector2 value)
  {
    Moved?.Invoke(value);
  }
}
