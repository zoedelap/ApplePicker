using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private float boundary = 10.0f;
    [SerializeField] private float dropRate;
    [SerializeField] private float initVel = 1f;
    [SerializeField] private float changeRate;

    private bool gameOver = false;

    private float eps = 0.0001f;
    void Start()
    {
        Invoke(nameof(DropApple), 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Vector3 pos = transform.position;
            if ((pos.x - eps <= boundary && boundary <= pos.x + eps) || (pos.x - eps <= -boundary && -boundary <= pos.x + eps))
            {
                initVel *= -1;
            }
            pos.x += initVel * Time.deltaTime;
            if (pos.x <= -boundary) pos.x = -boundary;
            else if (pos.x >= boundary) pos.x = boundary;
            transform.position = pos;
        }
    }


    private void FixedUpdate()
    {
        if (Random.value <= changeRate)
        {
            initVel *= -1;
        }
    }

    void DropApple()
    {
        if (!gameOver) 
        { 
            GameObject apple = Instantiate<GameObject>(applePrefab);
            apple.transform.position = transform.position;
            Invoke(nameof(DropApple), dropRate);
        }
    }

    public void GameOver() { gameOver = true; }
}
