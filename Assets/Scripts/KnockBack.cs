using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    [SerializeField]
    private float _thrust; //muc do cua luc. ma player tac dong (phuc vu cho viec knockback)

    [SerializeField]
    private float _knockTime;

    [SerializeField]
    private float _damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Ve viec dung other.gameObject.CompareTag thay cho other.CompareTag boi vi no se hieu qua hon khi ta cho biet doi tuong cu the la gi
        // va thay vi dung other.tag == se ton nhieu bo nho va thoi gian xu li hon la dung compareTag
        if (other.gameObject.CompareTag("enemies") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hitBody = other.GetComponent<Rigidbody2D>();
            if (hitBody != null)
            {
                Vector2 difference = hitBody.transform.position - transform.position;
                difference = difference.normalized * _thrust;
                hitBody.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("enemies"))
                {
                    hitBody.GetComponent<Enemy>().ChangeState(EnemyState.stagger);//chuyen state thanh stagger                   
                    other.GetComponent<Enemy>().Knock(hitBody, _knockTime, _damage);
                }

                if (other.gameObject.CompareTag("Player"))
                {
                    if (other.GetComponent<PlayerMovement>().GetCurrentState() != PlayerState.stagger)
                    {

                        hitBody.GetComponent<PlayerMovement>().ChangeState(PlayerState.stagger);//chuyen state thanh stagger
                        other.GetComponent<PlayerMovement>().Knock(_knockTime, _damage);
                    }
                }
            }
        }
    }
}
//luu y: vi dua vao trigger ma ta co 2 collision nen se an damage 2 lan
// 1 giai phap do la : tao ra 1 gameObject con cua Log, 1 cai se dong vai tro nhu hurtbox, va co tag "Collision" de chi bi trigger 1 lan

 