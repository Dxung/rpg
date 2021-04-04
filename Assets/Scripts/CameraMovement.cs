using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float updateSpeed = 4f;
    public Vector2 trackingOffset;
    public Vector3 offset;
    public Vector2 maxPosition;
    public Vector2 minPosition;

    private void Start()
    {
        //luu y: tracking offset o day la Vector2, chi ra vi tri cua camera so voi Target tren man hinh chung ta nhin
        //       offset la khoang cach cua camera so voi Scene, giup co dinh camera trong kgian 3 chieu.
        offset = (Vector3)trackingOffset;
        offset.z = transform.position.z - target.position.z;// giup camera duy tri khoang cach voi Scene khi theo doi cac doi tuong tron canh
                                                            // thay vi lap Vector3 moi thi dung cai nay camera se luon cach scene
    }
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.x = Mathf.Clamp(desiredPosition.x, minPosition.x, maxPosition.x);
        desiredPosition.y = Mathf.Clamp(desiredPosition.y, minPosition.y, maxPosition.y);


        Vector3 smoothPosition = Vector3.Lerp(transform.position,desiredPosition,updateSpeed*Time.deltaTime);
        transform.position = smoothPosition; 
        
       
    }




}
