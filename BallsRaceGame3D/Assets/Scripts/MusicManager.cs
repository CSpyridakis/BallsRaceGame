using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

/*
 * @brief Manipulates all Game Sounds and Background Music
 */
public class MusicManager : MonoBehaviour
{

	public MusicClip[] audioFiles;
	
	/*
	 * @brief Create Audio Sources foreach Audio File in order to Play them
	 */
	void Awake ()
	{
		foreach (MusicClip o in audioFiles)
		{
			o.source = gameObject.AddComponent<AudioSource>();
			o.source.clip = o.audiofile;
			o.source.volume = o.volume;
			o.source.loop = o.loop;
			o.source.playOnAwake=false;
		}
	}
	
	/*
	 * @brief Play Menu Background Audio File (Loop = true)
	 */
	private void Start()
	{
		Play("MenuSound");
	}
	
	/*
	 * @brief On Click Play Click sound effect ONLY ONCE PER TIME (Loop = false)
	 */
	public void Click()
	{
		Play("Click");
	}
	
	/*
	 * @brief If player triggered a Boost call this in order to play Boost sound effect ONLY ONCE PER TIME (Loop = false)
	 */
	public void Boost()
	{
		Play("Boost");
	}
	
	/*
	 * @brief If player collided with an Obstacle call this in order to play Obstacle sound effect ONLY ONCE PER TIME (Loop = false)
	 */
	public void Obstacle()
	{
		Play("Obstacle");
	}

	/*
	 * @brief Play a specific File Source with a specific Name
	 *
	 * @param audioName Name of the desired Audio Source
	 */
	public void Play(string audioName)
	{
		foreach (var o in audioFiles)
		{
			if (o.AudioName.Equals(audioName))
			{
				if (o.AudioName.Equals("MenuSound"))
				{
					o.source.volume = 0.01f;
					o.source.loop = true;
					o.source.Play();
				}
				else
				{
					o.source.volume = 1f;
					o.source.Play();
				}
			}
		}

	}
	
	/*
	 * @brief Pause a specific File Source with a specific Name
	 *
	 * @param audioName Name of the desired Audio Source
	 */
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

/*
 * @brief Needed Class in order to Create Audio Sources
 */
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
