using System;
using UnityEngine;

public class MeleeCombat : MonoBehaviour, ICombat
{
    [Header("CONFIG")] 
    [SerializeField] private VFXManager _vfxManager;
    [SerializeField] private float attackRadius;
    [SerializeField] LayerMask whatIsTarget;
    [Header("REFERENCE")] [SerializeField] private Transform attackPoint;

    public void Attack(HitData damageData)
    {
        Collider2D[] entityInRanges = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, whatIsTarget);
        if (entityInRanges == null) return;
        foreach (var entity in entityInRanges)
        {
            if (entity.TryGetComponent<IAttackable>(out var attackable))
            {
             bool canTakeDamage =   attackable.TakeDamage(damageData);
             if (canTakeDamage)
             {
                 if(!damageData.IsCrit)  _vfxManager.GetVFX(TypeOfVFX.ONHIT).ApplyEffect(entity.transform);
                 else _vfxManager.GetVFX(TypeOfVFX.ONCRIT).ApplyEffect(entity.transform);
             }
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position,attackRadius);
    }
}