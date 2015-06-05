using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class AudioProximityTrigger : MonoBehaviour {

    public GameObject target;
    public float sendlevel;
    public AudioMixer mixer;
    public string parameter_name;
    
    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        MixReverb(this.transform.position, target.transform.position, parameter_name);
	}

    void MixReverb(Vector3 origin, Vector3 target, string parameter_name)
    {
        sendlevel = 1/Vector3.SqrMagnitude(target - origin);
        mixer.SetFloat(parameter_name, sendlevel);
    }
}
