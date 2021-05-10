using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;


public class RoomMove : MonoBehaviour
{
    [SerializeField]
    private Vector2 _cameraChangeMin;

    [SerializeField]
    private Vector2 _cameraChangeMax;

    [SerializeField]
    private Vector3 _playerChange;

    [SerializeField]
    private bool _needText;

    [SerializeField]
    private string _placeName;

    [SerializeField]
    private GameObject _text;

    [SerializeField]
    private Text _placeText;

   
    private CameraMove _cam;
    
    private void Start()
    {
        //lay ra thuoc tinh Camera Movement cua camera dau tien co tag MainCamera
        _cam = Camera.main.GetComponent<CameraMove>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            _cam.ChangeMin(_cameraChangeMin);
            _cam.ChangeMax(_cameraChangeMax);
            other.transform.position += _playerChange;
            if (_needText)
            {
                StartCoroutine(placeNameCo());
            }
        }
    }
    //ham nay chay song song voi cac tien trinh dang xay ra, o day phu trach viec bat/tat Text.
    private IEnumerator placeNameCo()
    {
        _text.SetActive(true);
        _placeText.text = _placeName;
        yield return new WaitForSeconds(2.5f);// ham nay giup cho 1 khoang thoi gian cho truoc , truoc khi quay lai doan lenh tiep theo
        _text.SetActive(false);
    }
}
