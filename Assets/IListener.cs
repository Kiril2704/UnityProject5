using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EVENT_TYPE
{ 
    GAME_INIT,
    GAME_END,
    AMMO_EMPTY,
    HEALTH_CHANGE,
    DEAD

};
public interface IListener
{

    void OnEvent(EVENT_TYPE Event_type, Component Sender, System.Object Param = null);

}
