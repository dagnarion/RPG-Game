using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour, IAttackable , ICounterable
{
    [Header("CONFIG")] 
    [SerializeField] private float maxHp;
    [field: SerializeField] public float AnimationTransitionTime { get; private set; }
    public bool CanStunned { get; private set; }
    [Header("REFERENCE")]
    [field: SerializeField]
    public Animator animator { get; private set; }
    [field:SerializeField] public GameObject AlertPoint { get; private set; }
    [field:SerializeField] public GameObject StunPoint { get; private set; }
    [field: SerializeField] public EnemyMovement movement { get; private set; }
    [field: SerializeField] public EnemyDetecting Detecting { get; private set; }
    [SerializeField] private SelectCombatMode CombatMode;
    [SerializeField] private AnimationTrigger trigger;
    [SerializeField] private AnimationTriggerHandler triggerHandler;
    [SerializeField] private HealthSystem healthSystem;
    [field:SerializeField] public VFXManager vfxManager { get; private set; }
    public Enemy_IdleState IdleState { get; private set; }
    public Enemy_RunState RunState { get; private set; }
    public Enemy_AttackState AttackState { get; private set; }
    public Enemy_BattleState BattleState { get; private set; }
    public Enemy_DeadState DeadState { get; private set; }
    public Enemy_OnDamageState OnDamageState { get; private set; }
    public Enemy_StunnedState StunnedState { get; private set; }
    public StateMachine StateMachine { get; private set; }
    [field: SerializeField] public bool IsAttacked { get; private set; }
    private Coroutine knockBackCo;
    [field:SerializeField] public Transform sendered { get; private set; }
    private Coroutine TakeDamageCo;
    private void Awake()
    {
        StateMachine = new StateMachine();
        IdleState = new Enemy_IdleState(this, movement, StateMachine, "Idle");
        RunState = new Enemy_RunState(this, movement, StateMachine, "Run");
        AttackState = new Enemy_AttackState(this, movement, StateMachine, "Attack");
        BattleState = new Enemy_BattleState(this, movement, StateMachine, "Battle");
        DeadState = new Enemy_DeadState(this, movement, StateMachine, "Dead");
        OnDamageState = new Enemy_OnDamageState(this, movement, StateMachine, "OnDamage");
        StunnedState = new Enemy_StunnedState(this, movement, StateMachine, "Stunned");
        triggerHandler = new AnimationTriggerHandler(StateMachine);
        CombatMode.SetCombatMode(global::CombatMode.MeleeCombat);
        trigger.Init(triggerHandler, CombatMode.GetCurrentCombatMode());
        healthSystem.Init(maxHp);
    }

    private void Start()
    {
        CanStunned = false;
    }

    private void OnEnable()
    {
        healthSystem.OnDeadEvent += movement.OnDeadHandler;
        healthSystem.OnDeadEvent += DeadHandler;
        healthSystem.Reborn();
        StateMachine.Initialize(IdleState);
    }

    private void OnDisable()
    {
        healthSystem.OnDeadEvent -= DeadHandler;
        healthSystem.OnDeadEvent -= movement.OnDeadHandler;
    }

    private void Update()
    {
        StateMachine.UpdateActiveState();
        if (Input.GetKeyDown(KeyCode.F))
        {
            HandleCounter();
        }
    }

    public void HandleStunn(bool enable) => CanStunned = enable;

    public void TakeDamage(HitData hit)
    {
        healthSystem.Detuc(hit.Damage);
        if (healthSystem.IsDead()) return;
        vfxManager.StopAllVFX();
        vfxManager.GetVFX(TypeOfVFX.ONHIT).ApplyEffect();
        sendered = hit.Sender;
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
        knockBackCo = StartCoroutine(KnockBack(knockBackVel, hit.KnockBackDuration));
    }

    IEnumerator KnockBack(Vector2 knockbackForce, float duration)
    {
        IsAttacked = true;
        movement.SetVelocity(knockbackForce.x, knockbackForce.y);
        yield return new WaitForSeconds(duration);
        movement.SetVelocity(movement.rigi.linearVelocityX * 0.5f, movement.rigi.linearVelocityY);
        IsAttacked = false;
    }


    private void DeadHandler(object sender, EventArgs e)
    {
        StateMachine.ChangeState(DeadState);
        this.enabled = false;
    }

    public void HandleCounter()
    {
       if(!CanStunned) return;
       StateMachine.ChangeState(StunnedState);
    }
    
}