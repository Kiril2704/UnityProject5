using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : BetterPerson, IListener
{

    public int Money;

    public enum State {IS_BUSY,NOT_BUSY}
    public State CurrentState = State.NOT_BUSY;
    public Weapon Slot1 { get; set; }
    public Weapon Slot2 { get; set; }
    public Weapon Slot3 { get; set; }

    private int _health;

    public int Health
    {
        get { return _health; }
        set
        {
            //Clamp health between 0-100
            _health = Mathf.Clamp(value, 0, 100);
            //Post notification - health has been changed   PostNotification call method Listener.OnEvent
            EventManager.Instance.PostNotification(EVENT_TYPE.HEALTH_CHANGE, 
                this, _health);
        }
    }


    public void OnEvent(EVENT_TYPE Event_type, Component Sender, System.Object Param = null)
    {
        switch (Event_type)
        {
            case EVENT_TYPE.HEALTH_CHANGE:
                OnHealthChange(Sender, (int)Param);
                break;
        }

        //if(Event_type == EVENT_TYPE.HEALTH_CHANGE)
        //{
        //    OnHealthChange(Sender, (int)Param);
        //}
    
    }

    private void OnHealthChange(Component sender, int health)
    {
        Debug.Log("health was changed to " + health);
    }



    private Weapon activeWeapon;
    public Weapon ActiveWeapon {
        get //  Weapon weapon2 = player.ActiveWeapon; 
        {
            return activeWeapon;
        }
        set //  player.ActiveWeapon = weapon;  // value = weapon
        {   
            if(value.Bullets > 0)
            {
                activeWeapon = value;   
            }
           
        }
    }

    // in Java
    public Weapon GetActiveWeapon()
    {
        return activeWeapon;
    }

    public void SetActiveWeapon(Weapon value)
    {
        if (value.Bullets > 0)
        {
            activeWeapon = value;
        }
    }


    



    // GameObject GameObject { get; set; }
    public float velocity = 10f;
    public float rotationSpeed = 5f;


    public Player(): base()
    {
        // xPrivate = 10;  // error
        xProtected = 10;
        Debug.Log("Player");
      
    }

    public Player(Weapon slot1, Weapon slot2, Weapon slot3, string name, int health, float speed,State CurrentState) : base(name, health, speed)
    {
        Slot1 = slot1;
        Slot2 = slot2;
        Slot3 = slot3;
        ActiveWeapon = slot1;
        // GameObject = CreatePrimitiveCube(1, 1, 1);
        CurrentState = State.NOT_BUSY;
    }


    //GameObject CreatePrimitiveCube(float x, float y, float z)
    //{
    //    GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    cube2.transform.localScale = Vector3.one * 1;
    //    cube2.AddComponent<Rigidbody>().useGravity = false;
    //    cube2.transform.position = new Vector3(x, y, z);
    //    return cube2;
    //}
    private void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
            return;
        }
        Instance = this;
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        //Application.LoadLevel(1);
        
    }

    public sealed override void Test()
    {
        System.Console.WriteLine("Test");
        string description;
        if(Speed > 10)
        {
            description = "Fast";
        }
        else
        {
            description = "Slow";
        }
        string description2 = Speed > 10 ? "Fast" : "Slow";

    }


    void TestNull()
    {
        string s1 = null;
        string s2;
        int x;

        //if (s2 == null) // error
        //{
        //    Debug.Log(1);
        //}

    }



    public void TestDoubleQuestionMark()
    {

        //List<int> numbers = null;
        //// int x = null; // error
        //int? a = null;

        //(numbers ??= new List<int>()).Add(5); //if numbers==null numbers = new List<int>()
        //Debug.Log(string.Join(" ", numbers));  // output: 5

        //numbers.Add(a ??= 0);
        //Debug.Log(string.Join(" ", numbers));  // output: 5 0
        //Debug.Log(a);  // output: 0

        //if (numbers == null)
        //{
        //    numbers = new List<int>();
        //}

        //int? a = 11;
        //double x = a??=5;
        //x = a.GetValueOrDefault(5);
        //Debug.Log(a);
        //Debug.Log(x);

        //if(a == null)
        //{
        //    a = 0;           
        //}
        //x = a.Value;

    }

    public override string ToString()
    {
        // int x = 5;
        // string description = "table";
        // return string.Format("hello {0} world {1}", 5, "table"); // "hello " + 5 + " world " + "table"
        // return $"hello {x} world {description}";
       
        return $"Money: {Money}, ActiveWeapon: {(ActiveWeapon == null? "no":ActiveWeapon)}";
    }



    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axis.
        // By default they are mapped to the arrow keys.
        // The value is in the range -1 to 1
        float translation = Input.GetAxis("Vertical") * velocity;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        // Debug.Log(gameObject.transform.position);
        //Debug.Log(velocity);
        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        // Move translation along the object's z-axis
        transform.Translate(0, 0, translation);
        //Debug.Log(translation);
        
        // Rotate around our y-axis
        transform.Rotate(0, rotation, 0);

        if (Input.GetKey(KeyCode.K))
        {
            Application.LoadLevel(1);
        }
        if (Input.GetKey(KeyCode.L))
        {
            Application.LoadLevel(0);
            //Debug.Log(Mathf.Clamp(-5f, 0f, 100f));
        }

        //Debug.Log(state);


    }

    

    //public static Player Instance
    //{
    //    get
    //    {
    //        return instance;
    //    }
    //}
    //public static Player Instance => instance;

    //private static Player instance;


    // version 2 
    public static Player Instance { get; private set; }


    //private void OnTriggerEnter(Collider other) 
    //{
    //    Debug.Log("Collision" + Time.realtimeSinceStartup);
    //    Application.LoadLevel(0);

    //}


}
