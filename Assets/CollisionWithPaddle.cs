using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithPaddle : MonoBehaviour
{
    private bool doesCollideWithPaddle = false;
    private bool stun = false;
    

    private void Update()
    {
        bool clicked = Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space);

        if (doesCollideWithPaddle && clicked && !stun) 
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            doesCollideWithPaddle = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            doesCollideWithPaddle = false;
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
