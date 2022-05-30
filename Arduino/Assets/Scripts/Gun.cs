using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public SerialPort serialPort = new SerialPort("COM3", 9600);
    public float sumitaErrorY;

    void Start()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (serialPort.IsOpen) //comprobamos que el puerto esta abierto
        {
            try //utilizamos el bloque try/catch para detectar una posible excepción.
            {
                string ax = ""; float x = 0f;
                string ay = ""; float y = 0f;

                string value = serialPort.ReadLine(); //leemos una linea del puerto serie y la almacenamos en un string
                string[] vec6 = value.Split(',');
                //leemos el eje X
                for (int i = 0; i < vec6[0].Length; i++)
                {
                    if (vec6[0].Substring(i, 1) != ".")
                        ax = ax + vec6[0].Substring(i, 1);
                    else
                    { x = float.Parse(ax); ax = "0,"; }
                }
                //leemos el eje Y
                for (int i = 0; i < vec6[1].Length; i++)
                {
                    if (vec6[1].Substring(i, 1) != ".")
                        ay = ay + vec6[1].Substring(i, 1);
                    else
                    { y = float.Parse(ay); ay = "0,"; }
                }

                transform.rotation = Quaternion.Euler(-(-1) * x, (-1) * y + sumitaErrorY,0 );

                if (vec6[2] == "1")
                {
                    Debug.Log("Disparo");    
                }
                

            }
            catch
            { }
        }
    }
}
