using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
public class GameManager : MonoBehaviour
{
        public static GameManager instance;

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
  void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });
    }
}
