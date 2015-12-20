using UnityEngine;
using System.Collections;

public class NewBehaviourScript1 : MonoBehaviour {
    public float turnSpeed;
    public float speed;
    public float friction;
    Rigidbody rb = new Rigidbody();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        //rb.AddForce(new Vector3(x, 0, y));
        this.transform.Rotate(new Vector3(x, y, 0));
        if (Input.GetKey(KeyCode.W)) { rb.AddForce(new Vector3(x,0,y)); }
	}
}
