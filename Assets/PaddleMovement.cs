using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 oldMousePos;
    float scale = .05f;
    GameObject camera;
    float size;
    void Start()
    {
        oldMousePos = Input.mousePosition;
        camera = GameObject.FindWithTag("MainCamera");
        size = camera.GetComponent<Camera>().orthographicSize;
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

        if (transform.position.y + transform.localScale.y / 2 > camera.transform.position.y + size)
        {
            this.transform.position = new Vector3(transform.position.x, camera.transform.position.y + size - transform.localScale.y / 2, transform.position.z);
        }

        if (transform.position.y - transform.localScale.y / 2 < camera.transform.position.y - size)
        {
            this.transform.position = new Vector3(transform.position.x, camera.transform.position.y - size + transform.localScale.y / 2, transform.position.z);
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
