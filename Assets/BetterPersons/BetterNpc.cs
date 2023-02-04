using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate bool BoolIntInt(int a, int b);

public delegate bool BoolString(string s);

public class BetterNpc : BetterPerson, IListener
{
    public event BoolIntInt event1;
    public BoolIntInt Method;

    public bool IsAwake = true;
    public Transform player;


    public bool Larger(int x, int y)
    {
        if (x > y) { return false; }
        return true;
    }

    public BetterNpc(string name, int health, float speed, bool isAwake) : base(name, health, speed)
    {
        IsAwake = isAwake;
    }

    // Start is called before the first frame update
    void Start()
    {
        // EventManagerByInterface.Instance.AddListener(EVENT_TYPE.HEALTH_CHANGE, this);
        EventManager.Instance.AddEvent(EVENT_TYPE.HEALTH_CHANGE, this.OnEvent);
        Method = Larger;
        event1 = Larger;
        bool result = Larger(11, 5);
        bool result2 = Method(11, 5);
        bool result3 = event1(11, 5);
    }

    public void OnClick2(BoolIntInt Method)
    {
        Method(11, 5);  
    }


    public void OnEvent(EVENT_TYPE Event_type, Component Sender, System.Object Param = null)
    {
        switch (Event_type)
        {
            //case EVENT_TYPE.HEALTH_CHANGE:
            //    OnHealthChange(Sender, (int)Param);
            //    break;
            case EVENT_TYPE.GAME_INIT:
                OnGameInit(Sender);
                break;
            case EVENT_TYPE.GAME_END:
                OnGameEnd(Sender, (int)Param);
                break;
        }

        //if(Event_type == EVENT_TYPE.HEALTH_CHANGE)
        //{
        //    OnHealthChange(Sender, (int)Param);
        //}
        Debug.Log("On Event");
    }

    private void OnHealthChange(Component sender, int health)
    {
        Debug.Log("react in NPC. Player's Health was changed to " + health);
    }
    private void OnGameInit(Component sender)
    {
        Debug.Log("react in NPC. GAME INIT.");
    }
    private void OnGameEnd(Component sender, int health)
    {
        Debug.Log("react in NPC. save player because game end");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Vector3.Distance(player.position, transform.position));
        //if (Vector3.Distance(player.position, transform.position) <= 10f)
        //{
        //    IsAwake = true;
        //    transform.Rotate(3, 1, 2);
        //}




        if (IsAwake)
        {
            transform.Rotate(3, 1, 2);
            //int x = 1;
            //x = x / 0;
        }
    }
}
