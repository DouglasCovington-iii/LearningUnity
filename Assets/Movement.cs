using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - .01f, transform.position.z);
        } 

      if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + .01f, transform.position.z);
        }
    }
}
