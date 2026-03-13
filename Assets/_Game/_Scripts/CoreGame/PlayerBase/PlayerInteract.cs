using System;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
   [SerializeField] private float interactRadius;
   [SerializeField] private Transform interactPoint;
   [SerializeField] private LayerMask whatCanInteract;
   
   public void Interact()
   {
    Collider2D interactable =  Physics2D.OverlapCircle(interactPoint.position, interactRadius, whatCanInteract);
    if(interactable == null) return;
    if (interactable.TryGetComponent<IInteractable>(out var interactItems))
    {
        interactItems.Interact();
    }
   }

   private void OnDrawGizmos()
   {
      if(interactPoint == null) return;
      Gizmos.color = Color.green;
      Gizmos.DrawWireSphere(interactPoint.position,interactRadius);
   }
}
