using System;
using UnityEngine;

public class MeleeCombat : MonoBehaviour, ICombat
{
    [Header("CONFIG")] [SerializeField] private float damage;
    [SerializeField] private float attackRadius;
    [SerializeField] LayerMask whatIsTarget;
    [Header("REFERENCE")] [SerializeField] private Transform attackPoint;

    public void Attack()
    {
        Collider2D[] entityInRanges = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, whatIsTarget);
        if (entityInRanges == null) return;
        foreach (var entity in entityInRanges)
        {
            if (entity.TryGetComponent<IAttackable>(out var attackable))
            {
                attackable.TakeDamage(damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position,attackRadius);
    }
}