using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    private int currentScore = 0;
    private float audioVolume = 1.0f;
    public static GameManager instance;
    public TextMeshProUGUI scoreText;
    public AudioMixer audioMixer;

    // Audio properties
    public float AudioVolume
    {
        get { return audioVolume; }
        set
        {
            audioVolume = Mathf.Clamp01(value);  // Clamp volume between 0 and 1
            // Apply volume settings to AudioMixer
            audioMixer.SetFloat("volume", Mathf.Log10(audioVolume) * 20); // Convert linear volume to decibels
            Debug.Log("Audio volume changed to: " + audioVolume);
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void IncreaseScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        scoreText.text = currentScore.ToString() + " / 5";
        Debug.Log(currentScore);
    }
}
