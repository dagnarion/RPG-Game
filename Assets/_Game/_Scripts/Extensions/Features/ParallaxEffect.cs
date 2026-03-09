using System;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
  private Camera mainCam;
  [SerializeField] private ParallaxLayer[] backgrounds;
  private Vector3 lastPosition;
  private float cameraHalfWidth;
  private void Awake()
  {
    mainCam = Camera.main;
    cameraHalfWidth = mainCam.orthographicSize * mainCam.aspect;
    //orthographicSize: nửa chiều cao của camera, aspect: tỉ lệ width/height của màn hình => trả về nửa chiều rộng cam
  }


  void FixedUpdate()
  {
    Vector3 currentCameraPosition = mainCam.transform.position;
    float distance = currentCameraPosition.x - lastPosition.x;
    lastPosition = currentCameraPosition;
    float leftEdge = currentCameraPosition.x - cameraHalfWidth;
    float rightEdge = currentCameraPosition.x + cameraHalfWidth;
    for (int i = 0; i < backgrounds.Length; i++)
    {
      backgrounds[i].Move(distance); 
      backgrounds[i].LoopLayer(mainCam.transform.position);
    }
  }

  
}
