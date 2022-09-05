using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;
public class Leaderboard : MonoBehaviour
{

public static Leaderboard instance;

int leaderboardID=5343;

[SerializeField]TextMeshProUGUI playerNames;
[SerializeField]TextMeshProUGUI playerScores;
    private void Awake() {
        if(instance == null){
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

 public IEnumerator SubmitScoreRoutine(int scoreToUpload)
 {
    bool done = false;
    string playerID = PlayerPrefs.GetString("PlayerID");
    LootLockerSDKManager.SubmitScore(playerID, scoreToUpload, leaderboardID, (response) =>
    {
        if(response.success)
        {
            Debug.Log("Successfully uploaded the score");
        }
        else{
            Debug.Log("Failed" + response.Error);
            done = true;
        }
    });
    yield return new WaitWhile(() => done == false);
 }


public IEnumerator FetchTopHighscoresRoutine()
{
    Debug.Log("FETCHING SCORES");
    bool done = false;
    LootLockerSDKManager.GetScoreList(leaderboardID, 10, 0,(response)=>{
        if(response.success)
        {
            string tempPlayerNames = "Names\n";
            string tempPlayerScores = "Scores\n";
   Debug.Log("FETCHING SCORES Success");
            LootLockerLeaderboardMember[] members = response.items;

            for(int i =0; i< members.Length;i++)
            {
                tempPlayerNames+=members[i].rank + ". ";
                if(members[i].player.name != null)
                {
                    tempPlayerNames += members[i].player.name;
                }
                else
                {
                    tempPlayerNames += members[i].member_id;
                }
                tempPlayerScores += members[i].score + "\n";
                tempPlayerNames += "\n";
            }
            done = true;
            playerNames.text = tempPlayerNames;
            playerScores.text = tempPlayerScores;
        }
        else{
            Debug.Log("Failed "+ response);
            done = true;
        }
    });
    yield return new WaitWhile(() => done == false);
}



}
