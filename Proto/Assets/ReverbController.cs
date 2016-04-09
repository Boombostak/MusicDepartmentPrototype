using UnityEngine;
using System.Collections;
using UnityEngine.Audio;
using System.Linq;

//[RequireComponent (AudioReverbFilter)]
public class ReverbController : MonoBehaviour {

	//NOTE: Indexes of Node array, parameter array must match!!!
	//Set up nodes array length in editor!

	public AudioReverbFilter filter;
	public ReverbParameters averagedVerbParams;
	public GameObject[] nodes;
	public float[] closenesses;
	public ReverbParameters[] nodeParams;
	public AudioSource target;
	public RaycastHit hitToTestInside;
	public bool isInside;

	public float sumDryLevel;
	public float blendedDryLevel;
	public float sumRoom;
	public float blendedRoom;
	public float sumRoomHF;
	public float blendedRoomHF;
	public float sumRoomLF;
	public float blendedRoomLF;
	public float sumDecayTime;
	public float blendedDecayTime;
	public float sumHFRatio;
	public float blendedHFRatio;
	public float sumReflectionsLevel;
	public float blendedReflectionsLevel;
	public float sumReflectionsDelay;
	public float blendedReflectionsDelay;
	public float sumReverbLevel;
	public float blendedReverbLevel;
	public float sumReverbDelay;
	public float blendedReverbDelay;
	public float sumHFReference;
	public float blendedHFReference;
	public float sumLFReference;
	public float blendedLFReference;
	public float sumDiffusion;
	public float blendedDiffusion;
	public float sumDensity;
	public float blendedDensity;



	public void SetUp()
	{
		for (int i = 0; i < GameObject.Find("reverbManager").transform.FindChild("nodesGO").childCount; i++)
		{
			nodes[i] = GameObject.Find("reverbManager").transform.FindChild("nodesGO").transform.GetChild(i).gameObject;
			nodeParams [i] = nodes [i].GetComponent<ReverbParameters> ();
		}
	}

	void BlendNodeParams(){
		for (int i = 0; i < nodeParams.Length; i++) {
			sumDryLevel += (nodeParams [i].drylevel * closenesses[i]);
		}
		blendedDryLevel = sumDryLevel/(float)nodeParams.Length;

		for (int i = 0; i < nodeParams.Length; i++) {
			sumRoom += (nodeParams [i].room * closenesses[i]);
		}
		blendedRoom = sumRoom/(float)nodeParams.Length;

		for (int i = 0; i < nodeParams.Length; i++) {
			sumRoomHF += (nodeParams [i].roomhf * closenesses[i]);
		}
		blendedRoomHF = sumRoomHF/(float)nodeParams.Length;

		for (int i = 0; i < nodeParams.Length; i++) {
			sumRoomLF += (nodeParams [i].drylevel * closenesses[i]);
		}
		blendedDryLevel = sumDryLevel/(float)nodeParams.Length;
		for (int i = 0; i < nodeParams.Length; i++) {
			sumDryLevel += (nodeParams [i].drylevel * closenesses[i]);
		}
		blendedDryLevel = sumDryLevel/(float)nodeParams.Length;
		for (int i = 0; i < nodeParams.Length; i++) {
			sumDryLevel += (nodeParams [i].drylevel * closenesses[i]);
		}
		blendedDryLevel = sumDryLevel/(float)nodeParams.Length;
		for (int i = 0; i < nodeParams.Length; i++) {
			sumDryLevel += (nodeParams [i].drylevel * closenesses[i]);
		}
		blendedDryLevel = sumDryLevel/(float)nodeParams.Length;
		for (int i = 0; i < nodeParams.Length; i++) {
			sumDryLevel += (nodeParams [i].drylevel * closenesses[i]);
		}
		blendedDryLevel = sumDryLevel/(float)nodeParams.Length;
		for (int i = 0; i < nodeParams.Length; i++) {
			sumDryLevel += (nodeParams [i].drylevel * closenesses[i]);
		}
		blendedDryLevel = sumDryLevel/(float)nodeParams.Length;
		for (int i = 0; i < nodeParams.Length; i++) {
			sumDryLevel += (nodeParams [i].drylevel * closenesses[i]);
		}
		blendedDryLevel = sumDryLevel/(float)nodeParams.Length;
		for (int i = 0; i < nodeParams.Length; i++) {
			sumDryLevel += (nodeParams [i].drylevel * closenesses[i]);
		}
		blendedDryLevel = sumDryLevel/(float)nodeParams.Length;
		for (int i = 0; i < nodeParams.Length; i++) {
			sumDryLevel += (nodeParams [i].drylevel * closenesses[i]);
		}
		blendedDryLevel = sumDryLevel/(float)nodeParams.Length;
		for (int i = 0; i < nodeParams.Length; i++) {
			sumDryLevel += (nodeParams [i].drylevel * closenesses[i]);
		}
		blendedDryLevel = sumDryLevel/(float)nodeParams.Length;
		for (int i = 0; i < nodeParams.Length; i++) {
			sumDryLevel += (nodeParams [i].drylevel * closenesses[i]);
		}
		blendedDryLevel = sumDryLevel/(float)nodeParams.Length;
	}

	// Use this for initialization
	void Start () {
		filter = this.gameObject.GetComponent<AudioReverbFilter>();
		target = this.GetComponentInChildren<AudioSource>();
		SetUp();
	}

	[ExecuteInEditMode]
	public void AssignParamsToVerb(){
		filter.dryLevel = averagedVerbParams.drylevel;
		filter.room = averagedVerbParams.room;
		filter.roomHF = averagedVerbParams.roomhf;
		filter.roomLF = averagedVerbParams.roomlf;
		filter.decayTime = averagedVerbParams.decaytime;
		filter.decayHFRatio = averagedVerbParams.decayhfratio;
		filter.reflectionsLevel = averagedVerbParams.reflectionslevel;
		filter.reflectionsDelay = averagedVerbParams.reflectionsdelay;
		filter.reverbLevel = averagedVerbParams.reverblevel;
		filter.reverbDelay = averagedVerbParams.reverbdelay;
		filter.hfReference = averagedVerbParams.hfreference;
		filter.lfReference = averagedVerbParams.lfreference;
		filter.diffusion = averagedVerbParams.diffusion;
		filter.density = averagedVerbParams.density;
	}
	
	// Update is called once per frame
	void Update () {
		AssignParamsToVerb ();


		/*if (hitToTestInside.collider.bounds.Contains(target.gameObject.transform.position))
		{
			isInside = true;
		}
		else
		{
			isInside = false;
		}*/

		//update positions (should this be a coroutine?)
		for (int i = 0; i < nodes.Length; i++) {
			closenesses[i] = 1/
				Vector3.Distance(nodes[i].transform.position, 
					target.transform.position);
		}
	}
}
