using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class Chest : MonoBehaviour,IInteractable,IAttackable
{
    [Header("CONFIG")] 
    [SerializeField] private Vector2 knockBack;

    private bool isOpen;
    [Header("REFERENCE")]
    [SerializeField] private Animator _animator;
    [SerializeField] private VFXSelect _vfxSelect;
    private Rigidbody2D rigi;
    private IVFX vfx;
    private Coroutine openCoroutine;
    private void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        vfx = _vfxSelect.Create(VFXType.DamageVFX);
        isOpen = false;
    }


    public void Interact()
    {
        if(isOpen) return;
       _animator.SetBool("Open",true);
    }

    public void TakeDamage(HitData hit)
    {
        if(isOpen) return;
        if (openCoroutine != null)
        {
            StopCoroutine(openCoroutine);
        }

        openCoroutine = StartCoroutine(Open());
    }

    IEnumerator Open()
    {
        vfx.ApplyEffect(this.gameObject,0.2f);
        _animator.SetBool("Open",true);
        rigi.linearVelocity = knockBack;
        rigi.angularVelocity = Random.Range(-200f, 200f);
        isOpen = true;
        yield return new WaitForSeconds(0.5f);
        rigi.simulated = false;
    }
}
