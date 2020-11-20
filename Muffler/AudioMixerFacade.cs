using System;
using UnityEngine;
using UnityEngine.Audio;

namespace AudioMuffler {

	/// <summary>
	/// Description of AudioMixerFacade.
	/// </summary>
	public class AudioMixerFacade
	{
		
		private static bool BundleLoaded = false;
		
		private static AudioMixer audioMixer;
		
		public AudioMixerGroup MasterGroup {get; set;}
		public AudioMixerGroup InVesselGroup {get; set;}
		public AudioMixerGroup OutsideGroup {get; set;}
		public AudioMixerGroup HelmetGroup {get; set;}
		
		public void muteInVessel(bool mute) {
			audioMixer.SetFloat("InVesselVolume", mute ? -80 : 0);
		}

		public void muteOutside(bool mute) {
			audioMixer.SetFloat("OutsideVolume", mute ? -80 : 0);
		}

		public void setInVesselVolume(float volume) {
			audioMixer.SetFloat("InVesselVolume", volume);
		}

		public void setInVesselCutoff(float cutoff) {
			audioMixer.SetFloat("InVesselCutoff", cutoff);
		}

		public void setOutsideVolume(float volume) {
			audioMixer.SetFloat("OutsideVolume", volume);
		}
		
		public void setOutsideCutoff(float cutoff) {
			audioMixer.SetFloat("OutsideCutoff", cutoff);
		}

		public void muteHelmet(bool mute) {
			audioMixer.SetFloat("HelmetVolume", mute ? -80 : 0);
		}
		
		public static AudioMixerFacade InitializeMixer(string path) {
			AudioMixerFacade instance = new AudioMixerFacade ();
			if (audioMixer == null) {
				audioMixer = LoadBundle (path);
			}
			instance.MasterGroup = audioMixer.FindMatchingGroups("Master") [0];
			instance.InVesselGroup = audioMixer.FindMatchingGroups("InVessel") [0];
			instance.OutsideGroup = audioMixer.FindMatchingGroups("Outside") [0];
			instance.HelmetGroup = audioMixer.FindMatchingGroups("Helmet") [0];
			return instance;
		}
		
		public static AudioMixer LoadBundle(string path)
		{
			if (BundleLoaded) {
				return null;
			}
			
			using (WWW www = new WWW ("file://" + path)) {
				if (www.error != null) {
					Debug.Log ("Audio Muffler: Mixer bundle not found!");
					return null;
				}
	
				AssetBundle bundle = www.assetBundle;
			
				AudioMixer audioMixer = bundle.LoadAsset<AudioMixer> ("KSPAudioMixer");
			
				bundle.Unload (false);
				www.Dispose ();
			
				BundleLoaded = true;
				return audioMixer;
			}
		}
		
	}

}