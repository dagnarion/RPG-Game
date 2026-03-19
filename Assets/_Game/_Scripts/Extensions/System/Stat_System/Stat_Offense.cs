using System;
using UnityEngine;

[Serializable]
public class Stat_Offense
{
    [field:SerializeField] public Stat Damage { get; private set; }
    [field:SerializeField] public Stat CritChance { get; private set; }
    [field:SerializeField] public Stat CritPower { get; private set; }
    
    [field:SerializeField] public Stat FireDamage { get; private set; }
    [field:SerializeField] public Stat IceDamage { get; private set; }
    [field:SerializeField] public Stat LightningDamage { get; private set; }
}
