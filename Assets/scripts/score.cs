using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    
    public Text timer;
    private float startTimer;

    private void Start()
    {
        startTimer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTimer;

        string min = ((int)t / 60).ToString("f2");

        timer.text = min;
    }
}
