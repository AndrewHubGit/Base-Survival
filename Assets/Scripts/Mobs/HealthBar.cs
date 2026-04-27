using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image _healthBar;
    private void Start()
    {
        _healthBar = GetComponent<Image>();
    }
    public void HPBar(float _maxHealth, float _currentHealth)
    {
        _healthBar.fillAmount = _currentHealth / _maxHealth;
    }
}
