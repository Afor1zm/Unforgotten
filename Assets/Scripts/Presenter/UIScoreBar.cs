using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreBar : MonoBehaviour
{
    public Unit _unit;
    public Text _scoreLabel;
    public Text _hpLabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _scoreLabel.text = $"{_unit.Score}";
        _hpLabel.text = $"{_unit.Health} / {_unit.CurrentHealth}";
    }
}
