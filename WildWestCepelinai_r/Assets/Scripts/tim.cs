using UnityEngine;
using System.Collections;
using TMPro;

public class tim : MonoBehaviour
{
    public TextMesh timer;
    public static float remainingTime;


    IEnumerator Start()
    {
        enabled = false;
        timer.text = "";
        yield return new WaitForSeconds(3);
        remainingTime = 60;
        enabled = true;
    }

        // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1)) // debug
        {
            remainingTime = 10;
        }
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timer.text = string.Format("{0}:{1:00}", minutes, seconds);
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            timer.text = "Time's up. \nPress R to restart";
        }

        
    }
}
