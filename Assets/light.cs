using UnityEngine;
using System.Collections;

public class light : MonoBehaviour {
    public Light lt;
    float intense;
    float newIntense;
    public float batteryLife;
    public float count;
    bool lightOn;
	// Use this for initialization
	void Start () {
        intense = lt.intensity;
        newIntense = intense;
        lightOn = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (newIntense != 0)
        {
            batteryLife -= Time.deltaTime;
        }
        if (batteryLife <= 0 && newIntense !=0)
        {
            intense -= Time.deltaTime/count;
        }
        if (intense < 0)
        {
            intense = 0;
        }
        lt.intensity = newIntense;
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (lightOn)
            {
                case true:
                    lightOn = false;
                    break;
                case false:
                    lightOn = true;
                    break;
            }
        }
        switch (lightOn)
        {
            case true:
                newIntense = intense;
                break;
            case false:
                newIntense = 0;
                break;
        }
	}
}
