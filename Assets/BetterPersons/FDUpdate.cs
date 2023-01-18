using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDUpdate : MonoBehaviour
{
    public float Speed;
    public float acceleration = -0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // y = y0 + speed0 * time + a * time^2 / 2
        // dy/dt = speed0 + a * t
        // dy = speed0 * deltaTime + a * time * deltaTime

        // y += dy
        
        float dx = Speed * 0.3f * Time.fixedDeltaTime;
        float dy = Speed * 0.3f * Time.fixedDeltaTime + acceleration * Time.fixedDeltaTime * Time.realtimeSinceStartup;  

        transform.localPosition += transform.forward * dx + transform.right * dy;
     
    }
    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("Collision" + Time.realtimeSinceStartup);
    }
}
