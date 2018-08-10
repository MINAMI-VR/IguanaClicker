using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class IguanaClicker : MonoBehaviour {
    private const string INPUT_IGUANA = "iguana";
    public GameObject model;
    string[] arr = new string[6];
    float point = 0;
    public Text text;
    float AutoClickSpeed = 0;
    float[] AutoClickeker = new float[10];
	// Use this for initialization
	void Start () {

	}

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            for (int i = 4; i >= 0; i--)
            {
                arr[i + 1] = arr[i];
            }
            if (Input.GetKeyDown(KeyCode.I)) arr[0] = "i";
            else if (Input.GetKeyDown(KeyCode.G)) arr[0] = "g";
            else if (Input.GetKeyDown(KeyCode.U)) arr[0] = "u";
            else if (Input.GetKeyDown(KeyCode.A)) arr[0] = "a";
            else if (Input.GetKeyDown(KeyCode.N)) arr[0] = "n";
            else for (int j = 0; j < 6; j++) arr[j] = "";
        }

        string str = "";
        for (int i = 5; i >= 0; i--) str += arr[i];
        
        if (str == INPUT_IGUANA){
            DropObject();
            point += 10f;
            for (var i = 0; i < 6; i++) arr[i] = "";
        }

        if (Input.GetMouseButtonDown(0))
        {
            DropObject();
            point++;
        }

        AutoClickSpeed = 0;
        for (int i = 0; i < 10; i++)
        {
            AutoClickSpeed += (float)Math.Pow(10, i + 1) * AutoClickeker[i];
        }

        point += AutoClickSpeed * Time.deltaTime;
        text.text = ((int)point).ToString() + "\tIguanas\n" + ((int)AutoClickSpeed).ToString() + "\tIpS"; //"IpS" means "Iguana per Second"
    }

    void DropObject()
    {
        System.Random r = new System.Random();
        float rad = 3f * (float)r.NextDouble();
        float theta = 2f * (float)(Math.PI * r.NextDouble());
        float x = (float)(rad * Math.Cos(theta));
        float z = (float)(rad * Math.Sin(theta));
        GameObject iguana = Instantiate(model) as GameObject;
        iguana.transform.position = new Vector3(x, 3, z);
        Destroy(iguana, 1f);
    }

    void OnGUI()
    {
        for (int i = 0; i < 10; i++)
        {
            float Payment = (float)Math.Pow(100, i + 1);
            if (GUI.Button(new Rect(1000, 30 * i + 10, 200, 30), AutoClickeker[i] + "\tAutoClicker " + i.ToString()) && point >= Payment)
            {
                point -= Payment;
                AutoClickeker[i] += 1;
            }
        }
    }
}
