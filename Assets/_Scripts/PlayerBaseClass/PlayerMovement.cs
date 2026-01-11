using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Reference")]
    [field:SerializeField] public Rigidbody2D rigi {get; private set;}
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform firstWallCheckPoint;
    [SerializeField] private Transform secondWallCheckPoint;
    [Header("Value")]
    [field:SerializeField] public float Speed {get; private set;}
    [field:SerializeField] public float JumpForce { get; private set;}
    [field:SerializeField] public Vector2 WallJumpForce { get; private set; }
    [field:SerializeField] public float DashForce { get; private set; }
    [field:SerializeField] public float DashDuration { get; private set; }
    [field:SerializeField] public float CoyoteTime { get; private set; }
    [field:SerializeField] public float MaxFallSpeed { get; private set; }
    [SerializeField] float checkDistance;
    [SerializeField] float wallCheckDistance;
    public float InAirMoveMultiplier = 0.8f;
    public float InWallSlideMultiplier = 0.8f;
    public bool IsOnGround {get; private set;}
    public bool IsOnWall {get; private set;}
    public float FacingDirection { get; private set; } = 1;
    bool isFacingRight = true;

    void Update()
    {
        GroundCheck();
        WallCheck();
    }


    public void SetVelocity(float xVelocity,float yVelocity)
    {
        rigi.linearVelocity = new Vector2(xVelocity,yVelocity);
    }

    public void GroundCheck()
    {
        IsOnGround =  Physics2D.Raycast(this.transform.position,Vector2.down,checkDistance,whatIsGround);
    }
    public void WallCheck()
    {
        IsOnWall = Physics2D.Raycast(firstWallCheckPoint.position,transform.right,wallCheckDistance,whatIsGround) 
            && Physics2D.Raycast(secondWallCheckPoint.position,transform.right,wallCheckDistance,whatIsGround);
    }

    public void HandleFlip(float direction)
    {
        if(direction > 0 && !isFacingRight)
            Flip();
        else
        if(direction < 0 && isFacingRight)
            Flip();
    }

    private void Flip()
    {
        transform.Rotate(0,180,0);
        isFacingRight = !isFacingRight;
        FacingDirection *= -1;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(this.transform.position,Vector2.down*checkDistance);
        Gizmos.DrawRay(firstWallCheckPoint.position,transform.right*wallCheckDistance);
        Gizmos.DrawRay(secondWallCheckPoint.position,transform.right*wallCheckDistance);
    }
    
}
