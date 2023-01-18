using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTime : MonoBehaviour
{
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()  // 500 fps Time.deltaTime = 1/500 = 0.002 sec
    {
        transform.localPosition += transform.forward * Speed * 0.3f * Time.deltaTime;
        //Debug.Log(Time.deltaTime  + "Dtime");
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision"+ Time.realtimeSinceStartup);
    }
}
