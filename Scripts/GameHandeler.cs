using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHandeler : MonoBehaviour
{
    [SerializeReference]
    public AudioSource[] AudioSource;
    GameObject[] Goblins;
    public GameObject[] puppets;

    public int goblinsNumber;
    public GameObject Goblin;
    public GameObject puppet;

    public GameObject bloc1;


    bool death;

    public PlayerHealt PlayerHealt;
    public HealBar HealBar;
    public GameObject Player;
    public Text Text;
    private void Awake()
    {
        HealBar.SetMaxValue(PlayerHealt.healt);
        Goblins = new GameObject[goblinsNumber];
    }
    void FixedUpdate()
    {
        foreach (var item in AudioSource)
        {
            item.volume = 0.5f;
        }
        Text.text = PlayerHealt.healt.ToString();
        HealBar.SetHealth(PlayerHealt.healt);
        if (bloc1.active)
        {
            Spawn();
        }
        IsDeath();
    }
    void IsDeath()
    {
    }
    void Spawn()
    {
        for (int i = 0; i < Goblins.Length; i++)
        {
            Goblins[i] = Instantiate(Goblin, new Vector2(232, -15), Quaternion.identity);
        }
    }
}
