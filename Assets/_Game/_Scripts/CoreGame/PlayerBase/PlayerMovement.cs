using System;
using UnityEngine;

public class PlayerMovement : BaseMovement
{
    [Header("Value")]
    [field:SerializeField] public float Speed {get; private set;}
    [field:SerializeField] public float JumpForce { get; private set;}
    [field:SerializeField] public Vector2 WallJumpForce { get; private set; }
    [field:SerializeField] public float DashForce { get; private set; }
    [field:SerializeField] public float DashDuration { get; private set; }
    [field:SerializeField] public float CoyoteTime { get; private set; }
    [field:SerializeField] public float MaxFallSpeed { get; private set; }
    public float InAirMoveMultiplier = 0.8f;
    public float InWallSlideMultiplier = 0.8f;
    public FlipObject Flip { get; private set; }
    
    private void Awake()
    {
        Flip = new FlipObject(this.transform);
    }

    void Update()
    {
        GroundCheck();
        WallCheck();
    }
    
}
