using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    idle,
    walk,
    attack,
    interact,
    stagger
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private PlayerState _currentState;
    private Rigidbody2D _myRigidBody;
    private Animator _myAnimator;
    private Vector3 _change;
    public FloatValue _currentHealth;
    public SignalScript _playerHealthSignal;
    public VectorValue _startingPosition;

    public PlayerState GetCurrentState()
    {
        return _currentState;
    }

    private void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        ChangeState(PlayerState.idle);
        _myAnimator.SetFloat("moveX", 0);
        _myAnimator.SetFloat("moveY", -1);
        transform.position = _startingPosition._initialValue;
    }
    private void Update()   
    {
        _change = Vector3.zero;
        _change.x = Input.GetAxisRaw("Horizontal");
        _change.y = Input.GetAxisRaw("Vertical"); 
        
        //neu trang thai hien tai la walk/idle
        //neu co thay doi change --> chuyen thanh walk 
        //va nguoc lai
        if(_currentState == PlayerState.idle || _currentState == PlayerState.walk)
        {
            if(_change != Vector3.zero)
            {
                ChangeState(PlayerState.walk);
            }
            else
            {
                ChangeState(PlayerState.idle);
            }
        }

        //neu trang thai la walk/idle thi kiem tra xem co an nut attack khong
        //neu co thi thuc hien tan cong
        //roi neu khong tan cong thi moi chuyen qua update animation di chuyen
        if (_currentState == PlayerState.walk || _currentState == PlayerState.idle)
        {
            if (Input.GetButtonDown("attack"))
            {
                StartCoroutine(Attack());
            }
            else
            {
                UpdateAnimation();
            }
        }
    }
    private void FixedUpdate()
    {//neu trang thai hien tai la di chuyen ma co su thay doi
     //do trang thai hien tai da la walk/idle roi nen khong can them dieu kien nua
        MoveCharacter();
    }

    //ham de di chuyen nhan vat
    private void MoveCharacter()
    {
        if (_currentState == PlayerState.walk)
        {
            _myRigidBody.MovePosition(transform.position + _change.normalized * _speed * Time.fixedDeltaTime);
        }
    }

    private void UpdateAnimation()
    {
        if(_currentState == PlayerState.walk)
        {
            _myAnimator.SetFloat("moveX", _change.x);
            _myAnimator.SetFloat("moveY", _change.y);
            _myAnimator.SetBool("moving", true);
        }
        else if(_currentState == PlayerState.idle)
        {
            _myAnimator.SetBool("moving", false);

        }
    }

    private IEnumerator Attack()
    {
        ChangeState(PlayerState.attack);
        _myAnimator.SetBool("attacking", true);
        yield return null;
        _myAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        ChangeState(PlayerState.idle);
    }


    //ham dung de thay doi state nhan vat
    public void ChangeState(PlayerState state)
    {
        if (_currentState != state)
        {
            _currentState = state;
        }
    }

    public void Knock(float knockTime, float damage)
    {
        _currentHealth._runtimeValue -= damage;
        _playerHealthSignal.Raise();
        if (_currentHealth._runtimeValue > 0)
        {           
            StartCoroutine(KnockCo(knockTime));
        }else
        {
            this.gameObject.SetActive(false);
        }
    }
    
    private IEnumerator KnockCo(float knockTime)
    {
        if (_myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            _myRigidBody.velocity = Vector2.zero;
            this.ChangeState(PlayerState.idle);
            _myRigidBody.velocity = Vector2.zero;
        }
    }
}