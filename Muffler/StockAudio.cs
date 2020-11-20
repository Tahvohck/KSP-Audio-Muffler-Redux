using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace AudioMuffler {

	/// <summary>
	/// Description of StockAudio.
	/// </summary>
	public class StockAudio
	{
		
		private static List<string> AMBIENT = new List<string> {"FX Sound", "airspeedNoise"};
		private static List<string> PRESERVED = new List<string> {"MusicLogic"};
		private static List<string> INVESSEL = new List<string> {"StageManager(Clone)"};
		
		public static bool IsAmbient(AudioSource audioSource) {
			return AMBIENT.Contains(audioSource.name) || audioSource.name.StartsWith("Explosion");
		}
		
		public static bool IsPreserved(AudioSource audioSource) {
			return PRESERVED.Contains(audioSource.name);
		}

		public static bool IsInVessel(AudioSource audioSource) {
			return INVESSEL.Contains(audioSource.name);
		}

		public static void PrepareAudioSources(AudioMixerFacade audioMixer, AudioSource[] audioSources) {
			for (int i = 0; i < audioSources.Length; i++) {
				if (IsAmbient(audioSources[i])) {
					audioSources[i].outputAudioMixerGroup = audioMixer.OutsideGroup;
				} else if (IsInVessel(audioSources[i])) {
					audioSources[i].outputAudioMixerGroup = audioMixer.InVesselGroup;
				}
			}
		}
		
		/*public static void prepareAudioSources(AudioSource[] audioSources) {
			for (int i = 0; i < audioSources.Length; i++) {
				if (isAmbient(audioSources[i])) {
					audioSources[i].bypassEffects = false;
					audioSources[i].bypassListenerEffects = false;
				} else if (isPreserved(audioSources[i])) {
					audioSources[i].bypassEffects = true;
				}
			}
		}*/
		
		
	}
}