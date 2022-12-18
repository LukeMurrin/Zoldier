using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    //variables
    public Text counterText;
    int kills;

    //methods

    void Update()
    {
        ShowKills();
    }
    
    private void ShowKills()
    {
        counterText.text = kills.ToString();
    } 

    public void AddKill()
    {
        kills++;
    }
}
