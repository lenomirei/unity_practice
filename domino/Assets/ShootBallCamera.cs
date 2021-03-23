using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBallCamera : MonoBehaviour
{
    Transform main_camera_;
    float camera_speed_;
    Vector3 camera_rot_;
    public GameObject sphere_;
    public float shoot_speed_ = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        main_camera_ = Camera.main.transform;
        camera_speed_ = 10.0f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.W)) {
            pos.z += camera_speed_ * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            pos.z -= camera_speed_ * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            pos.x -= camera_speed_ * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            pos.x += camera_speed_ * Time.deltaTime;
        }
        if (Input.GetMouseButtonDown(0)) {
            ShootSphere();
        }

        main_camera_.Translate(pos);

        float rh = Input.GetAxis("Mouse X");
        float rv = Input.GetAxis("Mouse Y");

        camera_rot_ = main_camera_.eulerAngles;
        camera_rot_.x -= rv;
        camera_rot_.y += rh;
        main_camera_.eulerAngles = camera_rot_;
    }

    void ShootSphere() {
        Vector3 cam_pos = main_camera_.transform.localPosition;
        Vector3 camera_forward = main_camera_.transform.forward;
        GameObject sphere = GameObject.Instantiate(sphere_, cam_pos, main_camera_.transform.rotation);
        sphere.GetComponent<Rigidbody>().AddForce(camera_forward * shoot_speed_, ForceMode.Acceleration);
    }
}
