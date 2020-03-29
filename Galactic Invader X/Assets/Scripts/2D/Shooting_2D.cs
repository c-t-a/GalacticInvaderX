﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_2D : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 screenBound;
    private float speedShooting = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speedShooting);
        screenBound = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > screenBound.y * -2)
        {
            Destroy(this.gameObject);
        }
    }
}
