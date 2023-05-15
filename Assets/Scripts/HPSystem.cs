using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HPSystem : MonoBehaviour
{
    public int vidas = 3;
    public GameObject corazon1;
    public GameObject corazon2;
    public GameObject corazon3;

    private void Start()
    {
        corazon1 = GameObject.Find("Hearth1");
        corazon2 = GameObject.Find("Hearth2");
        corazon3 = GameObject.Find("Hearth3");

        corazon1.SetActive(true);
        corazon2.SetActive(true);
        corazon3.SetActive(true);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BolaMalosa"))
        {
            perderVida();
        }
    }

    private void perderVida()
    {
        vidas--;

        // Desactiva el objeto de corazón correspondiente a la vida perdida
        if (vidas == 2)
        {
            corazon3.SetActive(false);
        }
        else if (vidas == 1)
        {
            corazon2.SetActive(false);
        }
        else if (vidas == 0)
        {
            corazon1.SetActive(false);
            perderJuego();
        }
    }

    private void perderJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

