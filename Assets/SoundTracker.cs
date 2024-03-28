using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTracker : MonoBehaviour {
    
    public static SoundTracker Instance;
    public AudioLowPassFilter mylowpass;

    private AudioSource audioSource;
    private const string MUTE_PREF_KEY = "MutePreference";
    private const int MUTED = 1;
    private const int UN_MUTED = -1;

    void Awake()
    {
        if (Instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        // Get audio source component
        audioSource = GetComponent<AudioSource>();

        // Set mute based on the valued stored in PlayerPrefs
        if(IsMuted())
            audioSource.Stop();
    }

    public bool IsMuted()
    {
        return (PlayerPrefs.GetInt(MUTE_PREF_KEY, UN_MUTED) == MUTED);
    }

    public void lowPassIt()
    {
    
        mylowpass.cutoffFrequency = 1200;
    }

    public void unPassIt()
    {
       
  
        mylowpass.cutoffFrequency = 22000;
    }
 
	
	// Update is called once per frame
	void Update () {
        if (IsMuted())
            audioSource.Stop();
        else if(audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
	}
}
