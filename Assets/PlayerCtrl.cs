using System.Diagnostics;
using UnityEngine;
using TMPro;
using System;
using System.Collections;
using LootLocker.Requests;

public class PlayerCtrl : MonoBehaviour
{
public static PlayerCtrl instance;
    float score;
    int scoreInt;
    public Leaderboard leaderboard;
  [SerializeField] float timer;
    [SerializeField]TextMeshProUGUI boostTimertxt;
        [SerializeField]TextMeshProUGUI scoretxt;
   [SerializeField]float movementSpeed;
 [SerializeField]float jumpThrust;
  AudioSource auds;
   float movement;
    Rigidbody rb;
bool canBoost;

private void Awake() {
    if(instance==null)
    {
        instance = this;
    }
}


    private void Start() {
        rb = GetComponent<Rigidbody>();
        auds = GetComponent<AudioSource>();
        score =0;
    }
    void Update()
    {
        HorizontalMovement();
        Boost();    
        UpdateScore();

    }


    private void UpdateScore()
    {
        if(score<transform.position.y){
                  score = transform.position.y;
        }
        else{
            return;
        }
    
       scoreInt = Mathf.RoundToInt(score);
       scoretxt.text=scoreInt.ToString();
    }

    private void  HorizontalMovement()
    {
        movement = Input.acceleration.x;

    }

    private void FixedUpdate() 
     {

    rb.velocity =new Vector3( movement* movementSpeed,rb.velocity.y,rb.velocity.z);

    }

    public void Boost()
{
    if (Input.touchCount > 0)
        {
            if (canBoost)
            {
              rb.velocity = new Vector3(rb.velocity.x,jumpThrust*Time.deltaTime,rb.velocity.z);
               boostTimertxt.gameObject.SetActive(false);
              canBoost=false;
              timer = Time.time + 5f;
        }
        }
    RestBoost();
    

}

    private void RestBoost()
    {
             if (timer <= Time.time)
 {
 canBoost=true;
 boostTimertxt.gameObject.SetActive(true);
 }
              
    }


public IEnumerator DieRoutine()
{
        ///show dead anim & sound 

    Time.timeScale=0f;
    yield return new WaitForSecondsRealtime(1f);
    yield return leaderboard.SubmitScoreRoutine(scoreInt);
    Time.timeScale=1f;

string memberID = "20";
int leaderboardID = 123;

LootLockerSDKManager.SubmitScore(memberID, scoreInt, leaderboardID, (response) =>
{
    if (response.statusCode == 200) {
        UnityEngine.Debug.Log("Successful");
    } else {
        UnityEngine.Debug.Log("failed: " + response.Error);
    }
});

  gameObject.SetActive(false);


 }

      
}