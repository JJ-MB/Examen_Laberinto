using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boton : MonoBehaviour
{
    public string nombreEscenaACargar; // El nombre de la escena a la que deseas cambiar

    // Función que se llamará para cambiar de escena
    public void CargarEscena()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(nombreEscenaACargar);
    }

}










/*
{
public string nombreEscenaACargar; // El nombre de la escena a la que deseas cambiar

void Update()
{
    // Verifica si el botón del gatillo derecho del controlador Oculus Quest es presionado en este frame
    if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
    {
        // Llama a la función CargarEscena cuando el botón del gatillo es seleccionado
        CargarEscena();
    }
}

// Función que se llamará para cambiar de escena
void CargarEscena()
{
    // Cambia a la escena especificada
    SceneManager.LoadScene(nombreEscenaACargar);
}
}
*/