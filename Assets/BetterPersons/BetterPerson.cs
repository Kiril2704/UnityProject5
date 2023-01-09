using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterPerson : MonoBehaviour
{
    public int xPublic;
    private int xPrivate;
    protected int xProtected;

    public string Name = "";
    public int Health = 100;
    public float Speed = 10f;
    //GameObject GameObject { get; set; }

    //public BetterPerson(string Name, int Health, float Speed)
    //{
    //    this.Name = Name;
    //    this.Health = Health;
    //    this.Speed = Speed;
    //}

    public BetterPerson()
    {
            xPrivate = 10;
    }


    public BetterPerson(string name, int health, float speed)
    {
        Name = name;
        Health = health;
        Speed = speed;
        //GameObject = CreatePrimitiveSphere(2, 3, 3);
    }

    public  virtual void Test()
    {
        System.Console.WriteLine("Test");
    }

    //GameObject CreatePrimitiveSphere(float x, float y, float z)
    //{
    //    GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //    cube2.transform.localScale = Vector3.one * 1;
    //    cube2.AddComponent<Rigidbody>().useGravity = true;
    //    cube2.transform.position = new Vector3(x, y, z);
    //    return cube2;
    //}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
