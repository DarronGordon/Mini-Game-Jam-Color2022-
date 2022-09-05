using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformColorCtrl : MonoBehaviour
{
    [SerializeField]int level;
    
Color[] platformColor1 = { 
         Color.red,
         Color.green,
         };
Color[] platformColor;
    List<Color> platformColor2 = new List<Color>();

    List<Color> platformColor3 = new List<Color>();

    List<Color> platformColor4 = new List<Color>();
    void Start()
    {
        if(level==1){
          platformColor = platformColor1;
        }
   
    Color color = new Color();
    color = platformColor[Random.Range(0,2)];
    gameObject.GetComponent<MeshRenderer>().material.color=color;
    
    }

    void Update()
    {
        // r:Random.Range(0f,1f), g:Random.Range(0f,1f),b:Random.Range(0f,1f)
    }


}
