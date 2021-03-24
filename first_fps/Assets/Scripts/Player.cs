using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform transform_;
    CharacterController ch_controller_;
    float move_speed_ = 10.0f;
    public int life = 5;
    Transform camera_transform_;
    Vector3 cam_rot_;
    public float cam_rot_speed_ = 3.0f;
    float camera_height_ = 1.4f;

    // Start is called before the first frame update
    void Start()
    {
        camera_transform_ = Camera.main.transform;
        transform_ = transform;
        ch_controller_ = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        cam_rot_ = camera_transform_.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
            return;
        Control();
    }


    void Control() {
        float mx = 0f, my = 0f;
        mx += Input.GetAxis("Mouse X");
        my += Input.GetAxis("Mouse Y");

        cam_rot_.x -= my;
        cam_rot_.y += mx;
        camera_transform_.eulerAngles = cam_rot_;

        transform_.eulerAngles = camera_transform_.eulerAngles;

        float xm = 0f, ym = 0f, zm = 0f;
        if (Input.GetKey(KeyCode.W)) {
            zm += move_speed_ * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            xm -= move_speed_ * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            zm -= move_speed_ * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            xm += move_speed_ * Time.deltaTime;
        }
        ch_controller_.Move(transform_.TransformDirection(new Vector3(xm, ym, zm)));

        camera_transform_.position = transform_.TransformPoint(new Vector3(0, camera_height_, 0));
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(this.transform.position, "Spawn.tif");
    }
}
