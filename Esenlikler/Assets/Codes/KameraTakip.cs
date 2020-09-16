using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraTakip : MonoBehaviour
{
	public Transform Berkay;
	public float xdegeri;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = new Vector3(Berkay.position.x + xdegeri,0,-10);
    }
}
