using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    public AudioSource musicSource;

    private Slider mVolumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        mVolumeSlider = GetComponent<Slider>();
        musicSource.volume = mVolumeSlider.value;
        mVolumeSlider.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ValueChangeCheck()
    {
        musicSource.volume = mVolumeSlider.value;
    }
}
