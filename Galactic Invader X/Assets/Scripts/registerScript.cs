using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;

public class registerScript : MonoBehaviour
{
    public GameObject UsernameR;
    public GameObject EmailR;
    public GameObject PasswordR;
    public Button RegisterButton;

    public Image loading;

    private string username;
    private string email;
    private string password;
    private Button register;


    // Start is called before the first frame update
    void Start()
    {
        loading.enabled = false;
    }

    public void registerButton()
    {
        loading.enabled = true;
        SceneManager.LoadScene("BasicGamePlay");
    }

    // Update is called once per frame
    void Update()
    {
        username = UsernameR.GetComponent<InputField>().text;
        email = EmailR.GetComponent<InputField>().text;
        password = PasswordR.GetComponent<InputField>().text;
        register = RegisterButton.GetComponent<Button>();


        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (UsernameR.GetComponent<InputField>().isFocused)
            {
                EmailR.GetComponent<InputField>().Select();
            }
            if (EmailR.GetComponent<InputField>().isFocused)
            {
                PasswordR.GetComponent<InputField>().Select();
            }
        }

        //if the inputs are not blank, go to signinButton function.
        //accept both "Enter" and button press.
        if (username != "" && email != "" && password != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                registerButton();
            }

            register.onClick.AddListener(registerButton);

        }




    }
}
