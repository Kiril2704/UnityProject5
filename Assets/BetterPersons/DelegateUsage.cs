using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//---------------------------------------------------
public class DelegateUsage : MonoBehaviour
{
    //Defines delegate type: param list
    public delegate void EventHandler(int Param1, int Param2);

    
    //Declare array of references to functions from Delegate type -
    // max 10 events
    public EventHandler[] EH = new EventHandler[10];

    public Dictionary<string, EventHandler> EventHandlerDictionary = new Dictionary<string, EventHandler>();


    /// <summary>
    /// Awake is called before start. Will add my Delegate
    /// HandleMyEvent to list
    /// </summary>
    /// 
    void Awake()
    {
        //Add my event (HandleMyEvent) to delegate list
        EH[0] = HandleMyEvent;
        EH[0] += HandleMyEvent2;
        EventHandlerDictionary["Simple"] = HandleMyEvent;
        
       var keys = EventHandlerDictionary.Keys.ToList();

        foreach (var pair in EventHandlerDictionary)
        {
            pair.Value(1,2);
            string key = pair.Key;  
        }
    }


   
    /// <summary>
    /// Will cycle through delegate list and call all events
    /// </summary>
    void Start()
    {

        
        //Loop through all delegates in list
        foreach (EventHandler e in EH)
        {
            //Call event here, if not null
            if (e != null) e(0, 0); //This calls the event
        }
    }



    /// <summary>
    /// This is a sample delegate event. Can be referenced by Delegate
    /// Type EventHandler
    /// </summary>
    /// <param name="Param1">Example param</param>
    /// <param name="Param2">Example param</param>
    void HandleMyEvent(int Param1, int Param2)
    {
        Debug.Log($"Event Called Param1 = {Param1} Param2 = {Param2}");
    }


    /// <summary>
    /// This is a sample delegate event. Can be referenced by Delegate
    /// Type EventHandler
    /// </summary>
    /// <param name="Param1">Example param</param>
    /// <param name="Param2">Example param</param>
    void HandleMyEvent2(int Param1, int Param2)
    {

        Debug.Log($"Event2 Called Param1 = {Param1} Param2 = {Param2}");
    }


}