using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlatform : MonoBehaviour
{

[SerializeField]Vector3 boxPosSize;
    [SerializeField]GameObject platformEffect;
   [SerializeField]GameObject  platformSparkleEffect;
    [SerializeField]float jumpThrust;
    [SerializeField]LayerMask platformLayer;
BoxCollider mc;
private void Start()
 {
    mc = GetComponent<BoxCollider>();

}


private void OnCollisionEnter(Collision other) {

    Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
    rb.velocity = new Vector3(rb.velocity.x,jumpThrust*Time.deltaTime,rb.velocity.z);
    StartPlatformEffect( other.gameObject.transform.position);

}

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("player"))
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if(gameObject.GetComponent<MeshRenderer>().material.color == Color.red)
            {
                 StartSparklePlatformEffect( other.gameObject.transform.position);
            }
            else
            {
    
              rb.velocity = new Vector3(rb.velocity.x,0f,rb.velocity.z);
              StartPlatformEffect( other.gameObject.transform.position);
            }
        }
    }












private void StartSparklePlatformEffect(Vector3 pos)
{
Instantiate(platformSparkleEffect,pos,Quaternion.identity);
}
    

private void StartPlatformEffect(Vector3 pos)
{
Instantiate(platformEffect,pos,Quaternion.identity);
}

}
