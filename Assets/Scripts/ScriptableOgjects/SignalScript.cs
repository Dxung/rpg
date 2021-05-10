using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//day la 1 script ton tai trong bo nho chu k co tren scene va k tac dong truc tiep vao scene
//no se noi truyen di tin hieu giup cac object biet duoc nen lam gi

[CreateAssetMenu]
public class SignalScript : ScriptableObject
{
    public List<SignalListener> _listeners = new List<SignalListener>();

    public void Raise()
    {
        for (int i = _listeners.Count - 1; i >= 0; --i)//de phong out of index
        {
            _listeners[i].OnSignalRaise();
        }
    }

    public void RegisterListener (SignalListener listener)
    {
        _listeners.Add(listener);
    }
    public void DeRegisterListener(SignalListener listener)
    {
        _listeners.Remove(listener);
    }
}
/*
 Ve ham Raise, no se thuc hien tuan tu cac SignalListener da duoc add vao bang cach goi ham OnSignalRaise() cua chung
 
 
 
 */