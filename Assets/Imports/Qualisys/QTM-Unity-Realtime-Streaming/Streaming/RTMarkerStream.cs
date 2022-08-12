// Unity SDK for Qualisys Track Manager. Copyright 2015-2018 Qualisys AB
//
using UnityEngine;
using System.Collections.Generic;

namespace QualisysRealTime.Unity
{
    public class RTMarkerStream : MonoBehaviour
    {
        private List<LabeledMarker> markerData;
        private RTClient rtClient;
        private GameObject markerRoot;
        private List<GameObject> markers;

        public bool visibleMarkers = true;

        [Range(0.001f, 1f)]
        public float markerScale = 0.05f;

        private bool streaming = false;

        private Vector3 WorldCenter = new Vector3(0, 0, 0); // set the world position

        // Use this for initialization
        void Start()
        {
            rtClient = RTClient.GetInstance();
            markers = new List<GameObject>();
            markerRoot = gameObject;
        }


        private void InitiateMarkers()
        {
            foreach (var marker in markers)
            {
                Destroy(marker);
            }

            markers.Clear();
            markerData = rtClient.Markers;

            for (int i = 0; i < markerData.Count; i++)
            {
                GameObject newMarker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                newMarker.name = markerData[i].Name;
                newMarker.transform.parent = markerRoot.transform;
                newMarker.transform.localScale = Vector3.one * markerScale;
                newMarker.SetActive(false);
                // TDW added code from here to... 3/17/2022
                newMarker.AddComponent<Rigidbody>();
                newMarker.GetComponent<Rigidbody>().useGravity = false;
                newMarker.AddComponent<CapsuleCollider>(); 
                newMarker.GetComponent<CapsuleCollider>().isTrigger = true;
                // here
                markers.Add(newMarker);
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (rtClient == null) rtClient = RTClient.GetInstance();
            if (rtClient.GetStreamingStatus() && !streaming)
            {
                InitiateMarkers();
                streaming = true;
            }
            if (!rtClient.GetStreamingStatus() && streaming)
            {
                streaming = false;
                InitiateMarkers();
            }

            markerData = rtClient.Markers;

            if (markerData == null || markerData.Count == 0)
                return;

            if (markers.Count != markerData.Count)
            {
                InitiateMarkers();
            }

            for (int i = 0; i < markerData.Count; i++)
            {
                if (!float.IsNaN(markerData[i].Position.sqrMagnitude))
                {
                    markers[i].name = markerData[i].Name;
                    markers[i].GetComponent<Renderer>().material.color = markerData[i].Color;
                    markers[i].transform.localPosition = markerData[i].Position;
                    markers[i].SetActive(true);
                    markers[i].GetComponent<Renderer>().enabled = visibleMarkers;
                    markers[i].transform.localScale = Vector3.one * markerScale;
                    // added code below :: Rotate around the y-axis TDW 2022-03-14
                    markers[i].transform.RotateAround(WorldCenter, Vector3.up, 180);
                }
                else
                {
                    // Hide markers if we cant find them
                    markers[i].SetActive(false);
                }
            }
        }
    }
}