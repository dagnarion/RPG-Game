using System;
using UnityEngine;

[Serializable]
public class ParallaxLayer
{
  [SerializeField] private Transform layerPosition;
  [SerializeField] private float parallaxMultipiler;

  public void Move(float Distance)
  {
    layerPosition.position += Vector3.right * Distance * parallaxMultipiler;
  }
}
