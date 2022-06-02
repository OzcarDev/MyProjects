using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Gun : MonoBehaviour
{
    public SerialPort serialPort = new SerialPort("COM3", 9600);

    public float sensibility;
    public float margenX;
    public float margenY;
    public Collider2D col;
    public float shotDelay;
    bool canShot;
    public AudioSource shotSound;
   

    void Start()
    {
        canShot = true;
        serialPort.Open();
        serialPort.ReadTimeout = 100;
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string[] input = serialPort.ReadLine().Split(',');
                float x = float.Parse(input[1]) - margenX;
                float y = float.Parse(input[0]) - margenY;

                transform.position = new Vector3(-x * sensibility, -y * sensibility, 0);
                Debug.Log(transform.position);

                if (input[2] == "1"&&canShot)
                {
                    StartCoroutine(SecuenciaDisparo());
                    
                }
            }
            catch { }
        }
    }

   
       
       
    

    IEnumerator SecuenciaDisparo()
    {

        canShot = false;
        col.enabled = true;
        shotSound.Play();
        yield return new WaitForSeconds(shotDelay);
        col.enabled = false;
        canShot = true;
    }
}
