using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Value")]
    [field:SerializeField] public float AttackDuration { get; private set; }
    [field:SerializeField] public float AttackTimeReset { get; private set; }
    [field:SerializeField] public Vector2[] AttackVelocity { get; private set; }
    [field:SerializeField] public Vector2 JumpAttackVelocity { get; private set; }
    private Coroutine attackQueue;

    public void EnterAttackWithoutDelay(StateMachine stateMachine,EntityState state)
    {
        if(attackQueue != null) StopCoroutine(attackQueue);
        attackQueue = StartCoroutine(AttackQuere(stateMachine, state));
    }
    
    
    IEnumerator AttackQuere(StateMachine stateMachine,EntityState state)
    {
        yield return new WaitForEndOfFrame();
        stateMachine.ChangeState(state);
    }
    
}
