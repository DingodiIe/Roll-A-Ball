using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs2 : MonoBehaviour
{
    private Vector3 pos1 = new Vector3(40.8f,0.5f,3.36f);
     private Vector3 pos2 = new Vector3(37.8f,0.5f,3.36f);
     public float speed = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         transform.position = Vector3.Lerp (pos1, pos2, Mathf.PingPong(Time.time*speed, 1.0f));
    }
}
