using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


public class Shooting : MonoBehaviour
{

    // Pythonスクリプトのパス
    string myPythonApp = "live.py";

    // bullet prefab
    public GameObject bullet;

    // 弾丸発射点
    public Transform muzzle;

    // 弾丸の速度
    public float speed = 1000;

    // Use this for initialization
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        var myProcess = new Process
        {
            StartInfo = new ProcessStartInfo("python.exe")
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                Arguments = myPythonApp
            }
        };
        myProcess.Start();
        StreamReader myStreamReader = myProcess.StandardOutput;

        while (myStreamReader.Peek() > 0)
        {
            string myString = myStreamReader.ReadLine();
            //MessageBox.Show(myString);
            if (myString == "ip")
            {

                // 弾丸の複製
                GameObject bullets = Instantiate(bullet) as GameObject;

                Vector3 force;

                force = this.gameObject.transform.forward * speed;

                // Rigidbodyに力を加えて発射
                bullets.GetComponent<Rigidbody>().AddForce(force);

                // 弾丸の位置を調整
                bullets.transform.position = muzzle.position;
            }

        myProcess.Close();
        
        }

    }
}