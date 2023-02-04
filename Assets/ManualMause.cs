using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualMause : MonoBehaviour
{
    //Get collider attached to this object
    private Collider Col = null;


    //Awake function - called at start up
    void Awake()
    {
        //Get collider
        Col = GetComponent<Collider>();
    }


    //---------------------
    //Start Coroutine
    void Start()
    {
        //StartCoroutine(UpdateMouse());
    }

    //public IEnumerator UpdateMouse()
    //{
    //    //Are we being intersected
    //    bool bIntersected = false;
    //    //Is button down or up
    //    bool bButtonDown = false;
    //    //Loop forever
    //    while (true)
    //    {
    //        //Get mouse screen position in terms of X and Y
    //        //You may need to use a different camera
    //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;
    //        //Test ray for collision against this collider
    //        if (Col.Raycast(ray, out hit, Mathf.Infinity))
    //        {
    //            //Object was intersected
    //            if (!bIntersected)
    //            {
    //                SendMessage("OnMouseEnter", SendMessageOptions.DontRequireReceiver);
    //                Debug.Log("OnMouseEnter");
    //            }
    //            bIntersected = true;
    //            //Test for mouse events
    //            if (!bButtonDown && Input.GetMouseButton(0))
    //            {
    //                bButtonDown = true;
    //                SendMessage("OnMouseDown", SendMessageOptions.DontRequireReceiver);
    //                Debug.Log("OnMouseDown");
    //            }
    //            if (bButtonDown && !Input.GetMouseButton(0))
    //            {
    //                bButtonDown = false; 
    //                SendMessage("OnMouseUp", SendMessageOptions.DontRequireReceiver);
    //                Debug.Log("OnMouseUp");
    //            }
    //        }
    //        else
    //        {
    //            //Was previously entered and now leaving
    //            if (bIntersected)
    //            {
    //                SendMessage("OnMouseExit", SendMessageOptions.DontRequireReceiver);
    //                Debug.Log("OnMouseExit");
    //            }
    //            bIntersected = false;
    //            bButtonDown = false;
    //        }
    //        //Wait until next frame
    //        yield return null;
    //    }
    //}
    //---------------------
// Update is called once per frame
    void Update()
        {
            
        }

    public void OnMouseDown()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up, ForceMode.Impulse);
    }
    //public void OnApplicationPause(bool pause)
    //{
    //    Destroy(this.gameObject);
    //}

}
