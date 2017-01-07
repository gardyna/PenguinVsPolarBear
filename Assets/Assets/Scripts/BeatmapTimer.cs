using UnityEngine;
using System.Collections;

public class BeatmapTimer : MonoBehaviour {

	[SerializeField]
	private AudioSource noot;
	[SerializeField]
	private int initDelay = 16;

	private double bpm;
	private double bpmInSeconds;
	private double nextTime;
	private double[] beatMap;
	private int beatMapPos;

	void Start () {
		bpm = 140;
		bpmInSeconds = 60 / bpm;
		//Hver taktur gengur upp i fjora
		//Gott að aðskilja fernurnar með enter
		beatMap = new double[] 
			{1, 0.5, 1, 0.5, 1,
			1, 0.5, 1, 0.5, 1,
			2, 2,
			1, 1, 2, 
			1, 1, 0.5, 1.5,
			1, 1, 0.5, 1.5,
			1, 1, 1, 1,
			0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5,
			};
		nextTime = AudioSettings.dspTime + initDelay*bpmInSeconds;
	}

	void Update () {
		//If setningin gengur í gegn þegar dspTime er on beat (ekki staðfest nákvæmt)
		if (AudioSettings.dspTime >= nextTime) {
			noot.Play();
			nextTime += beatMap[beatMapPos]*bpmInSeconds;

			//Temporary looping conditional.
			//TODO: Ending
			if (beatMapPos+1 == beatMap.Length) {
				beatMapPos = 0;
			} else {
				beatMapPos += 1;
			}
		}
	}

}