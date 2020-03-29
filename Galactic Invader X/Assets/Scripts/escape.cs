using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class escape : MonoBehaviour
{
    public Button escapeButton;

    // Start is called before the first frame update
    void Start()
    {
        // add listener to the shoot button
        escapeButton.onClick.AddListener(OnButtonDown);
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
