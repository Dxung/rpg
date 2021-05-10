using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger //khi bi knockback se cho 1 khoang thoi gian roi moi di chuyen
}
public class Enemy : MonoBehaviour 
{
    //truong serializefield giup serialize du lieu
    //1. giup hien va co the thay doi tren unity du cho la private
    //2. giup ghi de du lieu cho truoc trong script:
    //vi du trong nay de health la: protected float health=4f;
    // nhung trong unity de health = 14f thi khi bat lai unity, du lieu trong script la 4f nhung len game se dung 14f
    [SerializeField]
    protected float _health;

    [SerializeField]
    protected string _enemyName;

    [SerializeField]
    protected int _baseAttack;

    [SerializeField]
    protected float _moveSpeed;

    public FloatValue _maxHealth;
    protected EnemyState _currentState;

    private void Awake()
    {
        _health = _maxHealth._initialValue;
    }
    public EnemyState GetState()
    {
        return _currentState;
    }

    public void ChangeState(EnemyState newState)
    {
        if(_currentState != newState)
        {
            _currentState = newState;
        }
    }

    protected void TakeDamage(float damage) {
        
        _health -= damage;
        if(_health <= 0)
        {
            this.gameObject.SetActive(false);
        }

    }

    public void Knock(Rigidbody2D myRigidBody, float knockTime,float damage)
    {
        StartCoroutine(KnockCo(myRigidBody, knockTime));
        TakeDamage(damage);
    }
    private IEnumerator KnockCo(Rigidbody2D myRigidBody, float knockTime)
    {
        if (myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            this.ChangeState(EnemyState.idle);
            myRigidBody.velocity = Vector2.zero;
        }
    }
}
