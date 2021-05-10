using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Image[] _hearts;
    public Sprite _fullHeart;
    public Sprite _halfHeart;
    public Sprite _emptyHeart;
    public FloatValue _heartContainers;
    public FloatValue _playerCurrentHealth;

    private void Start()
    {
        InitHeart();
    }

    public void InitHeart()
    {
        for (int i = 0; i < _heartContainers._initialValue; i++)
        {
            _hearts[i].gameObject.SetActive(true);
            _hearts[i].sprite = _fullHeart;
        }
    }

    public void UpdateHeart()
    {/*moi lan cham vao enemy se tru = damage, voi Log la 1
       lan dau, mau la 6 (moi 2 diem mau tuong duong 1 hp)
       temp =3 nen i=2 = temp -1 ==> full ca
       neu bi tan cong, curr=5 -> temp = 2.5
       i=2 thuoc else nen con half
       ...
     */
        float tempHealth = _playerCurrentHealth._runtimeValue / 2;
        for(int i=0; i < _heartContainers._runtimeValue; i++)
        {
            if (i <=tempHealth-1)
            {
                _hearts[i].sprite = _fullHeart;
            }
            else if(i >= tempHealth)
            {
                _hearts[i].sprite = _emptyHeart;
            }
            else
            {
                _hearts[i].sprite = _halfHeart;
            }
        }
    }
}
