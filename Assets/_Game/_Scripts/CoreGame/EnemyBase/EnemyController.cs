using System;
using UnityEngine;

public class EnemyController : MonoBehaviour,IAttackable
{
    [Header("CONFIG")]
    [SerializeField] private float maxHp;
    [field: SerializeField] public float AnimationTransitionTime { get; private set; }
    [Header("REFERENCE")]
    [field:SerializeField] public Animator animator { get; private set; }
    [field:SerializeField] public EnemyMovement movement { get; private set; }
    [field:SerializeField] public EnemyDetecting Detecting { get; private set; }
    [SerializeField] private SelectCombatMode CombatMode;
    [SerializeField] private AnimationTrigger trigger;
    [SerializeField] private AnimationTriggerHandler triggerHandler;
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private VFXSelect _vfxSelect;
    public Enemy_IdleState IdleState { get; private set; }
    public Enemy_RunState RunState { get; private set; }
    public Enemy_AttackState AttackState { get; private set; }
    public Enemy_BattleState BattleState { get; private set; }
    public Enemy_DeadState DeadState { get; private set; }
    public StateMachine StateMachine { get; private set; }
    private IVFX onDamageVFX;
    private void Awake()
    {
        StateMachine = new StateMachine();
        IdleState = new Enemy_IdleState(this,movement, StateMachine, "Idle");
        RunState = new Enemy_RunState(this,movement, StateMachine, "Run");
        AttackState = new Enemy_AttackState(this,movement, StateMachine, "Attack");
        BattleState = new Enemy_BattleState(this, movement, StateMachine, "Battle");
        DeadState = new Enemy_DeadState(this, movement, StateMachine, "Dead");
        triggerHandler = new AnimationTriggerHandler(StateMachine);
        CombatMode.SetCombatMode(global::CombatMode.MeleeCombat);
        trigger.Init(triggerHandler,CombatMode.GetCurrentCombatMode());
        healthSystem.Init(maxHp);
        onDamageVFX = _vfxSelect.Create(VFXType.DamageVFX);
    }

    private void OnEnable()
    {
        healthSystem.OnDeadEvent += DeadHandler;
        healthSystem.OnDeadEvent += movement.OnDeadHandler;
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
        if(Input.GetKeyDown(KeyCode.F)) StateMachine.ChangeState(AttackState);
        StateMachine.UpdateActiveState();
    }

    public void TakeDamage(float amount)
    {
        healthSystem.Detuc(amount);
        onDamageVFX.ApplyEffect(this.gameObject,0.2f);
     if(!healthSystem.IsDead())   StateMachine.ChangeState(BattleState);
    
    }
    
    
    private void DeadHandler(object sender, EventArgs e)
    {
        StateMachine.ChangeState(DeadState);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
