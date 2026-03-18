using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyStunnedTrigger : AnimationTrigger
{
    [SerializeField] private Enemy _controller;
    [FormerlySerializedAs("holder")] [SerializeField] private VFXManager vfxManager;

    public void StartAlert()
    {
        vfxManager.GetVFX(TypeOfVFX.ALERT).ApplyEffect(_controller.AlertPoint.transform);
    }

    public void StopAlert()
    {
        vfxManager.GetVFX(TypeOfVFX.ALERT).RemoveEffect();
    }
    
    public void StartStunnedHandle()
    {
        _controller.HandleStunn(true);
    }

    public void EndStunnedHandle()
    {
        _controller.HandleStunn(false);
    }
    
}
