using TreeEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Player_InputTesst input;
    [SerializeField] float speed;
    public Vector2 movement {get; private set;}
    void Awake()
    {
        input = new Player_InputTesst();
    }
    void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
    }
    void OnDisable()
    {
        input.Disable();        
    }

    void Update()
    {
        if(movement.x!=0)
        {
            transform.position += Vector3.right * movement.x * speed * Time.deltaTime;
        }
    }

}
