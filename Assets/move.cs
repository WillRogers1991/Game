using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
    public GameObject cam;
    Rigidbody rb;
    public float friction;
    public float speed;
    public float grav;
    public float rotateSpeed;
    float mousex;
    float starty;
    Vector3 velocity;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -grav, 0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        starty = this.transform.position.y;
    }

    // Update is called once per frame
    void Update() {
        //float t = Time.deltaTime;
        //if (Input.GetKey("up")) { velocity += (transform.forward * speed) / 5; }
        //if (Input.GetKey("down")) { velocity += (-transform.forward * speed) / 5; }
        velocity = Input.GetAxis("Vertical") * transform.forward * speed;
        velocity = Input.GetAxis("Horizontal") * transform.right * speed;
        velocity /= friction;
        //if (Input.GetKey("left")) { this.transform.Rotate(new Vector3(0, -rotateSpeed, 0)); }
        //if (Input.GetKey("right")) { this.transform.Rotate(new Vector3(0, rotateSpeed, 0)); }
        //velocity = new Vector3(Mathf.Pow(Mathf.Sin(this.transform.eulerAngles.y),2)*Input.GetAxisRaw("Vertical"), 0, Mathf.Pow(Mathf.Cos(this.transform.eulerAngles.y),2)*Input.GetAxisRaw("Vertical")).normalized * speed;

        this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y);
        mousex = Input.GetAxis("Mouse X") * rotateSpeed;
        
        //float mousey = Input.GetAxis("Mouse Y")*rotateSpeed;
        this.transform.Rotate(new Vector3(0,mousex,0));
        cam.transform.Rotate(new Vector3(0, mousex, 0));
        if (Input.GetKeyDown(KeyCode.E))
        {
            switch (Cursor.lockState)
            {
                case CursorLockMode.Locked:
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;
                case CursorLockMode.None:
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    break;
            }
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        this.transform.position += velocity*Time.fixedDeltaTime;
        this.transform.position = new Vector3(this.transform.position.x, starty, this.transform.position.z);
    }
    void LateUpdate()
    {
        cam.transform.position = transform.position;
        //cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, this.transform.eulerAngles.y, 0);
    }
}
