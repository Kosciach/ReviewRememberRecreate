using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioSettings
{
    [Range(0, 1)]
    public float MusicVolume;
    [Range(0, 1)]
    public float SoundsVolume;
}
