using UnityEngine;

public class Entity_Stats : MonoBehaviour
{
  [field:SerializeField] public Stat maxHp { get; private set; }
  [SerializeField] private Stat_Major major;
  [SerializeField] private Stat_Deffensive deffensive;
  [SerializeField] private Stat_Offense offense;

  public float GetElementDamage(out ElementType elementType)
  {
      float fireDamage = offense.FireDamage.GetValue();
      float iceDamage = offense.IceDamage.GetValue();
      float lightningDamage = offense.LightningDamage.GetValue();
      float bonusElementalDamage = major.Intelligence.GetValue() * 0.5f;
      float highestDamage = -10;
      elementType = ElementType.NONE;
      if (highestDamage < fireDamage)
      {
          highestDamage = fireDamage;
          elementType = ElementType.FIRE;
      } 
      if (highestDamage < iceDamage)
      {
          highestDamage = iceDamage;
          elementType = ElementType.ICE;
      }
      
      if (highestDamage < lightningDamage)
      {
          highestDamage = lightningDamage;
          elementType = ElementType.LIGHTNING;
      }
      
      float fireBonusDamage = (fireDamage == highestDamage) ? 0 : fireDamage * 0.5f;
      float iceBonusDamage = (iceDamage == highestDamage) ? 0 : iceDamage * 0.5f;
      float lightningBonusDamage = (lightningDamage == highestDamage) ? 0 : lightningDamage * 0.5f;
      float weakElementDamage = lightningBonusDamage + fireBonusDamage + iceBonusDamage;
      if (highestDamage <= 0) return 0;
      return highestDamage + weakElementDamage;
  }
  
  public float GetPhysicalDamage(out bool IsCrit)
  {
      float baseDamage = offense.Damage.GetValue();
      float bonusDamage = major.Strength.GetValue();
      float totalDamage = baseDamage + bonusDamage;

      float baseCritPower = offense.CritPower.GetValue();
      float bonusCritDamage = major.Strength.GetValue() * 0.5f;
      float critPower = (baseCritPower + bonusCritDamage) / 100;
      IsCrit = Random.Range(0, 100) <= offense.CritChance.GetValue();
      float finalDamage = IsCrit ? critPower * totalDamage : totalDamage;
      return finalDamage;
  }
  
   public float GetMaxHealth()
   {
      float baseHp = maxHp.GetValue();
      float bonusHp = major.Vitality.GetValue() * 7;
      return baseHp + bonusHp;
   }

   public float GetEvasion()
   {
       float baseEvasion = deffensive.Evasion.GetValue();
       float bounsEvasion = major.Agility.GetValue() * 0.5f;
       float maxEvasion = 85;
       float finalEvasion = Mathf.Clamp(baseEvasion + bounsEvasion, 0, maxEvasion);
       return finalEvasion;
   }

   public float GetArmorMitigation(float armorReduction)
   {
       float baseArmor = deffensive.Armor.GetValue();
       float bonusArmor = major.Strength.GetValue();
       float totalArmor = baseArmor + bonusArmor;
       totalArmor = totalArmor * Mathf.Clamp(1 - armorReduction, 0, 1);
       float mitigation = totalArmor / (totalArmor + 100);
       return Mathf.Clamp(mitigation,0,0.85f);
   }

   public float GetArmorReduction()
   {
       float finalReduction = offense.ArmorReduction.GetValue() / 100;
       return finalReduction;
   }

   public float GetElementResitance(ElementType element)
   {
       float baseResitance = 0f;
       float bonusResitance = major.Intelligence.GetValue() * .5f;

       switch (element)
       {
           case ElementType.FIRE:
               baseResitance = deffensive.FireRes.GetValue();
               break;
           case ElementType.ICE:
               baseResitance = deffensive.IceRes.GetValue();
               break;
           case ElementType.LIGHTNING:
               baseResitance = deffensive.LightningRes.GetValue();
               break;
       }

       float resitance = baseResitance + bonusResitance;
       float maxElementResitance = .75f;
       float finalResitance = Mathf.Clamp(resitance, 0, maxElementResitance) / 100;
       return finalResitance;
   }
}

public enum ElementType
{
    NONE = 0,
    FIRE = 1,
    ICE = 2,
    LIGHTNING = 3
}
