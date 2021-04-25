using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class MazeSequenceExtensions
{
  public static T PickOne<T>(this IEnumerable<T> collection)
  {
    var arr = collection.ToArray();
    return arr[Random.Range(0, arr.Length)];
  }
}
