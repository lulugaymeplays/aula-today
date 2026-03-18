using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Cube : MonoBehaviour
{
    public Color[] cores;
    public float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        if (cores.Length == 0)
        {
            Debug.LogWarning("Crie uma ou mais cores na lista.");

            return;
        }

        Color c = cores[Random.Range(0, cores.Length - 1)];

        GetComponent<Renderer>().material.color = c;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("up") || Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
    }
}
