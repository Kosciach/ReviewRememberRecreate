using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;

    [Header("====References====")]
    [SerializeField] AudioSource _musicAudio;
    [SerializeField] AudioSource _soundsAudio;
    [Space(5)]
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _soundsSlider;

    [Space(20)]
    [Header("====Debugs====")]
    [SerializeField] AudioSettings _audioSettings;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);


        _musicAudio = GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>();
        _soundsAudio = GameObject.FindGameObjectWithTag("Sounds").GetComponent<AudioSource>();

        if (File.Exists(Application.dataPath + "/AudioSettings.json")) LoadSettings();
        else
        {
            _audioSettings.MusicVolume = 0.5f;
            _audioSettings.SoundsVolume = 0.5f;
            SaveSettings();

            _musicAudio.volume = _audioSettings.MusicVolume;
            _soundsAudio.volume = _audioSettings.SoundsVolume;

            _musicSlider.value = _audioSettings.MusicVolume;
            _soundsSlider.value = _audioSettings.SoundsVolume;
        }
    }


    public void ChangeMusicVolume(Slider choosenSlider)
    {
        _audioSettings.MusicVolume = choosenSlider.value;
        _musicAudio.volume = _audioSettings.MusicVolume;
        SaveSettings();
    }
    public void ChangeSoundVolume(Slider choosenSlider)
    {
        _audioSettings.SoundsVolume = choosenSlider.value;
        _soundsAudio.volume = _audioSettings.SoundsVolume;
        SaveSettings();
    }

    public void PlayButtonSound()
    {
        _soundsAudio.Play();
    }


    private void SaveSettings()
    {
        string jsonAudioSettings = JsonUtility.ToJson(_audioSettings);
        File.WriteAllText(Application.dataPath + "/AudioSettings.json", jsonAudioSettings);
    }
    private void LoadSettings()
    {
        string jsonAudioSettings = File.ReadAllText(Application.dataPath + "/AudioSettings.json");
        _audioSettings = JsonUtility.FromJson<AudioSettings>(jsonAudioSettings);

        _musicSlider.value = _audioSettings.MusicVolume;
        _soundsSlider.value = _audioSettings.SoundsVolume;

        _musicAudio.volume = _audioSettings.MusicVolume;
        _soundsAudio.volume = _audioSettings.SoundsVolume;
    }
}
