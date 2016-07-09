using UnityEngine;
using System.Collections;
using System;
using UnityEngine.Events;
using UnityEngine.UI;

public class SimpleCalendar : MonoBehaviour {

	public TOD_Sky Sky;
	public string dotw;
	public Text text;

	public void CheckDay ()
	{
		text.text = Sky.Cycle.DateTime.DayOfWeek.ToString ();;
	}

	void Update ()
	{
		CheckDay ();
	}
}



