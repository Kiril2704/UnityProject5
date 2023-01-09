using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterNpc : BetterPerson
{


    public bool IsAwake = true;
    public Transform player;

  

    public BetterNpc(string name, int health, float speed, bool isAwake) : base(name, health, speed)
    {
        IsAwake = isAwake;
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
