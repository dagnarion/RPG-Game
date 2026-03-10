using System;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    [SerializeField] private HealthSystem health;

    private void OnEnable()
    {
        health.HealthChangeEvent += ChangeHealthBar;
        health.OnDeadEvent += HideHealthBar;
    }

    private void OnDisable()
    {
        health.HealthChangeEvent -= ChangeHealthBar;
        health.OnDeadEvent += HideHealthBar;
    }


    public void ChangeHealthBar(object sender, EventArgs eventArgs)
    {
        healthSlider.value = health.GetHealhAmountNozmalized();
    }

    public void HideHealthBar(object sender, EventArgs eventArgs)
    {
        healthSlider.gameObject.SetActive(false);
    }


}
