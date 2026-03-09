using UnityEngine;

public class FlipObject
{
    private Transform entity;
    public float FacingDirection { get; private set; } = 1;
    bool isFacingRight = true;
    
    public FlipObject(Transform _entity)
    {
        entity = _entity;
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
        entity.Rotate(0,180,0);
        isFacingRight = !isFacingRight;
        FacingDirection *= -1;
    }
}
