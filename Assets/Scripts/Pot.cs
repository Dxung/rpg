using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField]
    private int _hpMax;

    private int _currentHp;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        _currentHp = _hpMax;
    }

    public void TakeDamage(int amount)
    {
        if(_currentHp < amount || _currentHp == amount)
        {
            _currentHp = 0;
            BeDestroy();
        }
        else
        {
            _currentHp -= amount;
        }
    }

    private void BeDestroy()
    {
        animator.SetBool("broken", true);
        StartCoroutine(BreakCo());
    }

    IEnumerator BreakCo()
    {
        yield return new WaitForSeconds(.3f);
        this.gameObject.SetActive(false);
    }




}
