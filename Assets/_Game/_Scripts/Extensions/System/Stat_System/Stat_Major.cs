using System;
using UnityEngine;

[Serializable]
public class Stat_Major
{
    [field:SerializeField] public Stat Vitality { get; private set; }
    [field:SerializeField] public Stat Strength { get; private set; }
    [field:SerializeField] public Stat Intelligence { get; private set; }
    [field:SerializeField] public Stat Agility { get; private set; }
}
