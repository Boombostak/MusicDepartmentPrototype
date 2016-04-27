using UnityEngine;
using System.Collections;

public class TimeControl : MonoBehaviour {

    public float timeMultiplier = 1;
    public float wheelValue;
    public TOD_Time tod_time;
    public bool speedingUp;
    public bool slowingDown;
    
    // Use this for initialization
	void Start () {
        tod_time = FindObjectOfType<TOD_Time>();
	}
	
	// Update is called once per frame
	void Update () {
        wheelValue = Input.GetAxis ("Mouse ScrollWheel");

        if (wheelValue > 0)
        {
            speedingUp = true;
        }
        else
        {
            speedingUp = false;
        }

        if (wheelValue < 0)
        {
            slowingDown = true;
        }
        else
        {
            slowingDown = false;
        }
        if (speedingUp)
        {
            Mathf.Lerp(tod_time.DayLengthInMinutes, tod_time.DayLengthInMinutes / 2, 0.5f);
        }
        if (slowingDown)
        {
            Mathf.Lerp(tod_time.DayLengthInMinutes, tod_time.DayLengthInMinutes * 2, 0.5f);
        }
        if (Input.GetKeyDown("q"))
        {
            tod_time.DayLengthInMinutes= tod_time.DayLengthInMinutes * 2;
        }
        if (Input.GetKeyDown("e"))
        {
            tod_time.DayLengthInMinutes= tod_time.DayLengthInMinutes / 2;
        }

        //tod_time.DayLengthInMinutes = Mathf.Clamp(tod_time.DayLengthInMinutes, 0.0001f, 9999f) / timeMultiplier;
    }
}
