using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCoin : MonoBehaviour
{
    public string coin;
    public GameObject CoinObject;


    void Update()
    {
        coin = CoinObject.GetComponent<Text>().text;
    }
    public void save()
    {
        SaveLoadManage.SaveCoin(this);
    }

}