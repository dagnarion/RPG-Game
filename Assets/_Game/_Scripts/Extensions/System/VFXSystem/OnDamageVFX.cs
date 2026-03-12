using System;
using System.Collections;
using UnityEngine;

public class OnDamageVFX : IVFX
{
    private Material onDamageMaterial;
    private Material originMaterial;
    private MonoBehaviour runner;
    private Coroutine coroutine;
    public OnDamageVFX(Material originMaterial, Material onDamageMaterial, MonoBehaviour runner)
    {
        this.originMaterial = originMaterial;
        this.onDamageMaterial = onDamageMaterial;
        this.runner = runner;
    }
    
    public void ApplyEffect(GameObject appliedObject,float Duration)
    {
        if (coroutine != null)
        {
            runner.StopCoroutine(coroutine);
        }
       coroutine = runner.StartCoroutine(ApplyEffectForSecond(appliedObject.GetComponentInChildren<SpriteRenderer>(), Duration));
    }

    IEnumerator ApplyEffectForSecond(SpriteRenderer applied,float duration)
    {
        applied.material = onDamageMaterial;
        yield return new WaitForSeconds(duration);
        applied.material = originMaterial;
    }

}
