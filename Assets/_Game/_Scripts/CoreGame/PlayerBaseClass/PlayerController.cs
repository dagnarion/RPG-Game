using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Reference")]
    [field: SerializeField] public Animator animator { get; private set; }
    [field: SerializeField] public PlayerMovement Movement { get; private set; }
    [field: SerializeField] public PlayerAttack AttackController { get; private set; }
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
    }

    void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += ctx => MovementInput = ctx.ReadValue<Vector2>();
        input.Player.Movement.canceled += ctx => MovementInput = Vector2.zero;
    }
    void OnDisable()
    {
        input.Disable();
    }

    void Start()
    {
        state.Initialize(GroundedState);
    }

    void Update()
    {
        state.UpdateActiveState();
    }

    public void CompleteAnimation()
    {
        PlayerState playerState = (PlayerState) state.currentState;
        playerState.CompleteAnimation();
    }
}
