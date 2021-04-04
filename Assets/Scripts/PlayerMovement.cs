using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    walk,
    attack,
    interact
}

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private PlayerState _currentState;
    private Rigidbody2D _myRigidBody;
    private Animator _myAnimator;
    private Vector3 _change;

    private void Start()
    {
        _myRigidBody = GetComponent<Rigidbody2D>();
        _myAnimator = GetComponent<Animator>();
        ChangeState(1);
        _myAnimator.SetFloat("moveX", 0);
        _myAnimator.SetFloat("moveY", -1);
    }
    private void Update()
    {
        _change = Vector3.zero;
        _change = Vector3.zero;
        _change.x = Input.GetAxisRaw("Horizontal");
        _change.y = Input.GetAxisRaw("Vertical");
        if(_currentState == PlayerState.walk) 
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
        if (_currentState == PlayerState.walk && _change != Vector3.zero) 
        {
            MoveCharacter();
        }
    }

    //ham de di chuyen nhan vat
    private void MoveCharacter()
    {

        _myRigidBody.MovePosition(transform.position + _change.normalized * _speed * Time.fixedDeltaTime);
    }

    private void UpdateAnimation()
    {
        if(_currentState == PlayerState.walk && _change != Vector3.zero)
        {
            _myAnimator.SetFloat("moveX", _change.x);
            _myAnimator.SetFloat("moveY", _change.y);
            _myAnimator.SetBool("moving", true);
        }
        else
        {
            _myAnimator.SetBool("moving", false);

        }
    }

    private IEnumerator Attack()
    {
        ChangeState(2);
        _myAnimator.SetBool("attacking", true);
        yield return null;
        _myAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(.3f);
        ChangeState(1);
    }


    //ham dung de thay doi state nhan vat
    public void ChangeState(int number)
    {
        switch (number)
        {
            case 1:
                _currentState = PlayerState.walk;
                break;

            case 2:
                _currentState = PlayerState.attack;
                break;

            case 3:
                _currentState = PlayerState.interact;
                break;
                          
        }
    }

}