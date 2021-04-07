using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject SliderSound;
    bool open = false;
    bool close = true;
    AudioSource AudioSource;
    public Slider Slider;
    
    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();
        SliderSound.GetComponent<Slider>().value= 0.50f;
        SliderSound.SetActive(false);
        AudioSource.volume = SliderSound.GetComponent<Slider>().value;

    }
    private void FixedUpdate()
    {
        MenuSound();
    }
    public void MenuSound()
    {
        AudioSource.volume = SliderSound.GetComponent<Slider>().value;
    }
    public void LoadGame()
    {
        Application.LoadLevel("SampleScene");
    }
    public void SoundOpen()
    {
        bool flag=false;
        if (close)
        {
            close = false;
            open = true;
            flag = true;
            SliderSound.SetActive(true);
        }
        if (open && !flag)
        {
            open = false;
            close = true;
            SliderSound.SetActive(false);
        }
        
    }

}
