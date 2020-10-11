using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnemyUnit_Reaper : Unit, IPointerClickHandler
{
    public PlayerUnit PlayerUnit { get; set; }
    public GameObject _enemyObject;
    public GameObject _playerObject;
    public Rigidbody2D _enemyRigidBody;
    public PlayerUnit _playerUnit;
    public GameObject _enemyUI;
    public GameObject _damagePopUpPrefab;
    public GameObject _damagePopUpObject;
    //public TextMesh _damageLabel;
    public GameLogic _gameLogic;
    public Presenter _presenter;
    [SerializeField] float distanceBetweenPlayerAndEnemy;
    [SerializeField] float timeBetweenAttack;
    private float _elapsedTime;
    private bool OnAttackPosition { get { return _enemyObject.transform.position.x == endPosition.x; } }
    Vector2 endPosition;

    private void Start()
    {
        endPosition = _gameLogic.GetEndPosition(_playerObject, _enemyObject, distanceBetweenPlayerAndEnemy);        
        Score = 50;
        Damage = 25;
        Health = 100;
        CurrentHealth = Health;
        _elapsedTime = timeBetweenAttack;
        _presenter.UnitGetSprite(this);
        if (this.endPosition.x > 0 )
        {
            _presenter.FlipSpriteLeft(this);            
        }
        
    }

    private void Update()
    {        
        _presenter.UnitMove(_enemyObject,endPosition,_enemyRigidBody);
        _enemyUI.transform.position = _enemyObject.transform.position;        

        if (OnAttackPosition)
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime > timeBetweenAttack)
            {
                _gameLogic.TakeDamage(_playerUnit, Damage, _damagePopUpPrefab);                
                _elapsedTime = 0;                
            }            
        }
    }
    
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (Time.timeScale == 1)
        {
            if (this.endPosition.x < 0)
            {
                _presenter.FlipSpriteLeft(_playerUnit);
            }
            else
            {
                _presenter.FlipSpriteRight(_playerUnit);                
            }
            _gameLogic.TakeDamage(this, _playerUnit.Damage, _damagePopUpPrefab);
            if (CurrentHealth <= 0)
            {
                Destroy(_enemyUI);
                Destroy(_enemyObject);
                _playerUnit.Score += Score;
            }
        }                
    }
}