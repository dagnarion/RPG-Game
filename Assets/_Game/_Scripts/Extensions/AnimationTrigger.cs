using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    [SerializeField] private IComplete complete;
    [SerializeField] private ICombat combat;
    
    public void Init(IComplete _complete,ICombat combat)
    {
        complete = _complete;
        this.combat = combat;
    }
    public void AnimationDone()
    {
        complete.CompleteAnimation();
    }

    public void CombatAnimation()
    {
        combat.Attack();
    }
    
    
}
// test
