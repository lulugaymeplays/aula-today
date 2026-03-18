using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [Header("Movimentacao")]
    public float moveSpeed = 5f;

    [Header("Mouse")]
    public float mouseSensitivity = 2f;
    public float verticalClamp = 60f;

    [Header("Referencias")]
    public Transform cameraContainer;
    public Transform gunContainer;

    [Header("Tiro")]
    public GameObject bulletPrefab;
    public Transform muzzle;

    private float verticalRotation = 0f;



    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity; //"PEGA" O MOVIMENTO HORIZONTAL DO MOUSE
        transform.Rotate(0f, mouseX, 0f);

        //--- Rotação vertical da Camera (eixo X local ) --- 
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity; //"PEGA" O MOVIMENTO VERTICAL DO MOUSE 
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalClamp, verticalClamp); //TRAVA O MOVIMENTO PARA CIMA E PARA BAIXO 60º
        cameraContainer.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        gunContainer.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        //--- Movimento WASD / Setas ---
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * h + transform.forward * v;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // --- Tiro ---
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, muzzle.position, muzzle.rotation);
            
        }

    }
}
