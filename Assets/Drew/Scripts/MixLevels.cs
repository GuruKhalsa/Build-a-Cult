﻿using UnityEngine;
using UnityEngine.Audio;

namespace AssemblyCSharp
{
	public class MixLevels : MonoBehaviour
	{
		public AudioMixer masterMixer;

		public void SetSfxLvl (float sfxLvl)
		{
			masterMixer.SetFloat ("sfxVol", sfxLvl);
		}

		public void SetMusicLvl (float musicLvl)
		{
			masterMixer.SetFloat ("musicVol", musicLvl);
		}
	}
}