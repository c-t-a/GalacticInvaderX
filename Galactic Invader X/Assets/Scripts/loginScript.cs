using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using System.IO;

public class loginScript : MonoBehaviour
{
    public GameObject UsernameSI;
    public Button SigninButton;
    public dataProcessing dataProcessing;

    public Image loading;

    private string username;
    private Button signin;

    

    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        loading.enabled = false;
        if (File.Exists(Application.persistentDataPath + "/player"))
        {
            SceneManager.LoadScene("Dashboard");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        username = UsernameSI.GetComponent<InputField>().text;
        signin = SigninButton.GetComponent<Button>();


        if (username != "")
        {
            
            if (Input.GetKeyDown(KeyCode.Return))
            {
                signinButton();
            } 

            signin.onClick.AddListener(signinButton);

        }
    }

    //load Basic game play scene
    public void signinButton()
    {
        loading.enabled = true;
        SceneManager.LoadScene("Dashboard");

    }
}
