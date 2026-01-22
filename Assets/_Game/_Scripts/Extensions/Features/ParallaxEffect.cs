using System;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
  private Camera mainCam;
  [SerializeField] private ParallaxLayer[] backgrounds;
  private Vector3 lastPosition;

  private void Awake()
  {
    mainCam = Camera.main;
  }

  void LateUpdate()
  {
    Vector3 currentCameraPosition = mainCam.transform.position;
    float distance = currentCameraPosition.x - lastPosition.x;
    lastPosition = currentCameraPosition;
    for (int i = 0; i < backgrounds.Length; i++)
    {
      backgrounds[i].Move(distance);
    }
  }
  
}
