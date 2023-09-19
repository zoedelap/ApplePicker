using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public float boundary = 10.0f;
    public float dropRate;
    public float initVel = 1f;
    public float changeRate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        if ((pos.x - 0.001 <= boundary &&  boundary <= pos.x + 0.001) || (pos.x - 0.001 <= -boundary && -boundary <= pos.x + 0.001))
        {
            initVel *= -1;
        }
        pos.x += initVel * Time.deltaTime;
        if (pos.x >= boundary)
        {
            pos.x = boundary;
        }
        transform.position = pos;

        
        
    }
}
