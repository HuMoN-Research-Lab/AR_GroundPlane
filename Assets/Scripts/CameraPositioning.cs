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

    public void CalculateCameraPosition()
    {
        Camera this_camera = gameObject.GetComponent<Camera>();

        float a_b_length = Vector3.Distance(a_top_left_xz,b_top_right_xz);


        float this_camera_FOV = this_camera.fieldOfView;

        float camera_height_denominator = Mathf.Tan(this_camera_FOV)/2f; 

        float camera_height_numerator = a_b_length/2f;


        float camera_x_pos = (a_top_left_xz[0] + b_top_right_xz[0] + c_bottom_right_xz[0] + d_bottom_left_xz[0]) / 4f;

        float camera_z_pos = (a_top_left_xz[2] + b_top_right_xz[2] + c_bottom_right_xz[2] + d_bottom_left_xz[2]) / 4f;

        float camera_y_pos = camera_height_numerator/camera_height_denominator;

        gameObject.transform.position = new Vector3(camera_x_pos, camera_y_pos, camera_z_pos);

    }
    


}
