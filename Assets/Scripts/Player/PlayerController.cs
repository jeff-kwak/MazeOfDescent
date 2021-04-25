using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
  public ControlBusDefinition ControlBus;
  public float Speed = 2f;

  private Rigidbody2D rb;
  private Vector2 movementInput;

  public void Go(Vector3 position)
  {
    transform.SetPositionAndRotation(position, transform.rotation);
  }

  private void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    ControlBus.Moved += ControlBus_Moved;
  }

  private void OnDestroy()
  {
    ControlBus.Moved -= ControlBus_Moved;
  }

  private void FixedUpdate()
  {
    rb.MovePosition((Vector2)transform.position + movementInput * Speed * Time.fixedDeltaTime);
  }

  private void ControlBus_Moved(Vector2 value)
  {
    movementInput = value;
  }

}
