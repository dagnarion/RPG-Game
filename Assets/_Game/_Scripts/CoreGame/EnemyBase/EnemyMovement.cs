using System;
using System.Collections;
using UnityEngine;

public class EnemyMovement : BaseMovement
{
    [field: SerializeField] public float IdleTime { get; private set; }
    [field: SerializeField] public float MoveSpeed { get; private set; }
    [field: SerializeField] public float ChaseSpeed { get; private set; }
    [field:SerializeField] public float AnimationSpeedMultiphyler { get; private set; }
    [field:SerializeField] public Vector2 RetreatVelocity { get; private set; }
    [field:SerializeField] public Vector2 deadVelocity { get; private set; }
    [SerializeField] private float deadDuration;
    public FlipObject FlipHandler { get; private set; }
    private Coroutine deadDelay;
    
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
        this.GetComponent<Collider2D>().enabled = false;
    }
    
}
