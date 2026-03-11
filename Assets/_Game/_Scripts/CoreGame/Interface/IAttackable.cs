using System;
using UnityEngine;

public interface IAttackable
{
    public void TakeDamage(HitData hit);
}
[Serializable]
public class HitData
{
    [field:SerializeField] public Transform Sender { get; private set; }
    [field:SerializeField] public float Damage { get; private set; }
    [field:SerializeField] public Vector2 KnockBackForce { get; private set; }
    [field:SerializeField] public float KnockBackDuration { get; private set; }
}