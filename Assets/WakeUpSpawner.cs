using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WakeUpSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Spawner spawner;
    public TextMeshPro displayTimer;
    bool l1 = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && l1)
        {
            l1 = false;
            StartCoroutine(Intro(1));
        }
    }

    IEnumerator Intro(float waitTime)
    {
        //Time.fixedDeltaTime = newTimeStep;
        //Time.maximumDeltaTime = newMaxTimeStep;
        displayTimer.gameObject.SetActive(true);
        displayTimer.text = "3";
        yield return new WaitForSeconds(waitTime);
        displayTimer.text = "2";
        yield return new WaitForSeconds(waitTime);
        displayTimer.text = "1";
        yield return new WaitForSeconds(waitTime);
        displayTimer.gameObject.SetActive(false);
        spawner.gameObject.SetActive(true);
    }
}
