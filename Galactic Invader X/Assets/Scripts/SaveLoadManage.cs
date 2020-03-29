using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public static class SaveLoadManage 
{

    // Saving player name
    public static void savePlayer(Player player)
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream stream = new FileStream(Application.persistentDataPath + "/player", FileMode.Create);

        PlayerData data = new PlayerData(player);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static string[] LoadPlayer()
    {
        if (File.Exists(Application.persistentDataPath + "/player"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player", FileMode.Open);

            PlayerData data = bf.Deserialize(stream) as PlayerData;

            stream.Close();

            return data.stats;
        }

        else {
            Debug.LogError("File doesn't exist");
            return new string[0];
        }
    }

    // saving score
    public static void SaveScore(GameScore gameScore)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/score", FileMode.Create);

        ScoreData data = new ScoreData(gameScore);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static string[] LoadScore()
    {
        if (File.Exists(Application.persistentDataPath + "/score"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/score", FileMode.Open);

            ScoreData data = bf.Deserialize(stream) as ScoreData;

            stream.Close();

            return data.stats1;
        }

        else
        {
            Debug.LogError("File doesn't exist");
            return new string[0];
        }
    }

    // saving coin
    public static void SaveCoin(GameCoin gameCoin)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/coin", FileMode.Create);
        CoinData data = new CoinData(gameCoin);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static string[] LoadCoin()
    {
        if (File.Exists(Application.persistentDataPath + "/coin"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/coin", FileMode.Open);

            CoinData data = bf.Deserialize(stream) as CoinData;

            stream.Close();

            return data.stats2;
        }

        else
        {
            Debug.LogError("File doesn't exist");
            return new string[0];
        }
    }
}




[Serializable]
public class PlayerData
{
    public string[] stats;

    public PlayerData(Player player)
    {
        stats = new string[1];
        stats[0] = player.username;
    }
}

[Serializable]
public class ScoreData
{
    public string[] stats1;

    public ScoreData(GameScore gameScore)
    {
        stats1 = new string[1];
        stats1[0] = gameScore.score;
    }
}

[Serializable]
public class CoinData
{
    public string[] stats2;

    public CoinData(GameCoin gameCoin)
    {
        stats2 = new string[1];
        stats2[0] = gameCoin.coin;
    }
}
