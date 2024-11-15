using UnityEngine;
using UnityEditor.Experimental.GraphView;
using System.Collections;
using System.Collections.Generic;

public class control : MonoBehaviour
{

    [SerializeField] public Transform target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
    }
}
