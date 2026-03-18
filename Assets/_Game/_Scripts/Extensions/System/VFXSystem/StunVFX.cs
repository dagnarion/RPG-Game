using UnityEngine;

public class StunVFX : MonoBehaviour,IVFX
{
    [Header("REFERENCE")]
    [SerializeField] private GameObject stunPrefab;
    [SerializeField] private Transform holder;
    private GameObject stun;

    public void Start()
    {
        stun = Instantiate(stunPrefab,holder);
    }

    public void ApplyEffect(Transform appearPosition)
    {
        stun.transform.position = appearPosition.position;
       if(!stun.activeSelf) stun.SetActive(true);
    }

    public void RemoveEffect()
    {
        stun.SetActive(false);
    }
}
