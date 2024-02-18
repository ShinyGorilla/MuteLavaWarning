using System;
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;
using Utilla;

namespace MuteLavaWarning
{
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		public static AudioSource Audio;
		void Start()
		{
            GorillaTagger.OnPlayerSpawned(PlayerSpawned);
        }

		void OnEnable() => HarmonyPatches.ApplyHarmonyPatches();
		void OnDisable() => HarmonyPatches.RemoveHarmonyPatches();

		void PlayerSpawned()
		{
            Debug.Log("Mute Lava Warning Initialized");

            Audio = GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/SoundPostForest/geo/ForestSpeakerAudioSrc_Song2").GetComponent<AudioSource>();
        }

		void Update()
		{
            Audio.mute = true;
        }
	}
}
