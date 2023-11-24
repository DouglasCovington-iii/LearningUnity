using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public GameObject paddle;
    private float cameraY, size;
    private float spawnDistance = 10;
    private float spawnX, playerX;
    void Start()
    {
        cameraY = Camera.main.transform.position.y;
        size = Camera.main.orthographicSize;

        //playerX = GameObject()
        spawnX = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - spawnDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
           GameObject ninja_star = Instantiate(projectile, new Vector3(spawnX, Random.RandomRange(cameraY - size, cameraY + size), 0), Quaternion.identity);
           NinjaStarMovement temp = ninja_star.GetComponent<NinjaStarMovement>();
           temp.playerX = 2;
        }
    }
}
