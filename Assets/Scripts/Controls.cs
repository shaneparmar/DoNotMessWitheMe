using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class NewBehaviourScript : MonoBehaviour
{
    public AudioMixer mixer;

    float volume_master = 0;
    float volume_music = 0;
    float volume_ambient = 0;
    float volume_sfx = 0;

    bool mute = false;

    void SaveSettings()
    {
        mixer.GetFloat("volume_master", out volume_master);
        mixer.GetFloat("volume_music", out volume_music);
        mixer.GetFloat("volume_ambient", out volume_ambient);
        mixer.GetFloat("volume_sfx", out volume_sfx);
    }

    void RestoreSettings()
    {
        mixer.SetFloat("volume_master", volume_master);
        mixer.SetFloat("volume_music", volume_music);
        mixer.SetFloat("volume_ambient", volume_ambient);
        mixer.SetFloat("volume_sfx", volume_sfx);
    }

    // Start is called before the first frame update
    void Start()
    {
        SaveSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if (mute == false)
            {
                mute = true;
                mixer.SetFloat("volume_master", -80);
            }
            else
            {
                mute = false;
                RestoreSettings();
            }
        }
    }
}
