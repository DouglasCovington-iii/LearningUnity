using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeUpSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public Spawner spawner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(WakeUp());
    }

    IEnumerator WakeUp()
    {
        yield return new WaitForSeconds(2);
        spawner.gameObject.SetActive(true);

    }
}
