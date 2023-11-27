using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NinjaStarMovement : MonoBehaviour
{
    public float movement_per_iteration = 0.001f;
    float rotation_speed = -2;
    float cullingDistance = 5;
    float portion_of_screen = .15f;
    Vector3 firstControlPoint;
    Vector3 secondControlPoint;
    float cameraY, size, cullingX, playerX;
    float epsilon = 0.001f;

    float l;

    // Start is called before the first frame update
    void Start()
    {
        l = 0;

        float rightBoundX = Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect;
        //Hopefully doesn't slow down
        playerX = GameObject.FindWithTag("Paddle").transform.position.x;
        cameraY = Camera.main.transform.position.y;
        size = Camera.main.orthographicSize;

        float boundaryLength = 2 * portion_of_screen * size;

        float minY = cameraY - size + boundaryLength;
        float maxY = cameraY + size - boundaryLength;

        firstControlPoint = transform.position;
        secondControlPoint = new Vector3(playerX, Random.Range(minY + epsilon, maxY - epsilon), 0);

        cullingX = Camera.main.transform.position.x + Camera.main.orthographicSize * Camera.main.aspect + cullingDistance;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        l += movement_per_iteration;

        transform.position = (1 - l) * firstControlPoint + l * secondControlPoint;
        transform.Rotate(0, 0, rotation_speed, Space.Self);

        if (transform.position.x > cullingX)
        {
            Destroy(gameObject);
        }

    }
}
