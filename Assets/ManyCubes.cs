using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManyCubes : MonoBehaviour
{
    int n = 100;
    private GameObject[] MyObjects;


    private Rigidbody[] rigidBodies;
    float velocityChange = 0.02f;
    // Start is called before the first frame update

    // version 1
    //void Start()
    //{
    //    MyObjects = new GameObject[n];
    //    rigidBodies = new Rigidbody[n];
    //    for (int i = 0; i < MyObjects.Length; i++)
    //    {
    //        CreatePrimitiveCube(i);
    //    }        
    //    //MyObjects[0] = GameObject.Find("Cube");        
    //}

    //void CreatePrimitiveCube(int i)
    //{
    //    GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
    //    cube2.transform.localScale = Vector3.one * 1;
    //    rigidBodies[i] = cube2.AddComponent<Rigidbody>();
    //    rigidBodies[i].useGravity = false;
    //    cube2.transform.position = new Vector3(1.5f * i, -4 - i, 0);
    //    MyObjects[i] = cube2;
    //}


    // version 2

    void Start()
    {
        MyObjects = new GameObject[n];
        rigidBodies = new Rigidbody[n];
        for (int i = 0; i < MyObjects.Length; i++)
        {
            MyObjects[i] = CreatePrimitiveCube(1.5f * i, -4 - i, 0);
            rigidBodies[i] = MyObjects[i].GetComponent<Rigidbody>();
        }           
    }

    GameObject CreatePrimitiveCube(float x, float y, float z)
    {
        GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.transform.localScale = Vector3.one * 1;
        cube2.AddComponent<Rigidbody>().useGravity = false;
        cube2.transform.position = new Vector3(x, y, z);     
        return cube2;
    }






    // Update is called once per frame
    void Update()
    {
        int i = 0;
        foreach (Rigidbody rb in rigidBodies)
        {
            if (rb != null)
            {
                Debug.Log(i);
                i++;
                if (rb.transform.position.y < 0)
                {

                    rb.AddForce(Vector3.up * velocityChange, ForceMode.Impulse);
                }
                if (rb.transform.position.y > 3)
                {

                    rb.AddForce(Vector3.down * velocityChange, ForceMode.Impulse);
                }
            }
        }
    }

    void TestNull()
    {
        string s1 = null;
        string s2; // unassigned variable

        //if(s2 == null)
        //{
        //    Debug.Log("s2 is null");
        //}
        //else
        //{
        //    Debug.Log("s2 is not null");
        //}
        //int x;
        //Debug.Log(x);
    }



}
