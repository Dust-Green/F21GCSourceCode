using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class LightSway : MonoBehaviour
{
    public float speed = 1.0f;
    public float distance = 1.0f;
    Vector3 pointA;
    Vector3 pointB;
    
    // Start is called before the first frame update
    void Start()
    {
        pointA = transform.position;
        pointB = new Vector3(transform.position.x + distance,transform.position.y,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float time = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(pointA, pointB, time);
    }
}

