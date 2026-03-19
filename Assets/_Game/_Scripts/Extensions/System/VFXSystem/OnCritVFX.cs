using UnityEngine;

public class OnCritVFX : MonoBehaviour,IVFX
{
    [Header("CONFIG")] 
    [SerializeField] private Vector2 minOffSet;
    [SerializeField] private Vector2 maxOffSet;
    [Header("REFERENCE")] 
    [SerializeField] private Transform owner;
    [SerializeField] private GameObject onCritPrefab;
    [SerializeField] private Transform holder;
    
    public void ApplyEffect(Transform appearPosition)
    {
        GameObject onHit = Instantiate(onCritPrefab,holder); // objectPool in here
        
        float direction = owner.right.x;
        float xOffSet = Random.Range(minOffSet.x,maxOffSet.x);
        float yOffSet = Random.Range(minOffSet.y,maxOffSet.y);
        
        onHit.transform.position = appearPosition.position + new Vector3(xOffSet,yOffSet,0);
        
        if(direction == -1 ) onHit.transform.Rotate(0,180,0);
        onHit.SetActive(true);
    }

    public void RemoveEffect()
    {
        
    }
}
