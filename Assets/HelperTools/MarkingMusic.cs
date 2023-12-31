using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MarkingMusic : MonoBehaviour
{
    public AudioSource audioPlayer;
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
        if (!Input.GetKeyDown(KeyCode.R))
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
                        audioPlayer.Play();
                        l3 = true;
                    }

                    if (l3 && !l4)
                    {
                        if (!Input.GetKeyDown(KeyCode.S))
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
                            audioPlayer.Stop();


                            //string temp = "";

                            //for (int i = 0; i < hitTimes.Count; i++)
                            //{
                            //    temp += hitTimes[i] + " ";
                            //}

                            //Debug.Log(temp);

                            string hitTimesJson = UnityEngine.JsonUtility.ToJson(new JsonPayload(hitTimes, audioPlayer.clip.name));

                            Debug.Log(hitTimesJson);

                            using (System.IO.StreamWriter writer = new System.IO.StreamWriter($@"C:\dev\Unity\LetsLearnUnity\Assets\HelperTools\HitTimesData.json", false))
                            {
                                writer.WriteLine(hitTimesJson);
                            }
        }
                        //Time.fixedDeltaTime = oldTimeStep;
                        //Time.maximumDeltaTime = oldMaxTimeStep;

                        //string output = "List<float> hitTimes = new List<float> {";
                        //string content = "";

                        //for(int i = 0; i < hitTimes.Count; i++)
                        //{
                        //    if(i != hitTimes.Count - 1)
                        //    {
                        //        content += $"{hitTimes[i]}f, ";
                        //    }
                        //    else
                        //    {
                        //        content += $"{hitTimes[i]}f";
                        //    }
                        //}

                        //output += content + "};";

                        //Debug.Log(output);


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
        else
        {
            l1 = l2 = l3 = l4 = false;
            audioPlayer.Stop();
            StopAllCoroutines();
            displayTimer.gameObject.SetActive(false);
            hitTimes = new List<float>();
            totalClicks = 0;
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

        displayTimer.text = "Musician mode";
        displayTimer.gameObject.SetActive(true);;
        yield return new WaitForSeconds(waitTime);
        displayTimer.text = "3";
        yield return new WaitForSeconds(waitTime);
        displayTimer.text = "2";
        yield return new WaitForSeconds(waitTime);
        displayTimer.text = "1";
        yield return new WaitForSeconds(waitTime);
        displayTimer.gameObject.SetActive(false);
        l1 = true;
    }

}

[Serializable]
public class JsonPayload
{
    public List<float> hitTimes;
    public string songName;

    public JsonPayload(List<float> hitTimes, string songName)
    {
        this.hitTimes = hitTimes;
        this.songName = songName;
    }
}
