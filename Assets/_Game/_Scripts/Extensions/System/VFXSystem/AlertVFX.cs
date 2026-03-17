using System;
using UnityEngine;

public class AlertVFX : MonoBehaviour,IVFX
{
    [Header("REFERENCE")]
    [SerializeField] private GameObject alertPrefab;
    [SerializeField] private Transform holder;
    [SerializeField] private Transform appearPosition;
    private GameObject alert;

    public void Start()
    {
        alert = Instantiate(alertPrefab);
    }

    public void ApplyEffect()
    {
        alert.transform.position = appearPosition.position;
        alert.SetActive(true);
    }

    public void RemoveEffect()
    {
        alert.SetActive(false);
    }
    
}
