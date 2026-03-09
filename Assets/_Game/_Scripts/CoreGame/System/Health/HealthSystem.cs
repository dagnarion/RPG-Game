using UnityEngine;
using System;
public class HealthSystem : MonoBehaviour
{
    private float maxHp;
    private float currentHp;
    public event EventHandler HealthChangeEvent;
    public event EventHandler OnDeadEvent;
    private bool CheckingIfDeadOrNo;
    public void Init(float maxHp)
    {
        this.maxHp = maxHp;
        Reborn();
    }
    public void Reborn() => currentHp = maxHp;
    
    public void Heal(float amount)
    {
        if(IsDead()) return;
        currentHp = Mathf.Clamp(currentHp + amount, 0, maxHp);
        HealthChangeEvent?.Invoke(this,EventArgs.Empty);
    }

    public void Detuc(float amount)
    {
        if(IsDead()) return;
        currentHp = Mathf.Clamp(currentHp - amount, 0, maxHp);
        HealthChangeEvent?.Invoke(this,EventArgs.Empty);
    }

    public bool IsDead()
    {
        if (CheckingIfDeadOrNo == false && currentHp <= 0)
        {
            OnDeadEvent?.Invoke(this,EventArgs.Empty);
            CheckingIfDeadOrNo = true;
        }
        return currentHp <= 0;
    }

    public float GetHealhAmountNozmalized() => currentHp / maxHp;

}
