using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public GameObject paddle;
    public AudioSource audioPlayer;
    private float spawnDistance = 10;
    private float portionOfScreen = .15f;
    private float cameraY, spawnX, size, minY, maxY;
    private List<float> spawnTimes;
    private bool SelfSpawn = true;
    int spawnIndex;
    float offset = 2;
    bool l1, l2;
    DateTime startTime;

    void Start()
    {
        l1 = false;
        l2 = false;

        cameraY = Camera.main.transform.position.y;
        size = Camera.main.orthographicSize;
        spawnX = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - spawnDistance;

        float boundaryLength = 2 * portionOfScreen * size;

        minY = cameraY - size + boundaryLength;
        maxY = cameraY + size - boundaryLength;

        LevelObject level = GameData.currLevel;

        List<float> hitTimes = level.hitTimes;
        audioPlayer.clip = level.song;
        
        float movement_per_iteration = projectile.GetComponent<NinjaStarMovement>().movement_per_iteration;
        float traveling_frames = Mathf.CeilToInt(1 / movement_per_iteration);
        float move_time = traveling_frames * Time.fixedDeltaTime;

        spawnTimes = new List<float>();
        foreach (float hit in hitTimes)
        {
            spawnTimes.Add(hit - move_time + offset);
        }

        spawnIndex = 0;

        //Debug.Log(""move_time);
        StartCoroutine(PlaySong(offset));

    }

    // Update is called once per frame
    void Update()
    {

        //if (SelfSpawn)
        //{
        //    if (Input.GetKeyDown(KeyCode.S))
        //    {
        //        Instantiate(projectile, new Vector3(spawnX, UnityEngine.Random.Range(cameraY - size, cameraY + size), 0), Quaternion.identity);
        //    }
        //}
        if (!l1)
        {
            l1 = true;
            startTime = DateTime.Now;
        }

        //if (ElaspedTime() >= offset && !l2)
        //{
        //    song.Play();
        //    l2 = true;
        //}

        if (spawnIndex < spawnTimes.Count)
        {
            if (ElaspedTime() >= spawnTimes[spawnIndex])
            {
                Instantiate(projectile, new Vector3(spawnX, UnityEngine.Random.Range(minY, maxY), 0), Quaternion.identity);
                spawnIndex++;
            }
        }
    }

    //IEnumerator Spawn()
    //{
    //    int spawnIndex = 0;
    //    float waitTime = 0;
        
    //    while (spawnIndex < spawnTimes.Count)
    //    {
    //        if (spawnIndex == 0)
    //        {
    //            waitTime = spawnTimes[spawnIndex];
    //        }
    //        else
    //        {
    //            waitTime = spawnTimes[spawnIndex] - spawnTimes[spawnIndex - 1];
    //        }
    //        yield return new WaitForSeconds(waitTime);
    //        Instantiate(projectile, new Vector3(spawnX, UnityEngine.Random.Range(cameraY - size + boundaryLength, cameraY + size - boundaryLength), 0), Quaternion.identity);
    //        spawnIndex++;
    //    }

    //    Debug.Log("Done Spawning");
    //}

    float ElaspedTime()
    {
        DateTime curr = DateTime.Now;
        return (float)(curr - startTime).TotalSeconds;
    }
    IEnumerator PlaySong(float offset)
    {
        yield return new WaitForSeconds(offset);
        audioPlayer.Play();
    }
}
