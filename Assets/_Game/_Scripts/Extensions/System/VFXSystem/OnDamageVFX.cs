using System.Collections;
using UnityEngine;

public class OnDamageVFX : MonoBehaviour,IVFX
{
   [Header("CONFIG")] 
   [SerializeField] private float duration;
   [Header("REFERENCE")]
   [SerializeField] private Material originMaterial;
   [SerializeField] private Material onHitMaterial;
   [SerializeField] private SpriteRenderer objectToApply;
   private Coroutine EffectCo;
   
   public void ApplyEffect(Transform position)
   {
      if (EffectCo != null)
      {
         StopCoroutine(EffectCo);
      }
      EffectCo = StartCoroutine(TakeEffect(duration));
   }

   public void RemoveEffect()
   {
      if (EffectCo != null)
      {
         StopCoroutine(EffectCo);
      }
      objectToApply.material = originMaterial;
   }

   IEnumerator TakeEffect(float duration)
   {
      objectToApply.material = onHitMaterial;
      yield return new WaitForSeconds(duration);
      objectToApply.material = originMaterial;
   }

}
