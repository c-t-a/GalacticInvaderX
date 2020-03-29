using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

[Serializable]
public class dataProcessing
{
    private string DataPath = "/GameDB";
    //private playerData playerinfo;


    // Start is called before the first frame update
    void Start()
    {

        // print("Data path is " + Application.persistentDataPath + DataPath);

        //loadData();

        //if (playerinfo != null)
        //{
        //    print("Username is " + playerinfo.Username);
        //}
    }


    // create the data file and encypt the file
    public void saveData(string username)
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();

            file = File.Create(Application.persistentDataPath + DataPath);

           // playerData first = new playerData(username);

          //  bf.Serialize(file, first);

        } catch (Exception e)
        {
            if (e != null)
            {
                //Handle Expection
            }
        } finally
        {
            if(file != null)
            {
                file.Close();
            }
        }
    }

    // load the data file and decypt the file
    public void loadData()
    {
        FileStream file = null;

        try
        {
            BinaryFormatter bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + DataPath, FileMode.Open);
           // playerinfo = bf.Deserialize(file) as playerData;
        }
        catch(Exception e)
        {
            if( e != null) { }
        }
        finally
        {
            if (file == null)
            {
                file.Close();
            }
        }
    }
}




