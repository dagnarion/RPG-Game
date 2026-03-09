using System;
using UnityEngine;

public class EnemyDetecting : MonoBehaviour
{
  [Header("CONFIG")] 
  [field:SerializeField] public float attackRadius { get; private set; }
  [SerializeField] private float retreatRadius;
  [SerializeField] private float checkRadius;
  [SerializeField] private LayerMask whatIsTarget;
  [SerializeField] private LayerMask whatIsGround;
  [Header("REFERENCE")] 
  [SerializeField] private Transform checkPoint;
  [SerializeField] private Transform attackPoint;
  [SerializeField] private Transform retreatPoint;
  
  public Collider2D IsTargetOnChaseDetection()
  {
    Collider2D hit = Physics2D.OverlapCircle(checkPoint.position, checkRadius, whatIsTarget | whatIsGround );
    if (hit != null && hit.gameObject.layer != LayerMask.NameToLayer("Player"))
      return default;
    return hit;
  }

  public bool CanAttack() => Physics2D.OverlapCircle(attackPoint.position, attackRadius, whatIsTarget);
  public bool CanRetreat() => Physics2D.OverlapCircle(retreatPoint.position, retreatRadius, whatIsTarget);
  
  private void OnDrawGizmos()
  {
    if(checkPoint == null || attackPoint == null || retreatPoint == null) return;
    Gizmos.color = Color.white;
    Gizmos.DrawWireSphere(checkPoint.position,checkRadius);
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(attackPoint.position,attackRadius);
    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere(retreatPoint.position,retreatRadius);
  }
}

// RaycastHit2D hit = Physics2D.Raycast(checkPosition.position, transform.right, checkDistance, whatIsTarget | whatIsGround);
// if(hit.collider!=null && hit.collider.gameObject.layer != LayerMask.NameToLayer("Player"))
// return default;
// return hit;