using System;
using UnityEngine;

public class AlertVFX : MonoBehaviour,IVFX
{
    [Header("REFERENCE")]
    [SerializeField] private GameObject alertPrefab;
    [SerializeField] private Transform holder;
    private GameObject alert;

    public void Start()
    {
        alert = Instantiate(alertPrefab,holder);
    }

    public void ApplyEffect(Transform appearPosition)
    {
        alert.transform.position = appearPosition.position;
        alert.SetActive(true);
    }

    public void RemoveEffect()
    {
        alert.SetActive(false);
    }
    
}
