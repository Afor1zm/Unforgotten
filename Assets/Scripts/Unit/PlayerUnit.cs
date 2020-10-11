using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    [SerializeField] private int _damage;
    public GameLogic _gameLogic;
    public GameObject _restartButtonObject;
    public Presenter _presenter;
    void Awake()
    {
        Score = 0;        
        Health = 100;
        CurrentHealth = Health;
        Damage = _damage;
        _presenter.UnitGetSprite(this);        
    }
   
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            _gameLogic.PauseGame();
            _restartButtonObject.SetActive(true);
        }
        
    }
}
