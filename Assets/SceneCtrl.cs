using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneCtrl : MonoBehaviour
{
    public static SceneCtrl instance;

    private void Awake() {
        if(instance==null)
        {
            instance = this;
        }
        else{
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
  public void ChangeScene (string sceneName)
  {
    SceneManager.LoadScene(sceneName);
  }
}
