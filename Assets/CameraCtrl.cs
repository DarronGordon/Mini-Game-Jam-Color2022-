using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
public Transform target;

private void FixedUpdate() {
    
Vector3 targetPos = new Vector3(0f,target.position.y+7f,-95f);
 transform.position = Vector3.Lerp(transform.position,targetPos,0.2f);
   
}
}
