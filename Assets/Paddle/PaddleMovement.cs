using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public BoxCollider2D collider;
    float size;
    float halfBoundHeight;
    float maxY, minY;
    float portion_ofScreen = .15f;


    // Start is called before the first frame update
    void Start()
    {
        size = Camera.main.orthographicSize;
        halfBoundHeight = (collider.bounds.max.y - collider.bounds.min.y) / 2f;

        float boundaryLength = 2 * portion_ofScreen * size;

        minY = Camera.main.transform.position.y - size + boundaryLength;
        maxY = Camera.main.transform.position.y + size - boundaryLength;

    }

    // Update is called once per frame
    void Update()
    {
        //if (!Input.GetMouseButton(2))
        //{
        //Vector3 newMousePos = Input.mousePosition;
        //float diff = newMousePos.y - oldMousePos.y;
        //this.transform.position = new Vector3(transform.position.x, transform.position.y + scale * diff, transform.position.z);
        //oldMousePos = newMousePos;

        this.transform.position = new Vector3(transform.position.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, transform.position.z);

        if (transform.position.y + halfBoundHeight > maxY)
        {
            this.transform.position = new Vector3(transform.position.x, maxY - halfBoundHeight, transform.position.z);
        }

        if (transform.position.y - halfBoundHeight < minY)
        {
            this.transform.position = new Vector3(transform.position.x, minY + halfBoundHeight, transform.position.z);
        }

        //Debug.Log("(World Coordinates) Mouse Position: " + Camera.main.ScreenToWorldPoint(Input.mousePosition).ToString());
        //Debug.Log("Mouse Position:" + Camera.main.ScreenToViewportPoint(Input.mousePosition).ToString());
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Debug.Log("Pressed Spaced");
        //    Destroy(this.gameObject);
        //}
        

    }
}
