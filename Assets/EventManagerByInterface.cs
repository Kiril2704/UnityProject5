using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// old version 



public class EventManagerByInterface : MonoBehaviour
{    
    private Dictionary<EVENT_TYPE, List<IListener>> Listeners = new ();  // EventManager eventManager = new ();   

    public static EventManagerByInterface Instance { get; private set; }


    public void AddListener(EVENT_TYPE Event_Type, IListener Listener)
    {       
        List<IListener> ListenList = null;
        // Check existing event type key. If exists, add to list
        if (Listeners.TryGetValue(Event_Type, out ListenList))
        {
            //List exists, so add new item
            ListenList.Add(Listener);
            return;
        }

        //Otherwise create new list as dictionary key
        ListenList = new List<IListener>();
        ListenList.Add(Listener);
        Listeners.Add(Event_Type, ListenList);

       
    }


    public void PostNotification(EVENT_TYPE Event_Type, Component Sender, System.Object Param = null)
    {
        //Notify all listeners of an event
       
        //List of listeners for this event only
        List<IListener> ListenList = null;

        //If no event exists, then exit
        if (!Listeners.TryGetValue(Event_Type, out ListenList))
            return;

        //Entry exists. Now notify appropriate listeners
        //for (int i = 0; i < ListenList.Count; i++)
        //{
        //    if (!ListenList[i].Equals(null))
        //        ListenList[i].OnEvent(Event_Type, Sender, Param); 
        //}
        
        foreach (IListener Listener in ListenList)
        {
            if (Listener != null)
            {
                Listener.OnEvent(Event_Type, Sender, Param); //  Listener is a player
            }
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






    #region  other code

    void Test()
    {
        // example use delegate
        //Function sin = System.Math.Sin;
        //Function cos = System.Math.Cos;
        //double x = sin(1) * cos(1) * sin(2)/ cos(3);
        // OnEvent event1 = PostNotification;
    }

    void TestDictionary()
    {
        IListener heroListener = null;
        IListener npcListener = null;
        IListener player = new Player();
        

        Listeners[EVENT_TYPE.GAME_INIT] = new List<IListener> 
        { 
            heroListener, npcListener, player
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
