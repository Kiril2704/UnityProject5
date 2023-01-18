using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Plane : MonoBehaviour
{

    
    //public BetterPerson[] betterPeople = null;
 
    public BetterNpc[] betterNpc = null;
    //public Player player = null;

    public void TestProperty() 
    {
        Weapon weapon = new Weapon();
        Player.Instance.ActiveWeapon = weapon; // property -> set
        Player.Instance.SetActiveWeapon(weapon); // in Java

        System.Console.WriteLine(Player.Instance.ActiveWeapon); // get 
        Weapon weapon2 = Player.Instance.ActiveWeapon; // get 
        Weapon weapon3 = Player.Instance.GetActiveWeapon(); // in Java
    }

    public void TestQuestionMark()
    {

        //string playerActiveWeaponName  = null;
        //if(player != null)
        //{
        //    if (player.ActiveWeapon != null)
        //    {
        //        playerActiveWeaponName = player.ActiveWeapon.Name;
        //    }
        //}
        string playerActiveWeaponName = Player.Instance?.ActiveWeapon?.Name;

        System.Console.WriteLine(Player.Instance.ActiveWeapon.Name); // if player == null then exception  null.ActiveWeapon.Name
    }




    // Start is called before the first frame update
    void Start()
    {
        //BetterPerson betterPerson = new BetterPerson();
        //betterPerson.xPublic = 10; // ok
        //betterPerson.xProtected = 10; // protected 

        //betterPeople = new BetterPerson[3];
        //betterPeople[0] = new BetterPerson("Name1",122,12f);
        //Weapon weapon1 = new Weapon();
        //Weapon weapon2 = new Weapon();
        //Weapon weapon3 =  new Weapon();  


        //betterPeople[1] = new Player(weapon1,weapon2,weapon3, "PlayerName",222,10f);
        //betterPeople[2] = new BetterNpc("NPC",50,8f,true);
        string playerStr = " " + Player.Instance; // " " + player.ToString()
        List<int> ts = new List<int>() { 1, 5, 4, 3, 3 };
        

        //Debug.Log(player.ToString());
        //Debug.Log(player);
        //Debug.Log(ts.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var betterNpc in betterNpc)
        {
            //Debug.Log(Vector3.Distance(player.transform.position, betterNpc.transform.position));
            if (Vector3.Distance(Player.Instance.transform.position, betterNpc.transform.position) <= 10f && Player.Instance.CurrentState != Player.State.IS_BUSY)
            {
                Debug.Log("if");
                Player.Instance.CurrentState = Player.State.IS_BUSY;
                betterNpc.IsAwake = true;
            }
        }

    }
}
