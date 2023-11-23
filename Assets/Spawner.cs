using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameObject;
    private float cameraY, size;
    void Start()
    {
        cameraY = Camera.main.transform.position.y;
        size = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(gameObject, new Vector3(-3, Random.RandomRange(cameraY - size, cameraY + size), 0), Quaternion.identity);
        }
    }
}
