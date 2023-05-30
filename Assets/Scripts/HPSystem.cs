using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HPSystem : MonoBehaviour
{
    public int vidas = 3;
    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;

    public AudioClip bonk;
    public AudioClip death;

    private GameObject player;
    private AudioSource audio;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        audio = gameObject.GetComponent(typeof(AudioSource)) as AudioSource;
        audio.clip = bonk;
        corazon1.SetActive(true);
        corazon2.SetActive(true);
        corazon3.SetActive(true);
    }

    public void PerderVida()
    {
        vidas--;

        // Desactiva el objeto de corazón correspondiente a la vida perdida
        if (vidas == 2)
        {
            audio.Play();
            corazon3.SetActive(false);
            Debug.Log("Te quedan dos vidas");

        }
        else if (vidas == 1)
        {
            audio.Play();
            corazon2.SetActive(false);
            Debug.Log("Te queda una vida");

        }
        else if (vidas == 0)
        {
            audio.clip = death;
            corazon1.SetActive(false);
            Debug.Log("HAS PERDIDO");
            PerderJuego();
        }
    }

    private void PerderJuego()
    {
        player.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

