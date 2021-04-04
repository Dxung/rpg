using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RoomMove : MonoBehaviour
{
    public Vector2 cameraChangeMin;
    public Vector2 cameraChangeMax;
    public Vector3 playerChange;
    private CameraMovement cam;

    public bool needText;
    public string placeName;
    public GameObject text;
    public Text placeText;

    private void Start()
    {
        //lay ra thuoc tinh Camera Movement cua camera dau tien co tag MainCamera
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cam.minPosition += cameraChangeMin;
            cam.maxPosition += cameraChangeMax;
            other.transform.position += playerChange;
            if (needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }
    //ham nay chay song song voi cac tien trinh dang xay ra, o day phu trach viec bat/tat Text.
    private IEnumerator placeNameCo()
    {
        text.SetActive(true);
        placeText.text = placeName;
        yield return new WaitForSeconds(2.5f);// ham nay giup cho 1 khoang thoi gian cho truoc , truoc khi quay lai doan lenh tiep theo
        text.SetActive(false);
    }
}
