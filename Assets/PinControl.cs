using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PinControl : MonoBehaviour
{
    //Initial position for all pins
    private Vector3[] initialPositions;
    //reference for all pins in scene
    private GameObject[] pins;

    private List<GameObject> fallPins;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pins = new GameObject[transform.childCount];

        initialPositions = new Vector3[transform.childCount];

        fallPins = new List<GameObject>();

        for (int i = 0; i < transform.childCount; i++)
        {
            pins[i] = transform.GetChild(i).gameObject;
            initialPositions[i] = transform.GetChild(i).position;
        }
        
    }

    public void AddFallPin(GameObject pin)
    {
        if (!fallPins.Contains(pin))
        {
            fallPins.Add(pin);
        }
    }

    public int GetScore()
    {
        return fallPins.Count;
    }

    public void ResetPinPositions()
    {
        fallPins.Clear();

        for (int i = 0; i < pins.Length; i++)
        {
            pins[i].transform.position = initialPositions[i];
            pins[i].transform.rotation = Quaternion.identity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            ResetPinPositions();
        }
    }
}
