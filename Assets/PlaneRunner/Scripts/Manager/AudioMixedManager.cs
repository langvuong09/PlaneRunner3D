using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
[AddComponentMenu("TienCuong/AudioMixedManager")]
public class AudioMixedManager : MonoBehaviour
{
    public AudioMixer masterMixed;
    public Slider sliderMusic;
    void Start()
    {
        float volumeMusic = PlayerPrefs.GetFloat("VolumeMusic", 20);
        sliderMusic.value = volumeMusic;
        UpdateMusicVolume(volumeMusic);
    }

    // Update is called once per frame
    public void UpdateMusicVolume(float volume)
    {
        masterMixed.SetFloat("VolumeMusic", volume);
        PlayerPrefs.SetFloat("VolumeMusic", volume);
    }
}