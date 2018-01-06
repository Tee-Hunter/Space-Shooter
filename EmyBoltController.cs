using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmyBoltController : MonoBehaviour {

    public GameObject playerExplosion; // ລະເບິດຂອງຜູ້ຫລີ້ນ 
    private GameController gameController;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");

        if (gameControllerObject != null) // ກວດສອບການຕຳ
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find GameController script");
        }
    }


    // ໂຄດຄວບຄຸມການຕຳກັັນລະຫວ່າງອຸກະບາດກັບ ລຸກປື້ນ
    void OnTriggerEnter(Collider other) // OnTriggerEnter ເປັນການສ້າງເງື່ອນໄຂ ຖ້າລຸກປືນຖືກອຸກະບາດຈະຫາຍໄປ 
    {

        //ກອດສອບວ່າອຸກະບາດຕຳ player ບໍ່
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);  // ເອັບເຟກຕອນອຸກະບາດຕຳ player ຫຼື player ຕາຍ

            gameController.GameOver();

            Destroy(gameObject); // ລົບຕົວເອງ
            Destroy(other.gameObject);// ລົບສິ່ງທີ່ຊົນພ້ອມກັບຕົວອັນເອງ 

        }
    }
}