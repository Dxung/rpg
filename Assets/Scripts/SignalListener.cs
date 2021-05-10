using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//1 script gan vao object
//lang nghe tin hieu tu signal script va thuc hien tren object
public class SignalListener : MonoBehaviour
{

    public SignalScript _signal;
    public UnityEvent _signalEvent;
    public void OnSignalRaise()
    {
        _signalEvent.Invoke();//phuong thuc invoke se khoa cac luong khac lai, tru luong chua phuong thuc duoc invoke
    }

    private void OnEnable()
    {
        _signal.RegisterListener(this);
    }

    private void OnDisable()
    {
        _signal.DeRegisterListener(this);
    }
}
/*
 Khi object duoc enable hoac active --> onEnable()
va nguoc lai, --> onDisable()

voi onEnable(), them signalListener NAY` vao trong list cua signalScript
vi signalScript ton tai ngoai scene(trong bo nho) nen du lieu se duoc giu nguyen
 
 
 
 */



