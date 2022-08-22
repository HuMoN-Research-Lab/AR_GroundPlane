using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

using UXF;

public class LoadTerrain : MonoBehaviour
{

    //public Session session;
    public GameObject prefab_target;
    public bool is_mirrored;
    private string file_name;
    private TextAsset terrain_file;

    public void GenerateTerrain(Trial trial)
    {

        Debug.Log("Terrain is Loaded");
        Debug.Log("is_mirrored:" + is_mirrored);
        // get the positions of each of the projectors
        var Projector1_Pos_XYZ = GameObject.Find("CamProjector1").transform.position;
        var Projector2_Pos_XYZ = GameObject.Find("CamProjector2").transform.position;
        var Projector3_Pos_XYZ = GameObject.Find("CamProjector3").transform.position;

        // Get file name from the world
        if(is_mirrored)
        {
            file_name = trial.settings.GetString("Mirror");
            Debug.Log("is_mirrored = True");
        }
        else
        {
            file_name = trial.settings.GetString("File");
            Debug.Log("is_mirrored = False");
        }
        
        Debug.Log("Name of Trial File: " + file_name);

        TextAsset terrain_file = Resources.Load<TextAsset>(file_name); // feed in the file name without `.csv` appended to it

        Debug.Log("Terrain File Type:: " + terrain_file);

        // split up the data by line
        string[] terrain_info = terrain_file.text.Split(new char[] { '\n' });

        // Loop through the length of the list and create game objects
        // subtract 1 from length because Unity reads in an empty line at the end
        // start at i = 1 because we're giving our csv a header
        //Debug.Log(terrain_info.Length);
        for (int i = 1; i < terrain_info.Length -1; i++)
        {   
            // Split up terrain by commas to give us each column
            string[] col = terrain_info[i].Split(new char[] { ',' } );
        
            GameObject target = Instantiate(prefab_target);

            if(col[4] == "P1")
            {
                // add the x,z position of the appropriate camera to the position of the game object
                target.transform.position = new Vector3(float.Parse(col[0])+Projector1_Pos_XYZ[0],0,float.Parse(col[2])+Projector1_Pos_XYZ[2] );
            }

            if(col[4] == "P2")
            {
                // add the x,z position of the appropriate camera to the position of the game object
                target.transform.position = new Vector3(float.Parse(col[0])+Projector2_Pos_XYZ[0],0,float.Parse(col[2])+Projector2_Pos_XYZ[2] );
            }

            if(col[4] == "P3")
            {
                // add the x,z position of the appropriate camera to the position of the game object
                target.transform.position = new Vector3(float.Parse(col[0])+Projector3_Pos_XYZ[0],0,float.Parse(col[2])+Projector3_Pos_XYZ[2] );
            }

            Debug.Log("Tar Loc:" + target.transform.position.ToString("F4"));
        }
    }
}