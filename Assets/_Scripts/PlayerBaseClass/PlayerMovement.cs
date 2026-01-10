using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Reference")]
    [field:SerializeField] public Rigidbody2D rigi {get; private set;}
    [SerializeField] private LayerMask whatIsGround;
    [Header("Value")]
    [field:SerializeField] public float Speed {get; private set;}
    [field:SerializeField] public float JumpForce { get; private set;}
    [field:SerializeField] public Vector2 WallJumpForce { get; private set; }
    [field:SerializeField] public float DashForce { get; private set; }
    [field:SerializeField] public float DashDuration { get; private set; }
    // CustomAttack
    [field:SerializeField] public float AttackDuration { get; private set; }
    [field:SerializeField] public Vector2[] AttackVelocity { get; private set; }
    [field:SerializeField] public float AttackTimeReset { get; private set; }
    // TODO: temp, nên chuyển sang scripts khaác
    
    [SerializeField] float checkDistance;
    [SerializeField] float wallCheckDistance;
    public float InAirMoveMultiplier = 0.8f;
    public float InWallSlideMultiplier = 0.8f;
    public bool IsOnGround {get; private set;}
    public bool IsOnWall {get; private set;}
    public float IsFacingWall { get; private set; } = 1;
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
        IsOnWall = Physics2D.Raycast(this.transform.position,transform.right,wallCheckDistance,whatIsGround);
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
        IsFacingWall *= -1;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(this.transform.position,Vector2.down*checkDistance);
        Gizmos.DrawRay(this.transform.position,transform.right*wallCheckDistance);
    }
    
}
