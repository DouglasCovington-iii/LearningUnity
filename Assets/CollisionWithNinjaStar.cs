using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionWithNinjaStar : MonoBehaviour
{
    private List<GameObject> hitList = new List<GameObject>();
    private bool stun = false;
    

    private void Update()
    {
        bool clicked = Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);

        if (clicked)
        {
            Debug.Log("Count of hit list: " + hitList.Count);
        }

        if (!(hitList.Count == 0) && clicked && !stun) 
        {
            for (int i = 0; i < hitList.Count; i++)
            {
                Destroy(hitList[hitList.Count - 1]);
                //hitList.RemoveAt(hitList.Count - 1);
                //Debug.Log("Killed projectile");
            }

            //Debug.Log("Is this empty: " + hitList.ToString());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ninja Star")
        {
            hitList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ninja Star")
        {
            hitList.Remove(collision.gameObject);
        }
    }
    //private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    //{
    //    if (collision.gameObject.tag.Equals("Paddle"))
    //    {
    //        Debug.Log("Hit with paddle");
    //    }
    //    else
    //    {
    //        Debug.Log("How: " + collision.gameObject.ToString());
    //    }

    //    if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))&& collision.gameObject.tag.Equals("Paddle"))
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
    //private void OnTriggerStay2D(UnityEngine.Collider2D collision)
    //{
    //    if (collision.gameObject.tag.Equals("Paddle"))
    //    {
    //        Debug.Log("Hit with paddle");
    //    }
    //    else
    //    {
    //        Debug.Log("How: " + collision.gameObject.ToString());
    //    }

    //    if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && collision.gameObject.tag.Equals("Paddle"))
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}
}
