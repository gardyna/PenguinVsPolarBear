using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BeatmapTimerHard : MonoBehaviour {

	[SerializeField]
	private AudioSource noot;
	[SerializeField]
	private AudioSource cue;
	[SerializeField]
	private Launcher bearLauncher;
	[SerializeField]
	private Launcher penguinLauncher;
	[SerializeField]
	private double launcherOffset;

	[SerializeField]
	private GameUIManagerScript m_GameUIManager;

	private List<double> beatMap;

	private double bpm;
	private double bpmInSeconds;

	private double nextTime;
	private double cueTime;
	private double launchTime;

	private int beatMapPos;
	private int cueMapPos;
	private int launchMapPos;


	private List<double> GenLevel() {
		List<double> level = new List<double>();
		double[] firstPool = { 4, 2, 2 };
		double[] secondPool = { 2, 1, 1 };
		double[] thirdPool = { 2, 1, 1, 1 };
		double[] fourthPool = { 2, 1, 1, 1, 0.5, 0.5 };
		double sum = 0;

		for (int i = 0; i < 4; i++) {
			//First sublevel. Endsums 4 and 6.
			while (sum < 4) {
				double pick = firstPool [Random.Range (0, firstPool.Length - 1)];
				if (pick + sum < 4) {
					sum += pick;
					level.Add (pick);
				} else if (pick + sum == 4 || pick + sum == 6) {
					sum += pick;
					level.Add (pick);
					level.Add (16 - sum);
				}
			}
			sum = 0;
		}

		for (int i = 0; i < 4; i++) {
			while (sum < 6) {
				double pick = secondPool [Random.Range (0, secondPool.Length - 1)];
				if (pick + sum < 6) {
					sum += pick;
					level.Add (pick);
				} else if (pick + sum == 6) {
					sum += pick;
					level.Add (pick);
					level.Add (16 - sum);
				}
			}
			sum = 0;
		}

		for (int i = 0; i < 4; i++) {
			while (sum < 7) {
				double pick = thirdPool [Random.Range (0, thirdPool.Length - 1)];
				if (pick + sum < 7) {
					sum += pick;
					level.Add (pick);
				} else if (pick + sum == 7) {
					sum += pick;
					level.Add (pick);
					level.Add (16 - sum);
				}
			}
			sum = 0;
		}

		for (int i = 0; i < 4; i++) {
			while (sum < 7) {
				int mult = 1;
				double pick = fourthPool [Random.Range (0, fourthPool.Length - 1)];
				if (pick == 0.5) {
					mult = 2;
				}
				if (mult*pick + sum < 7) {
					sum += mult*pick;
					level.Add (pick);
					if (pick == 0.5) {
						level.Add (pick);
					}
				} else if (mult * pick + sum == 7) {
					sum += mult*pick;
					level.Add (pick);
					if (pick == 0.5) {
						level.Add (pick);
					}
					level.Add (16 - sum);
				}
			}
			sum = 0;
		}
		return level;
	}

	void Start () {
		bpm = 140;
		bpmInSeconds = 60 / bpm;
		beatMap = GenLevel ();
		nextTime = AudioSettings.dspTime + 16*bpmInSeconds;
		cueTime = nextTime - 8 * bpmInSeconds;
		launchTime = nextTime - 4 * bpmInSeconds + launcherOffset;
	}

	void Update () {
		if (AudioSettings.dspTime >= cueTime) {
			cue.Play ();
			cueTime += beatMap[cueMapPos] * bpmInSeconds;

			if (beatMap [cueMapPos] < 8) {
				cue.pitch = (float)(2 / beatMap [cueMapPos]);
			} else {
				cue.pitch = 1;
			}

			//TODO: muna að taka í burtu þegar þetta loopar ekki lengur
			if (cueMapPos + 1 == beatMap.Count) {
				cueMapPos = 0;
			} else {
				cueMapPos += 1;
			}
		}

		if (AudioSettings.dspTime >= nextTime) {
			//noot.Play();
			nextTime += beatMap[beatMapPos]*bpmInSeconds;

			//TODO: muna að taka i'burtu þegar þeta loopar ekki lengur
			if (beatMapPos+1 == beatMap.Count) {
				beatMapPos = 0;
				launchMapPos = 0;
				cueMapPos = 0;
				StartCoroutine(EndGame());
			} else {
				beatMapPos += 1;
			}
		}

		if (AudioSettings.dspTime >= launchTime) {
			if (Random.Range (0, 2) == 1) {
				bearLauncher.FireIce ();
				penguinLauncher.FireIce ();
			} else {
				bearLauncher.FireBox ();
				penguinLauncher.FireBox ();
			}


			launchTime += beatMap [launchMapPos] * bpmInSeconds;

			//TODO: muna að taka í burtu þegar þetta loopar ekki lengur
			if (launchMapPos + 1 == beatMap.Count) {
				launchMapPos = 0;
			} else {
				launchMapPos += 1;
			}
		}
	}

	private IEnumerator EndGame() {
		beatMap.Clear();
		beatMap.Add(double.PositiveInfinity);
		yield return new WaitForSeconds(3);
		m_GameUIManager.GameOver();

	}
}