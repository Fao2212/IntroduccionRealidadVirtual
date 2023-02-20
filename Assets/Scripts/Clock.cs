using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;

public class Clock : MonoBehaviour
{
    public GameObject secondObject;
    public GameObject minuteObject;
    public GameObject hourObject;
    // Start is called before the first frame update
    int secondCounter;
    int minuteCounter;

    //Hours 360/12
    int hourDegrees = 360 / 12;
    //Minutes = 360/60
    int minutesDegrees = 360 / 60;
    //Seconds = 360/60
    int secondsDegrees = 360 / 60;

    float elapsedTime = 0;
    float targetTime = 1;

    private void setTimeInClock()
    {
        DateTime timeNow = DateTime.Now;
        secondObject.transform.Rotate(new Vector3(timeNow.Second*secondsDegrees,0,0));
        minuteObject.transform.Rotate(new Vector3(timeNow.Minute * minutesDegrees, 0, 0));
        hourObject.transform.Rotate(new Vector3(timeNow.Hour * hourDegrees, 0, 0));
        secondCounter = timeNow.Second;
        minuteCounter = timeNow.Minute;
    }

    private void increaseSecond()
    {
        if(secondCounter == 60)
        {
            secondCounter = 0;
            increaseMinute();
        }
        secondCounter += 1;
        secondObject.transform.Rotate(new Vector3(secondsDegrees, 0, 0));
    }

    private void increaseMinute()
    {
        if(minuteCounter == 60)
        {
            minuteCounter = 0;
            increaseHour();
        }
        minuteCounter += 1;
        minuteObject.transform.Rotate(new Vector3(minutesDegrees, 0, 0));
    }

    private void increaseHour()
    {
        hourObject.transform.Rotate(new Vector3(minutesDegrees, 0, 0));
    }

    void Start()
    {
        setTimeInClock();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime > targetTime)
        {
            elapsedTime = 0;
            increaseSecond();
        }
        
    }
}
