using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] private List<VFXType> holder;
    private Dictionary<TypeOfVFX, IVFX> vfxes = new Dictionary<TypeOfVFX, IVFX>();
    
    private void Awake()
    {
        foreach (var it in holder)
        {
            if (!vfxes.ContainsKey(it.Type))
            {
                IVFX temp = it.Prefab.GetComponent<IVFX>();
                vfxes.Add(it.Type,temp);
            }
        }
    }

    public IVFX GetVFX(TypeOfVFX type)
    {
        if (!vfxes.ContainsKey(type)) {Debug.LogError($"There was not {type.ToString()} in holder"); return null;}
        return vfxes[type];
    }

    public void StopAllVFX()
    {
        foreach (var it in vfxes)
        {
            it.Value.RemoveEffect();
        }
    }
}

[Serializable]
public class VFXType
{
    [field: SerializeField] public TypeOfVFX Type { get; private set; }
    [field:SerializeField] public GameObject Prefab { get; private set; }
}

public enum TypeOfVFX
{
    NONE = 0,
    ONDAMAGE = 1,
    ALERT = 2,
    STUN = 3,
    ONHIT = 4
}
