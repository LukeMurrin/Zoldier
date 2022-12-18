using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    //Variables
    public TextMeshProUGUI timerText;
    public float currentTime;
    //public bool countUp;

    //Methods
    void Update()
    {
        currentTime = currentTime += Time.deltaTime;
        timerText.text = currentTime.ToString("0:00");
    }
}
