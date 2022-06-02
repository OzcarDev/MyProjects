using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public SerialPort serialPort = new SerialPort("COM3", 9600);
    
    public RectTransform position;
    public float sensibility;
    public int margenX;
    public int margenY;
    public GameObject bullet;
    public Transform shootPoint;
    public float bulletSpeed;
    public float shootRate;
    private float shootRateTime=0;
        
    void Start()
    {
        serialPort.Open();
        serialPort.ReadTimeout = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string[] input = serialPort.ReadLine().Split(',');
                float x = float.Parse(input[1])-margenX;
                float y = float.Parse(input[0])-margenY;

                position.localPosition = new Vector3(-x*sensibility, -y*sensibility, 0);

                if (input[2] == "1") Disparar();
            }
            catch {}
        }


        


    }

    void Disparar()
    {
        if (Time.time > shootRateTime)
        {
            GameObject actualGameObject; 
            actualGameObject= Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            actualGameObject.GetComponent<Rigidbody>().AddForce(shootPoint.forward*bulletSpeed);
            shootRateTime = Time.time + shootRate;
            Destroy(actualGameObject, 2);
        }
    }
}
