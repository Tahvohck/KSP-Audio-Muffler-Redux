/*
 * Created by SharpDevelop.
 * Date: 26.10.2016
 * Time: 11:17
 */
using System;

namespace AudioMuffler
{
	/// <summary>
	/// Description of Config.
	/// </summary>
	public class AudioMufflerConfig
	{
		public bool Debug {get; set;}
		public bool EngageMuffler {get; set;}
		public int MinCacheUpdateInterval {get; set;}
		public float WallCutoff {get; set;}
		public float MinimalCutoff {get; set;}
		public bool HelmetOutsideIVA {get; set;}
		public bool HelmetOutsideEVA {get; set;}
		public bool HelmetInMapView {get; set;}
		public bool HelmetForUnmanned { get; set;}
		public bool VesselInMapView {get; set;}
		public bool OutsideInMapView {get; set;}
		
		public static AudioMufflerConfig loadConfig() {
			AudioMufflerConfig config = new AudioMufflerConfig();
			
			string path =
                KSP.IO.IOUtils
                .GetFilePathFor(typeof(Muffler), "muffler.cfg")
                .Replace("/", System.IO.Path.DirectorySeparatorChar.ToString());
	        ConfigNode node = ConfigNode.Load(path);
	        
	        config.Debug = bool.Parse(node.GetValue("debug"));
	        config.EngageMuffler = bool.Parse(node.GetValue("enabled"));
			config.MinCacheUpdateInterval = int.Parse(node.GetValue("minCacheUpdateInterval"));
			config.WallCutoff = float.Parse(node.GetValue("wallCutoff"));
			config.MinimalCutoff = float.Parse(node.GetValue("minimalCutoff"));
			config.HelmetOutsideIVA = bool.Parse(node.GetValue("helmetOutsideIVA"));
			config.HelmetOutsideEVA = bool.Parse(node.GetValue("helmetOutsideEVA"));
			config.HelmetForUnmanned = bool.Parse(node.GetValue("helmetOutsideEVA"));
			config.HelmetInMapView = bool.Parse(node.GetValue("helmetInMapView"));
			config.VesselInMapView = bool.Parse(node.GetValue("vesselInMapView"));
			config.OutsideInMapView = bool.Parse(node.GetValue("outsideInMapView"));
			
			return config;
		}
		
	}
}
