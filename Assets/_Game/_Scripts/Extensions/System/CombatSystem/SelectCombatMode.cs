using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectCombatMode : MonoBehaviour
{
    [SerializeField] private List<CombatMode> combat;
    private Dictionary<CombatType, ICombat> combatModes = new Dictionary<CombatType, ICombat>();

    private void Awake()
    {
        foreach (var it in combat)
        {
            it.Init();
            if (!combatModes.ContainsKey(it.Type))
            {
                combatModes.Add(it.Type,it.combat);
            }
        }
    }

    public ICombat GetCombatMode(CombatType type)
    {
        if (!combatModes.ContainsKey(type)) {Debug.Log($"There {type.ToString()} was not exist in Holder"); return null;}
        return combatModes[type];
    }
    
}
[Serializable]
public class CombatMode
{
    [field:SerializeField] public CombatType Type { get; private set; }
    [SerializeField] private GameObject combatPrefab;
    public ICombat combat { get; private set; }
    public void Init()
    {
        combat = combatPrefab.GetComponent<ICombat>();
    }
}


public enum CombatType
{
    MeleeCombat = 0
}