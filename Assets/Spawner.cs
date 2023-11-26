using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectile;
    public GameObject paddle;
    public AudioSource song;
    private float spawnDistance = 10;
    private float cameraY, spawnX, size;
    private List<float> spawnTimes;
    private bool SelfSpawn = true;
    int spawnIndex;
    float offset = 3;
    bool l1, l2;
    DateTime startTime;

    void Start()
    {
        l1 = false;
        l2 = false;

        cameraY = Camera.main.transform.position.y;
        size = Camera.main.orthographicSize;

        spawnX = Camera.main.transform.position.x - Camera.main.orthographicSize * Camera.main.aspect - spawnDistance;
        List<float> hitTimes = new List<float> { 1.342972f, 1.702086f, 2.81387f, 3.19615f, 3.609685f, 4.347493f, 4.738717f, 5.797313f, 6.183011f, 6.581512f, 7.350471f, 7.747458f, 8.791831f, 9.188644f, 9.58757f, 10.34765f, 10.76881f, 11.77172f, 12.19487f, 12.58705f }; spawnTimes = new List<float>();
        
        float movement_per_iteration = projectile.GetComponent<NinjaStarMovement>().movement_per_iteration;
        float traveling_frames = Mathf.CeilToInt(1 / movement_per_iteration);
        float move_time = traveling_frames * Time.fixedDeltaTime;

        foreach (float hit in hitTimes)
        {
            spawnTimes.Add(hit - move_time + offset);
        }

        spawnIndex = 0;

        //Debug.Log(""move_time);
        //StartCoroutine(PlaySong(offset));

    }

    // Update is called once per frame
    void Update()
    {

        if (SelfSpawn)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Instantiate(projectile, new Vector3(spawnX, UnityEngine.Random.Range(cameraY - size, cameraY + size), 0), Quaternion.identity);
            }
        }
        //if(!l1)
        //{
        //    l1 = true;
        //    startTime = DateTime.Now;
        //}

        ////if (ElaspedTime() >= offset && !l2)
        ////{
        ////    song.Play();
        ////    l2 = true;
        ////}

        //if (spawnIndex < spawnTimes.Count)
        //{
        //    if (ElaspedTime() >= spawnTimes[spawnIndex])
        //    {
        //        Instantiate(projectile, new Vector3(spawnX, UnityEngine.Random.Range(cameraY - size, cameraY + size), 0), Quaternion.identity);
        //        spawnIndex++;
        //    }
        //}
    }

    IEnumerator Spawn()
    {
        int spawnIndex = 0;
        float waitTime = 0;
        
        while (spawnIndex < spawnTimes.Count)
        {
            if (spawnIndex == 0)
            {
                waitTime = spawnTimes[spawnIndex];
            }
            else
            {
                waitTime = spawnTimes[spawnIndex] - spawnTimes[spawnIndex - 1];
            }
            yield return new WaitForSeconds(waitTime);
            Instantiate(projectile, new Vector3(spawnX, UnityEngine.Random.Range(cameraY - size, cameraY + size), 0), Quaternion.identity);
            spawnIndex++;
        }

        Debug.Log("Done Spawning");
    }

    float ElaspedTime()
    {
        DateTime curr = DateTime.Now;
        return (float)(curr - startTime).TotalSeconds;
    }
    IEnumerator PlaySong(float offset)
    {
        yield return new WaitForSeconds(offset);
        song.Play();
    }
}
