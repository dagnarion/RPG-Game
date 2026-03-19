using UnityEngine;

public class Entity_Stats : MonoBehaviour
{
  [field:SerializeField] public Stat maxHp { get; private set; }
  [SerializeField] private Stat_Major major;
  [SerializeField] private Stat_Deffensive deffensive;
  [SerializeField] private Stat_Offense offense;

  public float GetDamage(out bool IsCrit)
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
   
}
