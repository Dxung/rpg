using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public string _sceneToLoad;
    public Vector2 _playerPosition;
    public VectorValue _playerStorage;
    public GameObject _fadeInPanel;
    public GameObject _fadeOutPanel;
    public float _fadeWait;



    private void Awake()
    {
        if(_fadeInPanel != null)
        {
            GameObject panel = Instantiate(_fadeInPanel, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
           

            _playerStorage._initialValue = _playerPosition; 
            //SceneManager.LoadScene(_sceneToLoad);//tranh destroy scene
            StartCoroutine(FadeCo());

        }
    }

    public IEnumerator FadeCo()
    {

        if(_fadeOutPanel != null)
        {
            Instantiate(_fadeOutPanel, Vector3.zero, Quaternion.identity);

        }

        yield return new WaitForSeconds(_fadeWait);
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(_sceneToLoad);
        while(! asyncOperation.isDone)
        {
            yield return null;
        }
    }


}
