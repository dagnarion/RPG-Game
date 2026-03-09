using System;
using UnityEngine;

public class SelectCombatMode : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] combat;
    private int index;
    
    public void SetCombatMode(CombatMode combatMode)
    {
        switch (combatMode)
        {
            case CombatMode.MeleeCombat:
                index = (int)CombatMode.MeleeCombat;
                break;
        }
    }

    public ICombat GetCurrentCombatMode()
    {
        return combat[index] as ICombat;
    }
}

public enum CombatMode
{
    MeleeCombat = 0
}