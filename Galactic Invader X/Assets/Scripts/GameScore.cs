using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    public string score;
    public GameObject ScoreObject;


    void Update()
    {
        score = ScoreObject.GetComponent<Text>().text;
    }
    public void save()
    {
        SaveLoadManage.SaveScore(this);
    }

}