using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UXF;

public class CameraPositioning : MonoBehaviour
{

    public Vector3 a_top_left_xz; // grab the xy(qualisys)/xz(unity) points from each corner of the projector, using qualisys
    public Vector3 b_top_right_xz;
    public Vector3 c_bottom_right_xz;
    public Vector3 d_bottom_left_xz;

    void Start()
    {
        Camera this_camera = gameObject.GetComponent<Camera>();

        Debug.Log("Camera Position:" + gameObject.transform.position);

        float a_b_length = Vector3.Distance(a_top_left_xz,b_top_right_xz);

        float this_camera_FOV = this_camera.fieldOfView;

        float this_camera_FOV_horizontal = Camera.VerticalToHorizontalFieldOfView(this_camera_FOV,this_camera.aspect);

        Debug.Log("camera FOV Horizontal: " + this_camera_FOV_horizontal);

        float camera_height_denominator = Mathf.Tan(7.5f * (Mathf.PI/180f)); 

        Debug.Log(camera_height_denominator);
        
        float camera_height_numerator = a_b_length/2f;


        float camera_x_pos = (a_top_left_xz[0] + b_top_right_xz[0] + c_bottom_right_xz[0] + d_bottom_left_xz[0]) / 4f;

        float camera_z_pos = (a_top_left_xz[2] + b_top_right_xz[2] + c_bottom_right_xz[2] + d_bottom_left_xz[2]) / 4f;

        float camera_y_pos = camera_height_numerator/camera_height_denominator;

        // Convert from CM to M

        float camera_x_pos_meters = camera_x_pos/1000;

        float camera_y_pos_meters = camera_y_pos/1000;

        float camera_z_pos_meters = camera_z_pos/1000;

        gameObject.transform.position = new Vector3(camera_x_pos_meters, camera_y_pos_meters, camera_z_pos_meters);

        Debug.Log("NEW Camera Position:" + gameObject.transform.position);

    }
    


}
