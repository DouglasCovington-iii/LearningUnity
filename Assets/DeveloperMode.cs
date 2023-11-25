using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeveloperMode : MonoBehaviour
{
    public AudioSource song;
    public TextMeshPro displayTimer;
    bool started;
    DateTime startTime;
    List<float> hitTimes;
    
    // Start is called before the first frame update

    void Start()
    {
        started = false;
        hitTimes = new List<float>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D)) || started)
        {
            //displayTimer.text = "Musician mode activated";
            if (!started)
                StartCoroutine(Intro(1));

            
            //song.Play();
            //displayTimer.text = "3";
            //if (!Input.GetKey(KeyCode.E))
            //{
            //    if (!started)
            //    {
            //        displayTimer.text = "Musician mode activated";
            //        wait(1);
            //        displayTimer.text = "3";
            //        wait(1);
            //        displayTimer.text = "2";
            //        wait(1);
            //        displayTimer.text = "1";
            //        wait(1);
            //        displayTimer.text = "Playing";
            //        started = true;
            //        wait(1);
            //        startTime = DateTime.Now;
            //        song.Play();

            //    }
            //}
        }
    }

    IEnumerator Intro(float waitTime)
    {
        displayTimer.text = "Musician mode";
        yield return new WaitForSeconds(waitTime);
        displayTimer.text = "3";
        yield return new WaitForSeconds(waitTime);
        displayTimer.text = "2";
        yield return new WaitForSeconds(waitTime);
        displayTimer.text = "1";
        yield return new WaitForSeconds(waitTime);
        displayTimer.text = "Begin";
        yield return new WaitForSeconds(waitTime/2);
        started = false;
        startTime = DateTime.Now;
        song.Play();
    }
}
