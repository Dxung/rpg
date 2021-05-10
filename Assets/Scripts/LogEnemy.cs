using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogEnemy : Enemy
{
    [SerializeField]
    private float _chaseRadius;

    [SerializeField]
    private float _attackRadius;


    private Transform _homePosition;
    private Transform _target;
    private Rigidbody2D _myRigidBody;
    private Animator _anim;

    private void Start()
    {

        //FindWithTag: tra ve 1 active gameobject co tag Player
        // .transform: lay gia tri Transform cua doi tuong gameobject do
        _target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _myRigidBody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        this.ChangeState(EnemyState.idle);
       
        
    }

    private void FixedUpdate()
    {
        CheckDistance();
    }
    private void CheckDistance()
    {
        //float distance = Vector2.Distance(_target.position, transform.position);
        //neu vao trong tam duoi theo thi se duoi theo
        //delta o day la khoang thoi gian tinh tu frame truoc
        if (Vector3.Distance(_target.position, transform.position) <= _chaseRadius && Vector3.Distance(_target.position, transform.position) >= _attackRadius)
        {

            if (this.GetState() == EnemyState.idle || this.GetState() == EnemyState.walk && this.GetState() != EnemyState.stagger)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, _target.position, _moveSpeed * Time.deltaTime);
                ChangeAnim(temp - transform.position);//o truoc MovePosition neu k khi de sau MovePosition thi transform.position = temp mat roi 

                _myRigidBody.MovePosition(temp);
                this.ChangeState(EnemyState.walk);
                _anim.SetBool("wakeUp", true);

            }
            

        }   
        else if(Vector3.Distance(_target.position, transform.position) > _chaseRadius )
        {
            _anim.SetBool("wakeUp", false);

        }
    }
    
    private void SetAnimFloat(Vector2 setVector)
    {
        _anim.SetFloat("moveX", setVector.x);
        _anim.SetFloat("moveY", setVector.y);
    }

    public void ChangeAnim(Vector2 direction)
    {
        if(Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if(direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }

        }else if(Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }
}
