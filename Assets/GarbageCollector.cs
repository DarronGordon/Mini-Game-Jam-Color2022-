using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollector : MonoBehaviour
{
private void OnTriggerEnter(Collider other) 
{
    LevelGenerator.instance.GeneratePlatform();

    if(other.gameObject.CompareTag("player"))
    {

    }
        Destroy(other.gameObject);
}
}
