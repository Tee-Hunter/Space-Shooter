using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {

	public float liftTime;
	void Start () {
        Destroy(gameObject,liftTime);	
	}
	
	
}
