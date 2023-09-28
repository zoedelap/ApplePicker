using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    private static float bottonY = -20;

    void Update()
    {
        if (transform.position.y < bottonY) Destroy(this.gameObject);    
    }
}
