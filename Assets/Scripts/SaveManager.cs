using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    public SaveData activeSave;

    public bool hasLoaded;
    

    private void Awake()
    {
        instance = this;
        
        Load();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            DeleteSaveData();
        }
    }

    //Saves data to path %userprofile%\AppData\Local\Packages\<productname>\LocalState
    public void Save()
    {
        string dataPath = Application.persistentDataPath;

        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Create);
        serializer.Serialize(stream, activeSave);
        stream.Close();

        Debug.Log("Saved");
    }

    //Loads data from path
    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        if(System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();

            Debug.Log("Loaded");

            hasLoaded = true;
        }
    }
    
    //Deletes saved data
    public void DeleteSaveData()
    {
        string dataPath = Application.persistentDataPath;

            if(System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
           File.Delete(dataPath + "/" + activeSave.saveName + ".save");
        }

        Debug.Log("Deleted");
    }
}

//objects it is going to save
[System.Serializable]
public class SaveData
{
    public string saveName;

    public Vector3 respawnPosition;

    public bool enemyAlive;

    public int items;
    
    
}