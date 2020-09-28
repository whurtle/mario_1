using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time : MonoBehaviour
{
    public int levelSeconds;
    public Text timerText;

    private System.TimeSpan start;
    // Start is called before the first frame update
    void Start()
    {
        start = new System.TimeSpan(System.DateTime.Now.Ticks);
    }

    // Update is called once per frame
    void Update()
    {
        var time = Current();
        if (time > 0)
        {
            timerText.text = time.ToString();
        }
        else
        {
            timerText.text = 0.ToString();
        }
    }

    private int Current()
    {
        var current = new System.TimeSpan(System.DateTime.Now.Ticks);
        var diff = current.Subtract(start).TotalSeconds;

        return levelSeconds - (int)diff;
    }
}
