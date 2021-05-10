using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//khong nam trong 1 Scene nao ca
//do do', co' the? dung` trong nhieu` scene 
//k co start va update do k trong 1 scene nao ca
//
//vi k trong scene nao ca, nen khi tat/chuyen scene, cac gia tri se duoc luu lai

[CreateAssetMenu]
public class FloatValue : ScriptableObject,ISerializationCallbackReceiver
{
    public float _initialValue;

    [HideInInspector]
    public float _runtimeValue;//thuc hien thay doi tren nay

    //sau khi unload tat ca khoi game
    public void OnAfterDeserialize()
    {
        _runtimeValue = _initialValue;//sau khi thoat game, gia tri se dua ve mac dinh(initialvalue)
    }

    //load tat ca 
    public void OnBeforeSerialize()
    {

    }

    






   
}

//voi FloatValue, ta co the tao ra cac trang thai cua player khi dung cac vu khi khac nhau
//Serialization la viec Load/Unload object tu memory
