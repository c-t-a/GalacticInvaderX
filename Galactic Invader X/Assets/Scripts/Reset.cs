using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public void deleteFile()
    {
        SceneManager.LoadScene("LoginScene");
        File.Delete(Application.persistentDataPath + "/player");
        File.Delete(Application.persistentDataPath + "/score");
        File.Delete(Application.persistentDataPath + "/coin");
    }

}
