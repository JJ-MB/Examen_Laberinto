using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userWeapon : MonoBehaviour
{

    private CharacterController userCharacter;
    public Vector3 userDirection;
    public float userSpeed;
    private Transform cameraTransform;

    //Para interacción del usuario
    public Transform bulletStart;
    public GameObject bullet;
    public float bulletForce;

    // Start is called before the first frame update
    void Start()
    {
        userCharacter = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //para el movimiento
        Vector2 userControl = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        float cameraRotation = cameraTransform.eulerAngles.y;
        Vector3 camerarotation = Quaternion.Euler(new Vector3(0, 90, 0)) * cameraTransform.forward;
        userDirection = (camerarotation * Input.GetAxis("Horizontal") + cameraTransform.forward * Input.GetAxis("Vertical")).normalized;
        //
        userCharacter.Move(userDirection * Time.deltaTime * userSpeed);

        if (OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger) || Input.GetMouseButtonDown(1) )
        {
            GameObject newBullet = Instantiate(bullet, bulletStart.transform.position, bulletStart.rotation);
            Rigidbody bulletforce = newBullet.GetComponent<Rigidbody>();
            //bulletforce.AddForce(bulletStart.forward * Time.deltaTime * bulletForce, ForceMode.Impulse);
            bulletforce.AddForce(-bulletStart.right * Time.deltaTime * bulletForce, ForceMode.Impulse);
        }
    }
}
