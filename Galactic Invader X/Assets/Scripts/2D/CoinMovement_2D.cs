using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement_2D : MonoBehaviour
{
    private GameController_2D gameController;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
