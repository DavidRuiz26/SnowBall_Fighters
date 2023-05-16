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

    private void Start()
    {
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
            corazon3.SetActive(false);
            Debug.Log("Te quedan dos vidas");

        }
        else if (vidas == 1)
        {
            corazon2.SetActive(false);
            Debug.Log("Te queda una vida");

        }
        else if (vidas == 0)
        {
            corazon1.SetActive(false);
            Debug.Log("HAS PERDIDO");
            PerderJuego();
        }
    }

    private void PerderJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

