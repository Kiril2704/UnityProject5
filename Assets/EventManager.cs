using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


delegate double Function(double x);

public class EventManager : MonoBehaviour
{
    // Declare a delegate type for events
    public delegate void OnEvent(EVENT_TYPE Event_Type, Component Sender, object Param = null);


    // Use interface IListener
    //private Dictionary<EVENT_TYPE, List<IListener>> Listeners = new ();  // EventManager eventManager = new ();
    //
    // Use delegate  OnEvent
    private Dictionary<EVENT_TYPE, List<OnEvent>> dictionaryOfEventLists = new();  // EventManager eventManager = new ();   

    public static EventManager Instance { get; private set; }

    // 100 объектов слушают »нит
    // 10 из 100 слушают »зменение«доровь€

    public void AddEvent(EVENT_TYPE Event_Type, OnEvent _event)
    {
        List<OnEvent> eventList = null;  // OnEvent - delegate type to save methods like "void MethodName(EVENT_TYPE Event_Type, Component Sender, object Param = null)

        // Check existing event type key. If exists, add to list
        if (dictionaryOfEventLists.TryGetValue(Event_Type, out eventList))
        {
            //List exists, so add new item
            eventList.Add(_event);
            return;
        }

        // dictionaryOfEventLists[EVENT_TYPE.HEALTH_CHANGE] = new List<OnEvent> { player.OnEvent, null, npc.OnEvent};
        // dictionaryOfEventLists[EVENT_TYPE.GAME_INIT] = new List<OnEvent> { plane.OnEvent, npc.OnEvent};

        //Otherwise create new list as dictionary key
        eventList = new List<OnEvent> { _event };
        dictionaryOfEventLists.Add(Event_Type, eventList);

    }


    public void PostNotification(EVENT_TYPE Event_Type, Component Sender, System.Object Param = null)
    {
        //List of listeners for this event only
        List<OnEvent> eventList = null;

        //If no event exists, then exit
        if (!dictionaryOfEventLists.TryGetValue(Event_Type, out eventList))
            return;

        foreach (OnEvent _event in eventList)
        {
            if (_event != null)
            {
                _event(Event_Type, Sender, Param); //  Listener is a player
            }
        }
    }

    //Remove all redundant entries from the Dictionary
    public void RemoveRedundancies()
    {
        //Create new dictionary
        Dictionary<EVENT_TYPE, List<OnEvent>> TmpListeners
       = new Dictionary<EVENT_TYPE, List<OnEvent>>();

        
        //Cycle through all dictionary entries
        foreach (KeyValuePair<EVENT_TYPE, List<OnEvent>> Item in dictionaryOfEventLists)
        {
            // {1, 2, null, 3, 4, null, 5, 6}
            // {1, 2, 3, 4, null, 5, 6}
            // LinkedList  without array 1 -> 2 -> null -> 3 -> 
            //Cycle through all listeners
            //for (int i = Item.Value.Count - 1; i >= 0; i--)
            //{
            //    //If null, then remove item
            //    if (Item.Value[i].Equals(null))
            //        Item.Value.RemoveAt(i);
            //}

            //List<OnEvent> tmpList = new List<OnEvent>();
            //foreach(OnEvent _event in Item.Value)
            //{
            //    if(_event != null)
            //    {
            //        tmpList.Add(_event);
            //    }
            //}

            // LINQ
            List<OnEvent> tmpList = Item.Value.Where(e => e != null).ToList();

            // method in class List
            Item.Value.RemoveAll(e => e == null);

            //If items remain, then add to tmp dictionary
            if (tmpList.Count > 0)
                TmpListeners.Add(Item.Key, tmpList);
        }

        //Replace listeners with new dictionary
        dictionaryOfEventLists = TmpListeners;
    }
    //-----------------------------------------------------------
    //Called on scene change. Clean up dictionary
    void OnLevelWasLoaded()
    {
        RemoveRedundancies();
    }
    //-----------------------------------------------------------


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






    #region  other code
    void TestDictionary()
    {
        IListener heroListener = null;
        IListener npcListener = null;
        IListener player = new Player();


        dictionaryOfEventLists[EVENT_TYPE.GAME_INIT] = new List<OnEvent>
        {
            heroListener.OnEvent, npcListener.OnEvent, player.OnEvent
        };

        Dictionary<string, int> dict = new Dictionary<string, int>();
        dict["health"] = 12;
        Debug.Log(dict["health"]);
        if (dict.ContainsKey("xdfg"))
        {
            Debug.Log(dict["xdfg"]); // exception 
        }
        Debug.Log(dict["xdfg"]); // may be exception 

    }




    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion
}
