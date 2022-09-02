using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Transform cofeeRoot;
    List<Transform> cofees;
    public List<Vector3> cofeeDefaultPositions;
    // Start is called before the first frame update
    public void Start()
    {
        FindCoffees();
        
    }
    
    private void FindCoffees()
    {
        cofees = new List<Transform>();
        cofeeDefaultPositions = new List<Vector3>();
        for (int i = 0; i < cofeeRoot.transform.childCount; i++)
        {
            cofees.Add(cofeeRoot.GetChild(i).transform);
            cofeeDefaultPositions.Add(cofeeRoot.GetChild(i).transform.position);
        }
    }
    public void ResetLevel()
    {
        for (int i = 0; i < cofees.Count; i++)
        {
            cofees[i].position = cofeeDefaultPositions[i];
            cofees[i].SetParent(transform);
            cofees[i].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
