using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class webCamScript : MonoBehaviour
{
    // reference to the "plane" gameobject 
    public GameObject webCameraPlane;
    // create Button
    public Button shootButton;
    public Button restartButton;

    public int count = 0;

    public int score = 50;
    public int totalScore = 0;

    public Text countDisplay;
    public Text scoreDisplay;

    public GameObject alienYellow;

    //set custom range for random position
    public float MinX = -850;
    public float MaxX = 850;
    public float MinY = -500;
    public float MaxY = 500;

    //for 3d you have z position
    public float MinZ = -1500;
    public float MaxZ = -4000;

    // timer
    public float targetTime = 30.0f;
    public Text timerDisplay;
    /*public Sprite spriteBack;*/
    public bool gameEnd = false;
    public Image gameoverDisplay;
    public Image crosshair;

/*    public HealthBar healthBar;*/
    //public string damage = "100";

    //public string damange = "100";
    //public GameObject popuptext;


    /*    public int InvadersLimit = 10;
        public GameObject[] YellowInvaders = new GameObject[0];
        GameObject YellowInvader;

        //in order for invaders to not overlap
        public float checkArea = 3f;

        //try again for 10 times if overlap
        public int maxSpawnAttemptsPerInvader = 10;*/

    // Start is called before the first frame update
    void Start()
    {
        
        gameoverDisplay.enabled = false;
        restartButton.gameObject.SetActive(false);

       // popuptext.enabled = false;
       /* spriteBack = Resources.Load<Sprite>("home");*/


        // check if we are on mobile platform
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
        shootButton.onClick.AddListener(OnButtonDown);
        restartButton.onClick.AddListener(OnButtonDown);


        // create new web cam texture
        WebCamTexture webCameraTexture = new WebCamTexture();

        // take that webcam texture and apply it to the main web cam texture of the webcameraplane that we created
        webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;

        // play that web cam texture
        webCameraTexture.Play();

        countDisplay.text = "Invaders: 0/5";
        scoreDisplay.text = "0";

    }

    void Spawn()
    {
        float x;
        float y;
        float z;
        x = Random.Range(MinX, MaxX);
        y = Random.Range(MinY, MaxY);
        z = Random.Range(MinZ, MaxZ);
        GameObject invader1 = Instantiate(alienYellow, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        x = Random.Range(MinX, MaxX);
        y = Random.Range(MinY, MaxY);
        z = Random.Range(MinZ, MaxZ);

        GameObject invader2 = Instantiate(alienYellow, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        x = Random.Range(MinX, MaxX);
        y = Random.Range(MinY, MaxY);
        z = Random.Range(MinZ, MaxZ);

        GameObject invader3 = Instantiate(alienYellow, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        x = Random.Range(MinX, MaxX);
        y = Random.Range(MinY, MaxY);
        z = Random.Range(MinZ, MaxZ);

        GameObject invader4 = Instantiate(alienYellow, new Vector3(x, y, z), Quaternion.identity) as GameObject;
        x = Random.Range(MinX, MaxX);
        y = Random.Range(MinY, MaxY);
        z = Random.Range(MinZ, MaxZ);

        GameObject invader5 = Instantiate(alienYellow, new Vector3(x, y, z), Quaternion.identity) as GameObject;

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
        if (gameEnd)
        {
            gameEnd = false;
            SceneManager.LoadScene("BasicGamePlay");

        }
        else
        {
            // play shooting sound and show effect for every shot
            GetComponent<AudioSource>().Play();

            GameObject laser = Instantiate(Resources.Load("Magic fire 1", typeof(GameObject))) as GameObject;
            laser.transform.position = transform.position;
            Destroy(laser, 2);

            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {

                count += 1;
                totalScore = score * count;
                countDisplay.text = "Invaders: " + count.ToString() + "/5";
                scoreDisplay.text = totalScore.ToString();

                GameObject explosion = Instantiate(Resources.Load("Explosion", typeof(GameObject))) as GameObject;
                explosion.transform.position = transform.position;
                Destroy(explosion, 2);

                Destroy(hit.transform.gameObject);
            }

            // go to winning scene if all invaders are gone
            if (count == 5)
            {
                SceneManager.LoadScene("WinningScene");
            }
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        // update every frame
        Quaternion cameraRotation = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);

        // set local rotation of this camera to that of camera rotation from gyro values.
        this.transform.localRotation = cameraRotation;

        // timer
        targetTime -= Time.deltaTime;
        timerDisplay.text = Mathf.Round(targetTime).ToString() + "s";

        if (targetTime <= 0.0f)
        {
            timerEnded();

        }
    }

    void timerEnded()
    {
        timerDisplay.text = "0s";
       /* shootButton.image.sprite = spriteBack;*/
        gameEnd = true;
        gameoverDisplay.enabled = true;
        Destroy(crosshair);
        shootButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
    }
}

