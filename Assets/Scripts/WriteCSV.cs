using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;


public class WriteCSV : MonoBehaviour
{
    public String file_path;

    private String file_path_with_file_name;

    private String object_position_string;

    public void WriteTerrainObjectsOnTrialStart(String terrain_dict_file_name, Dictionary<int,string> terrain_objects_dict)
    {
       
        file_path_with_file_name = String.Format(file_path + "\\" + terrain_dict_file_name + ".csv");

        try
        {
                        
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@file_path_with_file_name, true))
            {
                Debug.LogWarning("Files are about to be saved, make sure that you're working in a clean & new folder!!!");

                file.WriteLine("X, Y, Z");

                foreach(var item in terrain_objects_dict)
                {
                    // Find out how long the string is and then keep the substring between the "(" ")"

                    object_position_string = item.Value;

                    int string_length = object_position_string.Length - 2;

                    object_position_string = object_position_string.Substring(1, string_length);

                    file.WriteLine(object_position_string);
                }

                Debug.Log("Inside of WriteCSV! Files being saved here : " + file_path);
            }   
        }   
        catch(Exception ex)
        {
            throw new ApplicationException("Write CSV is broken!:", ex);
        }

    }

}
