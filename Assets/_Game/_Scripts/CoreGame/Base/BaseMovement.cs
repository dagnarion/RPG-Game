using System;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{

    public bool IsOnGround { get; protected set; }
    public bool IsOnWall { get; protected set; }
    [field: SerializeField] public Rigidbody2D rigi { get; protected set; }
    [SerializeField] protected LayerMask whatIsGround;
    [SerializeField] protected Transform groundCheckPoint;
    [SerializeField] protected Transform firstWallCheckPoint;
    [SerializeField] protected Transform secondWallCheckPoint;
    [SerializeField] protected float checkDistance;
    [SerializeField] protected float wallCheckDistance;

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rigi.linearVelocity = new Vector2(xVelocity, yVelocity);
    }

    public void GroundCheck()
    {
        IsOnGround = Physics2D.Raycast(groundCheckPoint.position, Vector2.down, checkDistance, whatIsGround);
    }

    public void WallCheck()
    {
        if (secondWallCheckPoint != null)
        {
            IsOnWall = Physics2D.Raycast(firstWallCheckPoint.position, transform.right, wallCheckDistance, whatIsGround)
                       && Physics2D.Raycast(secondWallCheckPoint.position, transform.right, wallCheckDistance,
                           whatIsGround);
            return;
        }

        IsOnWall = Physics2D.Raycast(firstWallCheckPoint.position, transform.right, wallCheckDistance, whatIsGround);
    }

    protected void OnDrawGizmos()
    {
        Gizmos.DrawRay(groundCheckPoint.position,Vector3.down * checkDistance);
        Gizmos.DrawRay(firstWallCheckPoint.position,Vector3.right * wallCheckDistance);
       if(secondWallCheckPoint!=null) Gizmos.DrawRay(secondWallCheckPoint.position,Vector3.right * wallCheckDistance);
    }
}
