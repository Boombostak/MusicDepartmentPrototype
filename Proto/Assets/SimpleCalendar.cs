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
		dotw = Sky.Cycle.DateTime.DayOfWeek.ToString ();
		text.text = dotw;
	}

	void Update ()
	{
		CheckDay ();
	}
}



