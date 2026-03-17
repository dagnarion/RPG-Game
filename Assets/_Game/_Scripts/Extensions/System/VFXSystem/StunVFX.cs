using UnityEngine;

public class StunVFX : MonoBehaviour,IVFX
{
    [Header("REFERENCE")]
    [SerializeField] private GameObject stunPrefab;
    [SerializeField] private Transform holder;
    [SerializeField] private Transform appearPosition;
    private GameObject stun;

    public void Start()
    {
        stun = Instantiate(stunPrefab);
    }

    public void ApplyEffect()
    {
        stun.transform.position = appearPosition.position;
       if(!stun.activeSelf) stun.SetActive(true);
    }

    public void RemoveEffect()
    {
        stun.SetActive(false);
    }
}
