using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControllerExtender : MonoBehaviour
{
    public void ChangeMusicVolume(Slider choosenSlider)
    {
        AudioController.Instance.ChangeMusicVolume(choosenSlider);
    }
    public void ChangeSoundVolume(Slider choosenSlider)
    {
        AudioController.Instance.ChangeSoundVolume(choosenSlider);
    }
    public void PlayButtonSound()
    {
        AudioController.Instance.PlayButtonSound();
    }
}
