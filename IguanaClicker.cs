using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class IguanaTyper : MonoBehaviour {
    private const string INPUT_IGUANA = "iguana";
    public GameObject model;
    string[] arr = new string[6];
    public int point = 0;
    public Text text;
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
            point += 10;
            for (var i = 0; i < 6; i++) arr[i] = "";
            text.text = point.ToString();
        }

        if (Input.GetMouseButtonDown(0))
        {
            DropObject();
            point++;
            text.text = point.ToString();
        }
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
}
