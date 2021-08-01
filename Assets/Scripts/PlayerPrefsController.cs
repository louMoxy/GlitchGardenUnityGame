using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master volume";
    const string DIFFICULTY_KEY = "difficulty";
    const float MIN_VOLUME = 0;
    const float MAX_VOLUME = 1;
    const float MIN_DIFF = 1;
    const float MAX_DIFF = 10;

    public static  void SetMasterVolume(float volume)
    {
        if(volume >= MIN_VOLUME && volume <= MAX_VOLUME)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Volume is outside of bounds");
        }
    }

    public static void SetDifficulty(float level)
    {
        if (level >= MIN_DIFF && level <= MAX_DIFF)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, level);
        }
        else
        {
            Debug.LogError("Difficulty is outside of bounds");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
