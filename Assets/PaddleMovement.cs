using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseScreenPos = Input.mousePosition;

        Vector3 mouGlobalPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        transform.position = new Vector3(transform.position.x, mouseScreenPos.y, transform.position.z);

        Debug.Log(mouseScreenPos);
    }
}
