using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;
    [Header("====AudioSources====")]
    [SerializeField] AudioSource[] _soundSources;
    [SerializeField] AudioSource[] _musicSources;


    [Space(20)]
    [Header("====Sliders====")]
    [SerializeField] Slider[] _soundSliders;
    [SerializeField] Slider[] _musicSliders;


    [Space(20)]
    [Header("====Keys====")]
    [SerializeField] string _soundKey;
    [SerializeField] string _musicKey;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Start()
    {
        if(!PlayerPrefs.HasKey(_soundKey)) PlayerPrefs.SetFloat(_soundKey, 0);

        foreach(Slider slider in _soundSliders) slider.value = PlayerPrefs.GetFloat(_soundKey);
        foreach (AudioSource soundSource in _soundSources) soundSource.volume = _soundSliders[0].value;




        if (!PlayerPrefs.HasKey(_musicKey)) PlayerPrefs.SetFloat(_musicKey, 0);

        foreach (Slider slider in _musicSliders) slider.value = PlayerPrefs.GetFloat(_musicKey);
        foreach (AudioSource musicSource in _musicSources) musicSource.volume = _musicSliders[0].value;
    }

    public void PlaySound(int index)
    {
        _soundSources[index].Play();
    }


    public void ChangeSoundVolume(Slider choosenSlider)
    {
        PlayerPrefs.SetFloat(_soundKey, choosenSlider.value);

        foreach (Slider slider in _soundSliders) slider.value = PlayerPrefs.GetFloat(_soundKey);
        foreach (AudioSource soundSource in _soundSources) soundSource.volume = choosenSlider.value;
    }
    public void ChangeMusicVolume(Slider choosenSlider)
    {
        PlayerPrefs.SetFloat(_musicKey, choosenSlider.value);

        foreach (Slider slider in _musicSliders) slider.value = PlayerPrefs.GetFloat(_musicKey);
        foreach (AudioSource musicSource in _musicSources) musicSource.volume = choosenSlider.value;
    }
}
