using UnityEngine;
using System.Collections;

public class AdhanController : MonoBehaviour {

    public GameObject sun;
    public bool sunBelowHorizon;
    public AudioSource adhanSource;
    public TOD_Sky sky;
	public ReverNodeZoneDetectorForListener RNZDFL;
	public AudioLowPassFilter filter;

    public bool fajrWasCalled = false;
    public bool dhuhrWasCalled = false;
    public bool asrWasCalled = false;
    public bool maghribWasCalled = false;
    public bool ishaWasCalled = false;

    // Use this for initialization
    void Start () {
		RNZDFL = GameObject.FindObjectOfType<ReverNodeZoneDetectorForListener> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (RNZDFL==null) {
			RNZDFL = GameObject.FindObjectOfType<ReverNodeZoneDetectorForListener> ();
		}
		if (RNZDFL.playerIsInside) {
			filter.enabled = true;
		} else {
			filter.enabled = false;
		}

        //is the sun visible?
        if (sun.transform.position.y < -3)
        {
            sunBelowHorizon = true;
        }
        else
        {
            sunBelowHorizon = false;
        }

        //is it just before sunrise?
        if (sunBelowHorizon == false && sky.Cycle.Hour < 12 && fajrWasCalled==false)
        {
            CallToPrayer();
            fajrWasCalled = true;
        }
        
        //is it noon?
        if (sky.Cycle.Hour >= 12 && dhuhrWasCalled == false)
        {
            CallToPrayer();
            dhuhrWasCalled = true;
        }

        //is it afternoon?
        if (sky.Cycle.Hour >= 15 && asrWasCalled == false)
        {
            CallToPrayer();
            asrWasCalled = true;
        }

        if (sunBelowHorizon ==true && maghribWasCalled ==false && sky.Cycle.Hour >= 12)
        {
            CallToPrayer();maghribWasCalled = true;
        }

        if (sky.Cycle.Hour >= 22 && ishaWasCalled==false)
        {
            CallToPrayer(); ishaWasCalled = true;
        }

        //reset at midnght
        if (sky.Cycle.Hour < 1)
        {
            fajrWasCalled = false;dhuhrWasCalled = false;asrWasCalled = false;maghribWasCalled = false;ishaWasCalled = false;
}

	}

    void CallToPrayer()
    {
        adhanSource.Play();
    }
}
