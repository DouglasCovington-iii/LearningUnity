using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionWithNinjaStar : MonoBehaviour
{
    private List<GameObject> hitList;
    private bool stun;
    private DateTime startTime;
    private SpriteRenderer spriteRenderer;
    private bool isHitListEmpty;
    private float stunTime = 0.5f;


    void Start()
    {
        hitList = new List<GameObject>();
        stun = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        bool clicked = Input.GetMouseButtonDown(0);

        //if (clicked)
        //{
        //    Debug.Log("Count of hit list: " + hitList.Count);
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    string s = transform.name;
        //    Transform t = transform.parent;

        //    while (t != null)
        //    {
        //        s = t.name + "/" + s;
        //        t = t.parent;
        //    }

        //    Debug.Log("MouseDown " + Time.frameCount + " : " + s);
        //}
            



        if (clicked && (hitList.Count == 0) && !stun)
        {
            stun = true;
            startTime = DateTime.Now;

            //Debug.Log("You Missed");

            Color color = spriteRenderer.color;
            color.a = .25f;
            spriteRenderer.color = color;
        }

        if (stun)
        {
            DateTime currTime = DateTime.Now;

            TimeSpan elapsedInter = currTime - startTime;
            double elaspedSeconds = elapsedInter.TotalSeconds;

            if (elaspedSeconds >= stunTime)
            {
                stun = false;

                Color color = spriteRenderer.color;
                color.a = 1f;
                spriteRenderer.color = color;

                //Debug.Log("You are unfrozen");
            }
        }

        if (!(hitList.Count == 0) && clicked && !stun)
        {
            int size = hitList.Count;
            for (int i = 0; i < size; i++)
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
}