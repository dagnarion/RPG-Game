using System;
using UnityEngine;

[Serializable]
public class Stat_Deffensive 
{
   [field:SerializeField] public Stat Evasion { get; private set; }
   [field:SerializeField] public Stat Armor { get; private set; }
   
   
   [field:SerializeField] public Stat FireRes { get; private set; }
   [field:SerializeField] public Stat IceRes { get; private set; }
   [field:SerializeField] public Stat LightningRes { get; private set; }
}
