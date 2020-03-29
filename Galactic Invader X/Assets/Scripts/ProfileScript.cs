using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ProfileScript : MonoBehaviour
{
    public Image loading;
    public Button backBtn;
    
    public Text usernameDisplay;
    public Text highScore;
    public Text coin;

    // Start is called before the first frame update
    void Start()
    {
        Load();
        loading.enabled = false;
        Screen.orientation = ScreenOrientation.Landscape;
    }

    // Update is called once per frame
    void Update()
    {
        backBtn.onClick.AddListener(dashboard);
        
    }

    private void dashboard()
    {
        loading.enabled = true;
        SceneManager.LoadScene("Dashboard");
    }

    public void Load()
    {
        string[] loadstats = SaveLoadManage.LoadPlayer();
        usernameDisplay.text = loadstats[0];

        string[] loadstats1 = SaveLoadManage.LoadScore();
        highScore.text = loadstats1[0];

        string[] loadstats2 = SaveLoadManage.LoadCoin();
        coin.text = loadstats2[0];


    }

}
