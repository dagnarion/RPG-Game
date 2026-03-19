using System;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private IComplete complete;
    public event Action OnAttack;
    public void Init(IComplete _complete)
    {
        complete = _complete;
    }
    public void AnimationDone()
    {
        complete.CompleteAnimation();
    }

    public void CombatAnimation()
    {
       OnAttack?.Invoke();
    }
    
    
}
// test
