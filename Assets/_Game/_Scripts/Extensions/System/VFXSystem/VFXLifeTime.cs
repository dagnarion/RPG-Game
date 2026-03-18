using System;
using UnityEngine;

public class VFXLifeTime : MonoBehaviour
{
   [Header("CONFIG")] 
   [SerializeField] private float lifeTime;
   [SerializeField] private Color _color;
   private float lifeTimeCount;

   private void OnEnable()
   {
      lifeTimeCount = lifeTime;
   }

   private void Awake()
   {
      this.gameObject.GetComponent<SpriteRenderer>().color = _color;
   }

   private void Update()
   {
      lifeTimeCount -= Time.deltaTime;
      if (lifeTimeCount <= 0)
      {
         this.gameObject.SetActive(false);
      }
   }
}
