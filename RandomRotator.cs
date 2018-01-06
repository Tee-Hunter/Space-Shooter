using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    public float tumble; //ເກືອກກຶ້ງ
    
    void Start()
    {   
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble; // angularVelocity ຄວາມໄວເຊີງມູນໃຊ້ໃນການໝູນ; insideUnitSphere ອົງສາຂອງຂອງວັດຖຸແບບສາມມິຕິ
    }

}