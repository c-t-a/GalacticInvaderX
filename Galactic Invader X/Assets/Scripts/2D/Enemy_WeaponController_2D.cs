using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_WeaponController_2D : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float delay,fireRate;

    void Start()
    {
        InvokeRepeating("Fire",delay,fireRate);
    }

    // Update is called once per frame
    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        FindObjectOfType<AudioManager_2D>().Play("EnemyShooting_2D");
    }
}
