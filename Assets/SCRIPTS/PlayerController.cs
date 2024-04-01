using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public EnemyAI EnemyAI;
    
    public Camera MainCamera;

    public Image[] wASD;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 5 * Time.deltaTime);
            wASD[0].color = Color.blue;
        }
        else wASD[0].color = Color.white;

        if (Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5 * Time.deltaTime);
            wASD[1].color = Color.blue;
        }
        else wASD[1].color = Color.white;

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + 5 * Time.deltaTime, transform.position.y, transform.position.z);
            wASD[2].color = Color.blue;
        }
        else wASD[2].color = Color.white;

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = new Vector3(transform.position.x - 5 * Time.deltaTime, transform.position.y, transform.position.z);
            wASD[3].color = Color.blue;
        }
        else wASD[3].color = Color.white;


        if (Input.GetKey(KeyCode.Keypad8))
        {
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z + 5 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x, MainCamera.transform.position.y, MainCamera.transform.position.z - 5 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Keypad6))
        {
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x + 5 * Time.deltaTime, MainCamera.transform.position.y, MainCamera.transform.position.z);
        }
        if (Input.GetKey(KeyCode.Keypad4))
        {
            MainCamera.transform.position = new Vector3(MainCamera.transform.position.x - 5 * Time.deltaTime, MainCamera.transform.position.y, MainCamera.transform.position.z);
        }
    }
}
