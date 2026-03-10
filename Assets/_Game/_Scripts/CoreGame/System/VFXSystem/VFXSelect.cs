using System;
using System.Collections.Generic;
using UnityEngine;

public class VFXSelect : MonoBehaviour
{
  [SerializeField] private List<VFXHolder> vfxHolders;
  private Dictionary<VFXType, IVFXFactory> vfxFactories = new Dictionary<VFXType, IVFXFactory>();

  private void Awake()
  {
      foreach (var vfx in vfxHolders)
      {
          if (!vfxFactories.ContainsKey(vfx.type))
          {
              vfxFactories.Add(vfx.type,vfx.kind.GetComponent<IVFXFactory>());
          }
      }
  }

  public IVFX Create(VFXType type)
  {
      if (vfxFactories.TryGetValue(type, out var vfx))
      {
          return vfx.CreateVFX();
      }

      return null;
  }
  
  
}
[Serializable]
public class VFXHolder
{
 [field:SerializeField] public VFXType type { get; private set; }
 [field: SerializeField] public GameObject kind { get; private set; }
}

public enum VFXType
{
    DamageVFX = 0
}