using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    public float speed;

    // code ຄວາມຄຸງກະສູນທີ່ເປັນລູກສອນໄຟ
	void Start ()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
	

}
