using Oculus.Platform.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Salida : MonoBehaviour
{
    public string nombreEscenaACargar; // El nombre de la escena a la que deseas cambiar
    public bool UserDetect;

    // M�todo que se llama cuando ocurre una colisi�n
    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que colision� tiene el tag "Player" (para asegurarnos de que sea el jugador)
        if (other.CompareTag("PlayerPunch"))
        {
            UserDetect = true;
        }
    }

    void Update()
    {

        if (UserDetect)
        {
            // Verifica si el bot�n de gatillo est� presionado en el controlador de Oculus
            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || Input.GetMouseButtonDown(1))
            {
                // Cambia a la escena especificada
                SceneManager.LoadScene(nombreEscenaACargar);
                PlayerPrefs.SetInt("Game", 1);
                PlayerPrefs.Save();
            }
        }
    }
}