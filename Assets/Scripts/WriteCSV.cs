using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UXF;

public class WriteCSV : MonoBehaviour
{
    
    // private String object_position_string;

    public FileSaver fileSaver;

    public void WriteTerrainObjectsOnTrialStart(String terrain_dict_file_name, Dictionary<int,string> terrain_objects_dict)
    {
       
        string sessionPath = fileSaver.GetSessionPath(Session.instance);

        string sessionPathWithTerrainFolder = String.Format(sessionPath + "\\" + "ar_terrain_data");

        // Create the folder so we can save the data -> this doesn't seem to break any other UXF processes
        var folder = Directory.CreateDirectory(sessionPathWithTerrainFolder); 

        string file_path_with_file_name = String.Format(sessionPathWithTerrainFolder + "\\" + terrain_dict_file_name + ".csv");

        System.DateTime epochStart = new System.DateTime(1970, 1, 1, 0, 0, 0, System.DateTimeKind.Utc);

        try
        {
            // for later: if there are no targets collided with, save an empty file

            // save start end box positions - can I save the start/end boxes as text files? -> don't lose time over this though

            // save intelligent timestamp data

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@file_path_with_file_name, true)) 
            {

                file.WriteLine("epoch_time_stamp, X, Y, Z");

                foreach(var item in terrain_objects_dict)
                {
                    // Find out how long the string is and then keep the substring between the "(" ")"

                    string object_position_string = item.Value;

                    int string_length = object_position_string.Length - 2;

                    object_position_string = object_position_string.Substring(1, string_length);

                    int cur_time = (int)(System.DateTime.UtcNow - epochStart).TotalSeconds;

                    string string_to_write = String.Format(cur_time.ToString() + ',' + object_position_string);

                    file.WriteLine(string_to_write);
                }

                Debug.Log("Inside of WriteCSV! Files being saved here : " + sessionPathWithTerrainFolder);
            }   
        }   
        catch(Exception ex)
        {
            throw new ApplicationException("WriteCSV is broken!:", ex);
        }

    }

}
