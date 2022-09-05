using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
[SerializeField]float jumpThrust;

private void OnCollisionEnter(Collision other) {
    Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
    rb.velocity = new Vector3(rb.velocity.x,jumpThrust*Time.deltaTime,rb.velocity.z);
}
}
