using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeveloperMode : MonoBehaviour
{
    public AudioSource song;
    public TextMeshPro displayTimer;
    bool l1, l2, l3, l4;
    DateTime startTime;
    List<float> hitTimes;
    float oldTimeStep, oldMaxTimeStep;
    float newTimeStep = .01f;
    float newMaxTimeStep = .1f;
    int totalClicks = 0;
    // Start is called before the first frame update

    void Start()
    {
        l1 = false;
        l2 = false;
        l3 = false;
        l4 = false;
        hitTimes = new List<float>();
        oldTimeStep = Time.fixedDeltaTime;
        oldMaxTimeStep = Time.maximumDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.D)) || l1)
        {
            //displayTimer.text = "Musician mode activated";
            if (!l2)
                StartCoroutine(Intro(1));

            if (l1)
            {
                if (!l3)
                {
                    startTime = DateTime.Now;
                    song.Play();
                    l3 = true;
                }

                if (l3 && !l4)
                {
                    if (!Input.GetKeyDown(KeyCode.E))
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            totalClicks++;
                            float elapsedTime = GetElaspedTime();
                            Debug.Log($"click {totalClicks}:\t{elapsedTime}");
                            hitTimes.Add(GetElaspedTime());
                        }
                    }
                    else
                    {
                        l4 = true;
                        song.Stop();
                        //Time.fixedDeltaTime = oldTimeStep;
                        //Time.maximumDeltaTime = oldMaxTimeStep;

                        string output = "List<float> hitTimes = new List<float> {";
                        string content = "";

                        for(int i = 0; i < hitTimes.Count; i++)
                        {
                            if(i != hitTimes.Count - 1)
                            {
                                content += $"{hitTimes[i]}f, ";
                            }
                            else
                            {
                                content += $"{hitTimes[i]}f";
                            }
                        }

                        output += content + "};";

                        Debug.Log(output);
                    }
                }

            }
            
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

        //Debug.Log("Iteration");
    }

    //void FixedUpdate()
    //{
    //    if (l3 && !l4)
    //    {
    //        if (!Input.GetKeyDown(KeyCode.E))
    //        {
    //            if(Input.GetMouseButtonDown(0))
    //            {
    //                hitTimes.Add(GetElaspedTime());
    //            }
    //        }
    //        else
    //        {
    //            l4 = true;
    //            song.Stop();
    //            Time.fixedDeltaTime = oldTimeStep;
    //            Time.maximumDeltaTime = oldMaxTimeStep;

    //            string temp = "";

    //            foreach (double h in hitTimes)
    //            {
    //                temp += h + " ";
    //            }

    //            Debug.Log(temp);
    //        }
    //    }
    //}


    float GetElaspedTime()
    {
        DateTime curr = DateTime.Now;
        return (float)(curr - startTime).TotalSeconds;
    }
    IEnumerator Intro(float waitTime)
    {
        l2 = true;

        //Time.fixedDeltaTime = newTimeStep;
        //Time.maximumDeltaTime = newMaxTimeStep;

        displayTimer.gameObject.SetActive(true);
        displayTimer.text = "Musician mode";
        yield return new WaitForSeconds(waitTime);
        displayTimer.text = "3";
        yield return new WaitForSeconds(waitTime);
        displayTimer.text = "2";
        yield return new WaitForSeconds(waitTime);
        displayTimer.text = "1";
        yield return new WaitForSeconds(waitTime);
        displayTimer.text = "Begin";
        l1 = true;
        startTime = DateTime.Now;
        song.Play();
    }
}
