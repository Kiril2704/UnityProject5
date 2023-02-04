using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnEvent(EVENT_TYPE Event_type, Component Sender, System.Object Param = null);

public class EventManagerWithoutDictionary : MonoBehaviour
{
    public List<OnEvent> events = new ();

    public static EventManagerWithoutDictionary Instance {get; private set;}
    
    public void AddEvent(OnEvent _event)
    {
       events.Add(_event);
    }

    public void PostNotification(EVENT_TYPE Event_type, Component Sender, System.Object Param = null)
    {
        Debug.Log("PostnNotification");
        foreach (var e in events)
        {
            e(Event_type, this,Param); // 
            Debug.Log("PostnNotificationForeach");
        }
    }





    void Awake()
    {
        //If no instance exists, then assign this instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            DestroyImmediate(this);
    }
}
