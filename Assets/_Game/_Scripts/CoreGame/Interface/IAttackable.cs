using System;
using UnityEngine;

public interface IAttackable
{
    public bool TakeDamage(HitData hit);
}
[Serializable]
public class HitData
{
    [field:SerializeField] public Transform Sender { get; private set; }
    [field:SerializeField] public Vector2 KnockBackForce { get; private set; }
    [field:SerializeField] public float KnockBackDuration { get; private set; }
    public ElementType ElementDamageType { get; private set; }
    public float PhysicalDamage { get; private set; }
    public float ElementDamage { get; private set; }
    public float ArmorReduction { get; private set; }
    public bool IsCrit { get; private set; }
    public void SetPhysicalDamage(float amount) => PhysicalDamage = amount;
    public void SetElementDamage(float amount) => ElementDamage = amount;
    public void SetCrit(bool condition) => IsCrit = condition;
    public void SetArmorReduction(float amount) => ArmorReduction = amount;
    public void SetElementDamageType(ElementType type) => ElementDamageType = type;
}