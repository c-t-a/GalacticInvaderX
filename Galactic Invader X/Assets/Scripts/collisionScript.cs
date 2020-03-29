/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //for collision
    //one must have rigid body (enemy) and the other must have it's trigger checked
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag != "Bullet")
        {
            GameObject explosion = Instantiate(Resources.Load("Explosion", typeof(GameObject))) as GameObject;
            explosion.transform.position = transform.position;
            Destroy(col.gameObject);
            Destroy(explosion, 2);
            Destroy(gameObject);
        }

    }

}*/