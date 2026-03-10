using UnityEngine;

public class DamageVFXFactory :MonoBehaviour,IVFXFactory
{
   [SerializeField] private Material originMaterial;
   [SerializeField] private Material onDamageMaterial;
    
    public IVFX CreateVFX()
    {
        return new OnDamageVFX(originMaterial,onDamageMaterial,this);
    }
}
