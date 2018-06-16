using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

	public float soundVolume;

	public MusicClip[] audioFiles;
	// Use this for initialization
	void Awake ()
	{
		foreach (MusicClip o in audioFiles)
		{
			o.source = gameObject.AddComponent<AudioSource>();
			o.source.clip = o.audiofile;
			o.source.volume = o.volume;
			o.source.loop = o.loop;
		}
	}
	
	
	private void Start()
	{
		Play("MenuSound");
	}
	public void Click()
	{
		Play("Click");
	}
	public void Boost()
	{
		Play("Boost");
	}	
	public void Obstacle()
	{
		Play("Obstacle");
	}

	public void Play(string audioName)
	{
		foreach (var o in audioFiles)
		{
			if (o.AudioName.Equals(audioName))
			{
				if (o.AudioName.Equals("MenuSound"))
				{
					o.source.volume = 0.001f;
				}
				else
				{
					o.source.volume = 0.7f;
				}
				o.source.Play();
			}
		}

	}
	
	public void Pause(string audioName)
	{
		foreach (var o in audioFiles)
		{
			if (o.AudioName.Equals(audioName))
			{
				o.source.Pause();
			}
		}	
	}
}



[System.Serializable]
public class MusicClip
{
	public String AudioName;
	public AudioClip audiofile;
	public float volume;
	public bool loop;

	[HideInInspector]
	public AudioSource source;

}
