using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip main;
    public AudioClip boss;
    public GameObject spawnzone;

    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;
        audio.clip = main;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        var wave = spawnzone.GetComponent<SpawnZone>().CheckWave();
        switch (wave)
        {
            case 5:
            case 10:
                audio.clip = boss;
                audio.Play();
                break;
            case 6:
                audio.clip = main;
                audio.Play();
                break;
        }
    }
}
