using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    public Button homeButton;

    // Start is called before the first frame update
    void Start()
    {
        // add listener to the shoot button
        homeButton.onClick.AddListener(OnButtonDown);
    }

    void OnButtonDown()
    {
        SceneManager.LoadScene("Dashboard");

    }


    // Update is called once per frame
    void Update()
    {

    }
}
