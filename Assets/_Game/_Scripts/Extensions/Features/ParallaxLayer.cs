using System;
using UnityEngine;

[Serializable]
public class ParallaxLayer
{
  [SerializeField] private Transform layerPosition;
  [SerializeField] private float parallaxMultipiler;
  [SerializeField] private float offSet;
  public void Move(float Distance)
  {
    layerPosition.position += Vector3.right * Distance * parallaxMultipiler;
  }

  public void LoopLayer(Vector3 cameraPosition)
  {
      if (Mathf.Abs(layerPosition.position.x - cameraPosition.x) > offSet)
      {
          layerPosition.position = new Vector3(cameraPosition.x,layerPosition.position.y,layerPosition.position.z);
          return;
      }
  }
}
