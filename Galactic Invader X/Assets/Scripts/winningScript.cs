using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class winningScript : MonoBehaviour
{
    public GameObject webCameraPlane;
    public Button pickButton;

    public int count = 0;
    public int coins = 50;
    public int totalCoins = 50;

    public Text countDisplay;
    public Text coinsDisplay;

    /*public Sprite spriteBack;*/
    public GameObject crosshair;

    public GameObject coinBag;

    //set custom range for random position
    public float MinX = -850;
    public float MaxX = 850;
    public float MinY = -500;
    public float MaxY = 500;

    //for 3d you have z position
    public float MinZ = -530;
    public float MaxZ = -3000;

    // Start is called before the first frame update
    void Start()
    {
        // spriteBack = Resources.Load<Sprite>("home");


        if (Application.isMobilePlatform)
        {
            // create cameraParent object 
            GameObject cameraParent = new GameObject("camParent");
            // set that cameraParent transform to THIS main camera
            cameraParent.transform.position = this.transform.position;
            // set camera parent relationship
            this.transform.parent = cameraParent.transform;
            // only the camera setup can rotate but the values are zero out
            cameraParent.transform.Rotate(Vector3.right, 90);

        }

        // enable gyro
        Input.gyro.enabled = true;

        Spawn();

        // add listener to the shoot button
        pickButton.onClick.AddListener(OnButtonDown);

        // create new web cam texture
        WebCamTexture webCameraTexture = new WebCamTexture();

        // take that webcam texture and apply it to the main web cam texture of the webcameraplane that we created
        webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;

        // play that web cam texture
        webCameraTexture.Play();

        countDisplay.text = "Coin Bags: 0/5";
        coinsDisplay.text = "0";

    }

    void Spawn()
    { 
        float x;
        float y;
        float z;
        x = Random.Range(MinX, MaxX);
        y = Random.Range(MinY, MaxY);
        z = Random.Range(MinZ, MaxZ);

        GameObject coinBag1 = Instantiate(coinBag, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        x = Random.Range(MinX, MaxX);
        y = Random.Range(MinY, MaxY);
        z = Random.Range(MinZ, MaxZ);
        GameObject coinBag2 = Instantiate(coinBag, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        x = Random.Range(MinX, MaxX);
        y = Random.Range(MinY, MaxY);
        z = Random.Range(MinZ, MaxZ);
        GameObject coinBag3 = Instantiate(coinBag, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        x = Random.Range(MinX, MaxX);
        y = Random.Range(MinY, MaxY);
        z = Random.Range(MinZ, MaxZ);
        GameObject coinBag4 = Instantiate(coinBag, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        x = Random.Range(MinX, MaxX);
        y = Random.Range(MinY, MaxY);
        z = Random.Range(MinZ, MaxZ);
        GameObject coinBag5 = Instantiate(coinBag, new Vector3(x, y, z), Quaternion.identity) as GameObject;

        //overlap 
        /*for (int i = 0; i < InvadersLimit; i++)
        {
            YellowInvader = YellowInvaders[Random.Range(0, YellowInvaders.Length)];

            // Create a position variable
            Vector3 position = Vector3.zero;

            // whether or not we can spawn in this position
            bool validPosition = false;

            // How many times we've attempted to spawn this Invader
            int spawnAttempts = 0;

            // While we don't have a valid position 
            //  and we haven't tried spawning this obstable too many times
            while (!validPosition && spawnAttempts < maxSpawnAttemptsPerInvader)
            {
                // Increase our spawn attempts
                spawnAttempts++;

                // Pick a random position
                position = new Vector3(Random.Range(-50.0f, 50.0f), 0, Random.Range(-50.0f, 50.0f));

                // This position is valid until proven invalid
                validPosition = true;

                // Collect all colliders within our Invader Check Radius
                Collider[] colliders = Physics.OverlapSphere(position, checkArea);

                // Go through each collider collected
                foreach (Collider col in colliders)
                {
                    // If this collider is tagged "Invader"
                    if (col.tag == "Invader")
                    {
                        // Then this position is not a valid spawn position
                        validPosition = false;
                    }
                }
            }

            // If we exited the loop with a valid position
            if (validPosition)
            {
                // Spawn the Invader here
                Instantiate(YellowInvader, position + YellowInvader.transform.position, Quaternion.identity);
            }
        }*/
    }

    void OnButtonDown()
    {

        // go to menu when pressed after the button icon is changed 
        if (count > 5)
        {
            SceneManager.LoadScene("Dashboard"); 

        }

        else
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // play coin sound
                GetComponent<AudioSource>().Play();
                count += 1;
                totalCoins = coins * count;
                countDisplay.text = "Coin Bags: " + count.ToString() + "/5";
                coinsDisplay.text = totalCoins.ToString();

                Destroy(hit.transform.gameObject);

            }
        }

        // change the button and make crosshair disappear when all coinbags are collected
        if (count == 5)
        {

            // pickButton.image.sprite = spriteBack;
            Destroy(crosshair);
            pickButton.gameObject.SetActive(false);
            count += 1;

        }


    }


    // Update is called once per frame
    void Update()
    {

        // update every frame
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);

        // set local rotation of this camera to that of camera rotation from gyro values.
        this.transform.localRotation = cameraRotation;

    }
}
