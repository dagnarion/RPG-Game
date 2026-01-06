using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Reference")]
    [field:SerializeField] public Animator animator { get; private set; }
    [field:SerializeField] public PlayerMovement Movement {get; private set;}

    Player_InputTesst input;
    public StateMachine state;
    public PlayerIdleState IdleState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public Vector2 MovementInput { get; private set; }
    void Awake()
    {
        input = new Player_InputTesst();
        state = new StateMachine();
        animator = this.GetComponentInChildren<Animator>();
        IdleState = new PlayerIdleState(this, state, "Idle");
        RunState = new PlayerRunState(this, state, "Run");
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
        state.Initialize(IdleState);
    }

    void Update()
    {
        state.UpdateActiveState();
    }

}
