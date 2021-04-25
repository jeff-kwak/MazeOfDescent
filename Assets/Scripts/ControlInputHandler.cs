using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class ControlInputHandler : MonoBehaviour
{
  public ControlBusDefinition ControlBus;

  private void OnMove(InputValue value)
  {
    ControlBus.Move(value.Get<Vector2>());
  }
}
