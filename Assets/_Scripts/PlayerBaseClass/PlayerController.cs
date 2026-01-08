using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Reference")]
    [field:SerializeField] public Animator animator { get; private set; }
    [field:SerializeField] public PlayerMovement Movement {get; private set;}

    public Player_InputTesst input {get; private set;}
    public StateMachine state;
    public PlayerJumpState JumpState { get; private set; }
    public PlayerFallState FallState { get; private set; }
    public PlayerGroundedState GroundedState {get; private set;}
    public Vector2 MovementInput { get; private set; }
    void Awake()
    {
        input = new Player_InputTesst();
        state = new StateMachine();
        animator = this.GetComponentInChildren<Animator>();
        GroundedState = new PlayerGroundedState(this,state,"Ground");
        JumpState = new PlayerJumpState(this,state,"Air");
        FallState = new PlayerFallState(this,state,"Air");
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
        Movement.GroundCheck();
        Movement.HandleFlip(MovementInput.x);
    }

}
