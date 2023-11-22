using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NinjaStarMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float movement_speed = 0.01f;
    float rotation_speed = -2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(transform.position.x + movement_speed, transform.position.y, transform.position.z);
        transform.Rotate(0, 0, rotation_speed, Space.Self);
    }
}
