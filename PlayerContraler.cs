using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContraler : MonoBehaviour {

    // ສ້າງclass ໃຫມ່ຂື້ນມາເກັບຕົວແປ
    [System.Serializable] public class Boundary // [System.Serializable ແມ່ນການດຶງເອົາຄ່າຕົວແປໃນ class ນີ້ໄປໃຊ້ໃນ unity 
    {
        public float xMin;
        public float xMax;
        public float zMin;
        public float zMax;
    }


    public Rigidbody rb;
    public float speed = 10f;
    public float titl; // ອົງສາການອຽງຍານ

    public GameObject shot;     // ແທນກະສຸນ
    public Transform shotSpawn; // ແທນຕຳແໜ່ງ 
    public float fireRate;      // ຕົວຖ່ວງເວລາການຍ້ງ
    private float nextFire;     // ເວລາທີ່ເຮົາຈະຍິງນັດຕໍ່ໄປ

    public Boundary _boundary; // ເປັນການຕັ້ງຊື້ໄວໃນຕົວແປ _boundary ເພື່ອນຳໄປໃຊ້

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
    	
	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, .0f, moveVertical);
        rb.velocity = movement * speed; // Velocity  ແມ່ນການເຄື່ອນທີ່ຕາມຄວາມໄວ ຖ້າໃຊ້ Add.Force ແມ່ນການເຄື່ອນທີ່ຕາມຄວາມແຮງ

        // ກຳນົດເນື້ອທີ່ໃນການເຄື່ນຍ້າຍຂອງຍານ
        rb.position = new Vector3
            (
                // Mathf.Clamp ເປັນຕົວລະບຸຕຳແໜ່ງວ່າໃຫຍ່ສຸດນ້ອຍສຸດເທົາໃດ
                Mathf.Clamp(rb.position.x, _boundary.xMin, _boundary.xMax),       // ການເຄື່ອນທີ່ຕາມແກນ x 
                .0f,                                                             // ການເຄື່ອນທີ່ຕາມແກຍ y ໃສ່ສູນຍ້ອນວ່າເຮົາບໍ່ຕ້ອງການໃຫ້ຍົນຂື້ນລົງ
                Mathf.Clamp(rb.position.z, _boundary.zMin, _boundary.zMax)       // ການເຄີ່ອນທີ່ຕາມແກນ z
            );

        rb.rotation = Quaternion.Euler(0f, 0f, rb.velocity.x * -titl); // ຄຳສັ່ງນີ້ເຮົດໃຫ້ຍານອຽງຊ້າຍເມື່ອເຄື່ອນທີ່ໄປທາງຊ້າຍ ແລະ ອຽງຂວາເມື່ອເຄື່ອນທີ່ໄປທາງຂວາ; Quaternion ເປັນຕົວແທນໃນການໝູນ; Euler ອົງສາໃນການໝູນຂອງຍານ
	}

    //ສ່ວນຄຳສັ່ງຂອງການຍິງອາວຸດ
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire) //ຄຳສັ່ງກົດປູ່ມຍິງ
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //ຄຳສັ້ງໃນການເພີມວັດຖູທີ່ເຮົາສ້າງໄວ້ໃນ prefab ໃນທີ່ນີ້ເຮົາເພີ່ມຈຳນວນກະສຸນ

            GetComponent<AudioSource>().Play();
        }
    }
}
