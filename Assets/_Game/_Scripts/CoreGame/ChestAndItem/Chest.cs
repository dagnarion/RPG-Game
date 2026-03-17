using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Chest : MonoBehaviour,IInteractable,IAttackable
{
    [Header("CONFIG")] 
    [SerializeField] private Vector2 knockBack;
    [SerializeField] private float Duration;
    private bool isOpen;
    [Header("REFERENCE")]
    [SerializeField] private Animator _animator;
    [FormerlySerializedAs("holder")] [SerializeField] private VFXManager vfxManager;
    private Rigidbody2D rigi;
    
    private Coroutine openCoroutine;
    private void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
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
        vfxManager.GetVFX(TypeOfVFX.ONHIT).ApplyEffect();
        openCoroutine = StartCoroutine(Open());
    }

    IEnumerator Open()
    {
        _animator.SetBool("Open",true);
        rigi.linearVelocity = knockBack;
        rigi.angularVelocity = Random.Range(-200f, 200f);
        isOpen = true;
        yield return new WaitForSeconds(0.5f);
        rigi.simulated = false;
    }
}
