using System;
using UnityEngine;

public class PlayerController : MonoBehaviour,IAttackable
{
    [Header("CONFIG")] 
    [SerializeField] private float maxHp;
    [Header("Reference")] 
    [SerializeField] private SelectCombatMode combatMode;
    [field: SerializeField] public Animator animator { get; private set; }
    [field: SerializeField] public PlayerMovement Movement { get; private set; }
    [field: SerializeField] public PlayerAttack AttackController { get; private set; }
    [SerializeField] private AnimationTrigger trigger;
    [SerializeField] private HealthSystem HealthSystem;
    private AnimationTriggerHandler triggerHandler;
    public Player_InputTesst input { get; private set; }
    public StateMachine state;
    public PlayerJumpState JumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerGroundedState GroundedState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerDashEndState DashEndState { get; private set; }
    public PlayerAttackState AttackState { get; private set; }
    public PlayerJumpAttack JumpAttack { get; private set; }
    public Vector2 MovementInput { get; private set; }
    void Awake()
    {
        input = new Player_InputTesst();
        state = new StateMachine();
        animator = this.GetComponentInChildren<Animator>();
        GroundedState = new PlayerGroundedState(this, state, "Ground");
        JumpState = new PlayerJumpState(this, state, "Air");
        FallState = new PlayerFallState(this, state, "Air");
        WallSlideState = new PlayerWallSlideState(this, state, "WallSlide");
        WallJumpState = new PlayerWallJumpState(this, state, "Air");
        DashState = new PlayerDashState(this, state, "Dash");
        DashEndState = new PlayerDashEndState(this, state, "DashEnd");
        AttackState = new PlayerAttackState(this, state, "BaseAttack");
        JumpAttack = new PlayerJumpAttack(this, state, "JumpAttack");
        triggerHandler = new AnimationTriggerHandler(state);
        combatMode.SetCombatMode(CombatMode.MeleeCombat);
        trigger.Init(triggerHandler,combatMode.GetCurrentCombatMode());
        HealthSystem.Init(maxHp);
    }

    void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += ctx => MovementInput = ctx.ReadValue<Vector2>();
        input.Player.Movement.canceled += ctx => MovementInput = Vector2.zero;
        HealthSystem.OnDeadEvent += DeadHandler;
        HealthSystem.Reborn();
    }
    void OnDisable()
    {
        input.Disable();
        HealthSystem.OnDeadEvent -= DeadHandler;
    }

    void Start()
    {
        state.Initialize(GroundedState);
    }

    void Update()
    {
        state.UpdateActiveState();
    }
    
    public void TakeDamage(float amount)
    {
        HealthSystem.Detuc(amount);
    }

    private void DeadHandler(object sender, EventArgs e)
    {
        //anim.SetTrigger("Die"); 
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
