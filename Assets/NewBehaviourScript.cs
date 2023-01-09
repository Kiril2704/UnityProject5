using System.Collections;
using System.Collections.Generic;
using UnityEngine;



enum MyDirection
{
    UP,   // 0
    DOWN // 1
}

class MyDirection2
{
    public static int Up = 0;
    public static int Down = 1;
}



public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
   public float direction;
    Rigidbody rb;
    float velocityChange = 0.02f;

    void Start()
    {
        //direction = 0.002f;  
        rb = GetComponent<Rigidbody>();

        int direction2 = MyDirection2.Up;


        MyDirection myDirection = MyDirection.UP;   
        if (myDirection == MyDirection.DOWN)
        {
            myDirection = MyDirection.DOWN;
        }

        int x = 1;
        // x = 1;
        // Task x --> enum MyDirection

        MyDirection foo = (MyDirection)x;
        Debug.Log(foo); 


    }


    void Update()
    {
        //Debug.Log(transform.position.y);



        //transform.position += Vector3.up * direction;
        //if (transform.position.y < 0 || transform.position.y > 3)
        //{
        //    direction *= -1;
        //}

        if (transform.position.y < 0)
        {
             
            rb.AddForce(Vector3.up * velocityChange, ForceMode.Impulse);
        }
        if(transform.position.y > 3)
        {
            
            rb.AddForce(Vector3.down * velocityChange, ForceMode.Impulse);
        }

    }

        // Update is called once per frame
        //void Update()
        //{
        //    Debug.Log(transform.position.y);
        //    Vector3 maxHight = new Vector3(3,2,2);
        //    //switch(transform.position.y)
        //    //{
        //    //    case 5:
        //    //        Debug.Log("asdf");
        //    //        transform.position = Vector3.zero;
        //    //        break;

        //    //    default:
        //    //        Debug.Log("I");
        //    //        transform.position += Vector3.up*0.001f;
        //    //        break;           
        //    //}


        //    //  if(transform.position.y < 3 && transform.position.y > 0)

        //    bool direction = false;
        //    if(direction == false && transform.position.y < 0)
        //    {
        //        direction = true;
        //        goUp();

        //    }
        //    else
        //    {
        //        direction = false;
        //        goDown();
        //    }




        //}
        //void goUp()
        //{
        //    transform.position += Vector3.up * 0.001f;
        //}
        //void goDown()
        //{
        //    transform.position -= Vector3.up * 0.001f;
        //}
    }
