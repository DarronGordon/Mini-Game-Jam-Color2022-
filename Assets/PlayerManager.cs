using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LootLocker.Requests;

public class PlayerManager : MonoBehaviour
{
   [SerializeField]TMP_InputField playerNameInputField;

    public static PlayerManager instance;

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
   public void SetPlayerName()
   {
    LootLockerSDKManager.SetPlayerName(playerNameInputField.text,(response)=>
    {
        if(response.success){
            Debug.Log("successfully set player name");
        }
        else 
        {
            Debug.Log("Could not set player name " + response.Error);
        }
    });
   }
}
