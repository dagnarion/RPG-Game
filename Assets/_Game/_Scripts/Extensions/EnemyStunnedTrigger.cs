using UnityEngine;

public class EnemyStunnedTrigger : AnimationTrigger
{
    [SerializeField] private EnemyController _controller;

    public void StunnedHandle()
    {
        _controller.HandleStunn(!_controller.CanStunned);
    }
}
