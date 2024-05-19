using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 3.0f;

    private float rotacionX = 0.0f;

    void Update()
    {
        // Obtener la entrada de teclado para el movimiento
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Calcular el desplazamiento en la dirección del movimiento
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical) * velocidadMovimiento * Time.deltaTime;

        // Aplicar el desplazamiento a la posición de la cámara
        transform.Translate(movimiento);

        // Obtener la entrada del mouse para la rotación
        float rotacionY = Input.GetAxis("Mouse X") * velocidadRotacion;

        // Aplicar la rotación horizontal al objeto (cámara)
        transform.Rotate(0, rotacionY, 0);

        // Obtener la entrada del mouse para la rotación vertical
        float rotacionVertical = -Input.GetAxis("Mouse Y") * velocidadRotacion;

        // Aplicar la rotación vertical a la cámara sin permitir exceso de rotación
        rotacionX += rotacionVertical;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f);

        // Aplicar la rotación vertical a la cámara
        transform.localRotation = Quaternion.Euler(rotacionX, transform.localRotation.eulerAngles.y, 0);
    }
}