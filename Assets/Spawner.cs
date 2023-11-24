using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public GameObject paddle;
    private float spawnDistance = 10;
    private float cameraY, spawnX, size;

    void Start()
    {
        cameraY = Camera.main.transform.position.y;
        size = Camera.main.orthographicSize;

        spawnX = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - spawnDistance;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(projectile, new Vector3(spawnX, Random.Range(cameraY - size, cameraY + size), 0), Quaternion.identity);
        }
    }
}
