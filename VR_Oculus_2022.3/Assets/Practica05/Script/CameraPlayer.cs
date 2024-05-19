using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad de movimiento del jugador
    public float sensitivity = 2.0f; // Sensibilidad del ratón para mover la cámara
    public float gravity = 20.0f; // Gravedad aplicada al jugador

    private CharacterController characterController;
    private Camera playerCamera;
    private float rotX;
    private float rotY;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>();
        Cursor.lockState = CursorLockMode.Locked; // Bloquea el cursor al centro de la pantalla
    }

    void Update()
    {
        // Obtener la entrada del teclado y el ratón
        float moveFB = Input.GetAxis("Vertical") * speed;
        float moveLR = Input.GetAxis("Horizontal") * speed;
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, -90f, 90f); // Limita el ángulo de rotación en Y

        // Rotar la cámara verticalmente
        playerCamera.transform.localRotation = Quaternion.Euler(rotY, 0, 0);

        // Mover al jugador en la dirección deseada
        moveDirection = (transform.forward * moveFB + transform.right * moveLR).normalized;
        moveDirection *= speed;

        // Aplicar la gravedad
        moveDirection.y -= gravity * Time.deltaTime;

        // Aplicar movimiento al jugador
        characterController.Move(moveDirection * Time.deltaTime);
        transform.Rotate(Vector3.up * rotX * Time.deltaTime);
    }
}