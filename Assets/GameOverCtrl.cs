using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCtrl : MonoBehaviour
{
public Transform target;

public static GameOverCtrl instance ;

[SerializeField]GameObject  gameOverPanel;
private void Awake() {
    if(instance == null){
        instance = this;
    }
    else{
        Destroy(gameObject);
    }
}

private void FixedUpdate() {
    if(target.GetComponent<Rigidbody>().velocity.y<0){return;}
Vector3 targetPos = new Vector3(0f,target.position.y-10f,5f);
 transform.position = Vector3.Lerp(transform.position,targetPos,0.2f);

}
private void OnTriggerEnter(Collider other) {
    if(other.gameObject.CompareTag("player"))
    {
        Debug.Log("Player should be dead");
        PlayerCtrl.instance.StartCoroutine("DieRoutine");
         gameOverPanel.SetActive(true);
         Leaderboard.instance.StartCoroutine("FetchTopHighscoresRoutine");
    }
}

}
