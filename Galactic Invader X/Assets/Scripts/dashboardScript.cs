using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class dashboardScript : MonoBehaviour
{
    public Image loading;
    public Text usernameDisplay;
    //public string playerName;
    public Button btn2D, btn3D;
    public Button ProfileBtn;
    public Button settingBtn;


    // Start is called before the first frame update
    void Start()
    {
        Load();

        loading.enabled = false;
        Screen.orientation = ScreenOrientation.Landscape;
        //PlayerPrefs.SetString("name", PlayerPrefs.GetString("username"));
        //usernameDisplay.GetComponent<Text>().text = Name;
    }

    // Update is called once per frame
    void Update()
    {
        btn2D.onClick.AddListener(play2D);
        btn3D.onClick.AddListener(play3D);
        ProfileBtn.onClick.AddListener(profilePage);
        settingBtn.onClick.AddListener(toSetting);
    }
    private void play2D()
    {
        loading.enabled = true;
        SceneManager.LoadScene("Main_2D");
    }
    private void play3D()
    {
        loading.enabled = true;
        SceneManager.LoadScene("BasicGamePlay");
    }

    private void profilePage()
    {
        loading.enabled = true;
        SceneManager.LoadScene("profile");
    }
    public void Load()
    {
        string[] loadstats = SaveLoadManage.LoadPlayer();
        usernameDisplay.text = loadstats[0];
    }
    private void toSetting()
    {
        loading.enabled = true;
        SceneManager.LoadScene("Setting");
    }
}
