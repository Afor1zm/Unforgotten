using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject _enemyObjectPrefab;    
    public GameObject _spawner;
    public GameObject _playerObject;
    public PlayerUnit _playerUnit;
    public GameObject _enemyUIPrefab;
    public GameLogic _gameLogic;    
    public float _secondsBetweenSpawn;
    public Presenter _presenter;
    private float _elapsedTime = 0.0f;
    private Vector2 startPosition;
    private GameObject _enemyObject;
    private GameObject _enemyUIObject;
    private UIHealthBarPlayer _uIHealth;
    private EnemyUnit_Reaper _enemyUnit;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = _spawner.transform.position;
    }

    // Update is called once per frame
    void Update()
    {        
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _secondsBetweenSpawn)
        {
            _elapsedTime = 0;
            // Spawning Enemies
            _enemyObject = _gameLogic.SpawnFunction(_enemyObjectPrefab, new Vector3(startPosition.x, startPosition.y, 0f));
            _enemyUnit = _gameLogic.Seed_fieldsForEnemy(_enemyObject, _playerObject, _playerUnit);
            //if (_enemyUnit.transform.position.x > 0)
            //{
            //    _presenter.FlipSpriteLeft(_enemyUnit);
            //}
            // Spawning Enemies's UI
            _enemyUIObject = _gameLogic.SpawnFunction(_enemyUIPrefab, new Vector3(startPosition.x, startPosition.y, 0f));
            _uIHealth = _gameLogic.Seed_fieldsForUIEnemy(_enemyUIObject, _enemyUnit);
        }
    }
}
