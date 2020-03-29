using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryByContent_2D : MonoBehaviour
{
    public GameObject explosion, playerExplosion,coinObject;
    public int scoreValue,coinValue;
    private GameController_2D gameController;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController_2D>();
        }
        if(gameController == null)
        {
            Debug.Log("Can't find!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if(gameController.StopShooting() == true)
        {
            if (other.CompareTag("Boundary") || other.CompareTag("Coin"))
            {
                return;
            }
            FindObjectOfType<AudioManager_2D>().Play("CollectCoin_2D");
            gameController.CoinScore(coinValue);
            Destroy(coinObject.gameObject);
        }
        else
        {
            if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
            {
                return;
            }
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            if (other.CompareTag("Player"))
            {
                Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
                gameController.GameOver();
            }
            gameController.addScore(scoreValue);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
