//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//using System.IO;

//public class ExceptionLogger : MonoBehaviour
//{
//    //Internal reference to stream writer object
//    private System.IO.StreamWriter SW;

//    //Filename to assign log
//    public string LogFileName = "log2.txt";

//    //------------------------------------------------
//    // Use this for initialization
//    void Start()
//    {
//        //Make persistent
//        DontDestroyOnLoad(gameObject);

//        //Create string writer object
//       // SW = new System.IO.StreamWriter(Application.persistentDataPath + "/" +
//       //LogFileName);

//       // Debug.Log(Application.persistentDataPath + "/" +
//       //LogFileName);

//        SW = new System.IO.StreamWriter("E:\\"+ LogFileName);

        


//    }
//    //------------------------------------------------
//    //Register for exception listening, and log exceptions
//    void OnEnable()
//    {
//        Application.RegisterLogCallback(HandleLogNew);
//    }
//    //------------------------------------------------
//    //Unregister for exception listening
//    void OnDisable()
//    {
//        Application.RegisterLogCallback(null);
//    }

//    //------------------------------------------------
//    //Log exception to a text file
//    void HandleLogNew(string logString, string stackTrace, LogType type)
//    {
//        //If an exception or error, then log to file
//        if (type == LogType.Exception || type == LogType.Error)
//        {           
//            SW.WriteLine($"Logged at: {System.DateTime.Now} - Log Desc: {logString} - Trace: {stackTrace} - Type: {type}");
//            //SW.WriteLine("zdfgdzfg");
//        }
//    }
//    //------------------------------------------------
//    //Called when object is destroyed
//    void OnDestroy()
//    {
//        //Close file
//        SW.Close();
//    }
    
//}


