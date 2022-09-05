using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public static LevelGenerator instance;
    [SerializeField]public Transform[] spawnPoints;
    [SerializeField]GameObject platformParent;
    Vector3 lastPos;
  //  public GameObject player;
    public GameObject platformPrefab;
      GameObject myPlat;

     // [SerializeField]List<GameObject> generatedPlatformList = new List<GameObject>();

      private void Awake() {
        if(instance == null)
        {
            instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
      }

      
public void GeneratePlatform(){
    //Select type of platform
    //check position if no other platforms within half a grid size then can instantiate
   // Vector3 newSpawnPos =  new Vector3 (Random.Range(-4f,4f),player.transform.position.y + (11f + Random.Range(0f,.5f)),5f);
     Vector3 platformPos = spawnPoints[Random.Range(0,3)].position;
     if(lastPos == platformPos)
     {
       platformPos = spawnPoints[Random.Range(0,3)].position;
     }
     else if(lastPos!=platformPos)
     {
    Vector3 newSpawnPos =  new Vector3 (platformPos.x,platformPos.y,5f);
     
    //instantiate the chosen platform under a parent gameobject in the position accepted 
   myPlat = (GameObject)Instantiate(platformPrefab,  newSpawnPos,Quaternion.identity);

   lastPos = myPlat.transform.position;
     }
}



}
