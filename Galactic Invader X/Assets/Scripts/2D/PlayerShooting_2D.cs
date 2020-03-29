using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting_2D : MonoBehaviour
{
    public float fireRate;

    private float nextFire;

    public GameObject shot;

    public Transform shotSpawn;

    public FireZone_2D fireZone;

    public GameController_2D gameController;

    private bool canFire;

    void Update()
    {
        
        if (gameController.StopShooting()==false)
        {
            if (fireZone.CanFire() && Time.time > nextFire)
            {
                nextFire = Time.time + 1 / fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
                FindObjectOfType<AudioManager_2D>().Play("PlayerShooting_2D");
            }
        }
        else { 
        
        }
    }
}
