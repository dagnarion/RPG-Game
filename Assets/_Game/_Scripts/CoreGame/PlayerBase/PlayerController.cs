using System;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

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
    [SerializeField] private VFXSelect _vfxSelect;
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
    public PlayerOnDamageState OnDamageState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    public Vector2 MovementInput { get; private set; }
    private IVFX onDamageVFX;
    private Coroutine knockBackCo;
    public bool IsAttacked { get; private set; }
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
        OnDamageState = new PlayerOnDamageState(this, state, "OnDamage");
        DeadState = new PlayerDeadState(this, state, "Dead");
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
        onDamageVFX = _vfxSelect.Create(VFXType.DamageVFX);
    }

    void Update()
    {
        state.UpdateActiveState();
    }
    
    public void TakeDamage(HitData hit)
    {
        if(HealthSystem.IsDead()) return;
        HealthSystem.Detuc(hit.Damage);
        onDamageVFX?.ApplyEffect(this.gameObject,0.2f);
        TakeKnockback(hit);
    }

    private void TakeKnockback(HitData hit)
    {
        int direction = (transform.position.x > hit.Sender.position.x) ? 1 : -1;
        Vector2 knockBackVel = hit.KnockBackForce;
        knockBackVel.x = hit.KnockBackForce.x * direction;
        if (knockBackCo != null)
        {
            StopCoroutine(knockBackCo);
        }
        knockBackCo = StartCoroutine(KnockBack(knockBackVel,hit.KnockBackDuration));
    }

    IEnumerator KnockBack(Vector2 knockbackForce,float duration)
    {
        IsAttacked = true;
        Movement.SetVelocity(knockbackForce.x,knockbackForce.y);
        yield return new WaitForSeconds(duration);
        Movement.SetVelocity(Movement.rigi.linearVelocityX*0.5f,0);
        IsAttacked = false;
    }
    
    private void DeadHandler(object sender, EventArgs e)
    {
        //anim.SetTrigger("Die"); 
        state.ChangeState(DeadState);
        IsAttacked = false;
        GetComponent<Collider2D>().enabled = false;
        Movement.rigi.simulated = false;
        this.enabled = false;
    }
}
