using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Reference")]
    [field:SerializeField] public Rigidbody2D rigi {get; private set;}
    [Header("Value")]
    [field:SerializeField] public float speed {get; private set;}
    bool isFacingRight = true;

    public void SetVelocity(float xVelocity,float yVelocity)
    {
        rigi.linearVelocity = new Vector2(xVelocity,yVelocity);
    }

    public void HandleFlip(float direction)
    {
        if(direction > 0 && !isFacingRight)
        Flip();
        else
        if(direction < 0 && isFacingRight)
        Flip();
    }

    private void Flip()
    {
        transform.Rotate(0,180,0);
        isFacingRight = !isFacingRight;
    }

}
