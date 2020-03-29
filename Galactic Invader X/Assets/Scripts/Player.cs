using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public string username;
    public GameObject UsernameSI;


    void Update()
    {
        username = UsernameSI.GetComponent<InputField>().text;
    }
    public void save()
    {
        SaveLoadManage.savePlayer(this);
    }

}
