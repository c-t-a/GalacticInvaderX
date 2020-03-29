using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class profilePgScript : MonoBehaviour
{

    public Text usernameDisplay;


    // Start is called before the first frame update
    void Start()
    {
        Load();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load()
    {
        string[] loadstats = SaveLoadManage.LoadPlayer();
        usernameDisplay.text = loadstats[0];

    }


}
