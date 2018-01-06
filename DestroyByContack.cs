using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContack : MonoBehaviour {

    public GameObject explosion; // ຕົວແປເອບເຟັກລະເບີດ
    public GameObject playerExplosion; // ລະເບິດຂອງຜູ້ຫລີ້ນ 
    public int scoreValue;  // ການໃຫ້ຄ່າໃນການຍິງ ເຊັ່ນຍິງບາດໜຶ່ງໄດ້ຄະແນນໜຶ່ງ ຖ້າປຽນຄ່າເປັນ 5 ສະແດງວ່າຍິງບາດ 1 ໄດ້ 5 ຄະແນນ

    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null) // ກວດສອບການຕຳ
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if(gameControllerObject == null)
        {
            Debug.Log("Cannot find GameController script");
        }
    }


    // ໂຄດຄວບຄຸມການຕຳກັັນລະຫວ່າງອຸກະບາດກັບ ລຸກປື້ນ
    void OnTriggerEnter(Collider other) // OnTriggerEnter ເປັນການສ້າງເງື່ອນໄຂ ຖ້າລຸກປືນຖືກອຸກະບາດຈະຫາຍໄປ 
    {
        if (other.tag == "BoundaryDeleteBolt")      
            return;


        //ກອດສອບວ່າອຸກະບາດຕຳ player ບໍ່
        if (other.tag == "Player")
        {
            Instantiate(explosion, transform.position, transform.rotation); // ເອັບເຟກຕອນອູກະບາດຖືກຍິງ

            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);  // ເອັບເຟກຕອນອຸກະບາດຕຳ player ຫຼື player ຕາຍ

            gameController.GameOver();

            Destroy(gameObject); // ລົບຕົວເອງ
            Destroy(other.gameObject);// ລົບສິ່ງທີ່ຊົນພ້ອມກັບຕົວອັນເອງ
            
        }

        if (other.tag == "Bolt")
        {
            Debug.Log("this is the bolt hit");
            Instantiate(explosion, transform.position, transform.rotation); //ເອັບເຟັກຕອນອຸກະບາດກັບຍານສັດຕູຊົນກັນ
            Destroy(gameObject); // ທຳລາຍຕົວເອງ

            gameController.AddScore(scoreValue); // ເມື່ອອຸກະບາດຖືກຍິງໃຫ້ gameController ມີຄ່າເທົ່າ 1
        }

    }
}
