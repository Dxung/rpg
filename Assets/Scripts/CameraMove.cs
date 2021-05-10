using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _updateSpeed;

    [SerializeField]
    private Vector2 _trackingOffset;

    [SerializeField]
    private Vector2 _maxPosition;

    [SerializeField]
    private Vector2 _minPosition;

    private Vector3 _offset;

    private void Start()
    {
        //luu y: tracking offset o day la Vector2, chi ra vi tri cua camera so voi Target tren man hinh chung ta nhin
        //       offset la khoang cach cua camera so voi Scene, giup co dinh camera trong kgian 3 chieu.
        _offset = (Vector3)_trackingOffset;
        _offset.z = transform.position.z - _target.position.z;// giup camera duy tri khoang cach voi Scene khi theo doi cac doi tuong tron canh
                                                            // thay vi lap Vector3 moi thi dung cai nay camera se luon cach scene
    }
    private void LateUpdate()
    {
        if (transform.position != _target.position)
        {
            Vector3 desiredPosition = _target.position + _offset;
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, _minPosition.x, _maxPosition.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, _minPosition.y, _maxPosition.y);


            Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, _updateSpeed);//Time.deltaTime lam giat khung hinh
            transform.position = smoothPosition;

        }
    }

    public void ChangeMax(Vector2 change )
    {
        _maxPosition += change;
    }

    public void ChangeMin(Vector2 change)
    {
        _minPosition += change;
    }
}
