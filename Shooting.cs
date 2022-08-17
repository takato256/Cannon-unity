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

    // Python�X�N���v�g�̃p�X
    string myPythonApp = "live.py";

    // bullet prefab
    public GameObject bullet;

    // �e�۔��˓_
    public Transform muzzle;

    // �e�ۂ̑��x
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

                // �e�ۂ̕���
                GameObject bullets = Instantiate(bullet) as GameObject;

                Vector3 force;

                force = this.gameObject.transform.forward * speed;

                // Rigidbody�ɗ͂������Ĕ���
                bullets.GetComponent<Rigidbody>().AddForce(force);

                // �e�ۂ̈ʒu�𒲐�
                bullets.transform.position = muzzle.position;
            }

        myProcess.Close();
        
        }

    }
}