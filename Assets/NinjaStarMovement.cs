using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NinjaStarMovement : MonoBehaviour
{
    // Start is called before the first frame update
    float movement_speed = 0.001f;
    float rotation_speed = -2;
    Vector3 firstControlPoint;
    Vector3 secondControlPoint;
    float cameraY, size;
    float l;
    void Start()
    {
        l = 0;
        cameraY = Camera.main.transform.position.y;
        size = Camera.main.orthographicSize;

        firstControlPoint = transform.position;
        secondControlPoint = new Vector3(Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect, Random.RandomRange(cameraY - size, cameraY + size), 0);
    }

    // Update is called once per frame
    void Update()
    {
        l += movement_speed;
        this.transform.position = (1 - l) * firstControlPoint + l * secondControlPoint;
        transform.Rotate(0, 0, rotation_speed, Space.Self);

        if (transform.position.x > Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + 5)
        {
            Destroy(gameObject);
        }

    }
}
