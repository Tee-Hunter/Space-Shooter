using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmyController : MonoBehaviour {
    public float speed;

    GameObject player;

    private Rigidbody rb;
    public float titl; // ອົງສາການອຽງ
    public GameObject emyBolt;
	
	void Start () {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player"); // ຫາເຫັນແລ້ວ ໃຫ້ນຳຂ້າ player

        InvokeRepeating("OnShooting", 0f, 1f);// ຄຳສັ່ງເຮັດຟັງຊັິນຊ້ຳໆ looping ເປັນແບບນີ້ InvokeRepeating("ຊື່ຟັງຊັ້ນ", ເວລາທີ່ເລີ່ມ, ເວລະໃນການເອີ້ນຊ້ຳ);
	}

    void OnShooting ()
    {
        Instantiate(emyBolt, transform.position, Quaternion.identity); 
    }
	
	
	void FixedUpdate () {
        if (player != null) // ກວດສອບເບິງວ່າຖ້າ player ຍັງບໍ່ຕາຍໃຫ້ມັນນຳໄປຍິງ
        {
            float moveX = 0f;

            // ຖ້າ player ມີ​ x ຫຼາຍກວ່າເຮົາ
            if (Mathf.Round(player.transform.position.x) > Mathf.Round(transform.position.x)) // ໄວ້ປ່ຽນຕ່າຂອງຕຳແໜ່ງທີ່ຢູ່ ຕົວຢ່າງຖ້າມັນຫຼາຍກວ່າ 4 ໃຫ້ລຸດລົງ ຫຼື ນ້ອຍກວ່າ -4 ໃຫ້ເພີ່ມຂື້ນ
            {
                moveX = 1f;
            }

            else if (Mathf.Round(player.transform.position.x) < Mathf.Round(transform.position.x)) // ຖ້າ player ມີ x ນ້ອຍກວ່າເຮົາ
            {
                moveX = -1f;
            }

            rb.velocity = new Vector3(moveX, 0f, -1f) * speed; // code ຍ້າຍຕຳແໜ່ງຍານສັດຕູ

            rb.rotation = Quaternion.Euler(0f, -180f, rb.velocity.x *           titl); //ເຮັດໃຫ້ຍານສັດຕູອຽງຕົວເມື່ອເຄື່ອນຍ້າຍ
        }
	}
}
