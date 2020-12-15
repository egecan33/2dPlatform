using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menü : MonoBehaviour
{
    public AudioSource AudioSource;
    public void LoadGame()
    {
        Application.LoadLevel("SampleScene");
    }
    private void FixedUpdate()
    {
        
    }
    public void Sound(int asdas)
    {
        AudioSource.volume = asdas;
    }
}
