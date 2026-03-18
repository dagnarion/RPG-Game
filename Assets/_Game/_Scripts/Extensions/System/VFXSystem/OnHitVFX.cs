using UnityEngine;

public class OnHitVFX : MonoBehaviour,IVFX
{
    [Header("CONFIG")] 
    [SerializeField] private Vector2 minOffSet;
    [SerializeField] private Vector2 maxOffSet;
    [Header("REFERENCE")] 
    [SerializeField] private GameObject onHitPrefab;
    [SerializeField] private Transform holder;
    
    public void ApplyEffect(Transform appearPosition)
    {
        GameObject onHit = Instantiate(onHitPrefab,holder);
        
        float xOffSet = Random.Range(minOffSet.x,maxOffSet.x);
        float yOffSet = Random.Range(minOffSet.y,maxOffSet.y);
        
        onHit.transform.position = appearPosition.position + new Vector3(xOffSet,yOffSet,0);
        onHit.SetActive(true);
    }

    public void RemoveEffect()
    {
        
    }

   
}
