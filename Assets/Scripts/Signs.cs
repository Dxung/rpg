using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Signs : MonoBehaviour
{
    [SerializeField]
    private GameObject _dialogBox;

    [SerializeField]
    private Text _dialogText;

    [SerializeField]
    private string _dialog;

    private bool _playerInRange;
    private PlayerMovement _playerMove;
    private Animator _playerAnimator;

 
   
    private void Update()
    {
       if(_playerInRange == true && Input.GetButtonDown("attack") )
        {
            //neu dang tat thi:
            //1. chuyen trang thai sang interact(3);
            //2. tat animation walk
            //3. bat dialogBox
            //4. Gan doan text bang string minh muon
            if (! _dialogBox.activeInHierarchy)
            {
                _playerMove.ChangeState(3);
                _playerAnimator.SetBool("moving", false);
                _dialogBox.SetActive(true);
                _dialogText.text = _dialog;

            }

            //neu dang bat thi:
            //1. tat hoi thoai
            //2. cho 1 chut
            //3. chuyen trang thai ve lai walk(1)
            else
            {
                _dialogBox.SetActive(false);
                _playerMove.ChangeState(1);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerMove = other.gameObject.GetComponent<PlayerMovement>();
            _playerAnimator = other.gameObject.GetComponent<Animator>();
            _playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInRange = false;
        }
    }

    //IEnumerator BreakCo()
    //{
    //    _dialogBox.SetActive(false);
    //    yield return null;
    //    _playerMove.ChangeState(1);

    //}



}