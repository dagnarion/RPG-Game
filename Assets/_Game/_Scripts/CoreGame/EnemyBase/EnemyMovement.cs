using System;
using UnityEngine;

public class EnemyMovement : BaseMovement
{
    [field: SerializeField] public float IdleTime { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float ChaseSpeed { get; private set; }
    [field:SerializeField] public float AnimationSpeedMultiphyler { get; private set; }
    [field:SerializeField] public Vector2 RetreatVelocity { get; private set; }
    public FlipObject FlipHandler { get; private set; }

    private void Awake()
    {
        FlipHandler = new FlipObject(this.transform);
    }

    private void Update()
    {
        GroundCheck();
        WallCheck();
    }

    public void OnDeadHandler(object sender,EventArgs eventArgs)
    {
        rigi.simulated = false;
    }
}
