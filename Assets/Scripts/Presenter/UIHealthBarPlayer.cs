using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBarPlayer : MonoBehaviour
{
    public Image _healthBar;    
    public Unit _unit;    
    
    void Start()
    {        
        _healthBar.fillAmount = _unit.Health;
    }

    // Update is called once per frame
    void Update()
    {
        _healthBar.fillAmount = (_unit.CurrentHealth / _unit.Health);        
    }
}
