using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    
	void OnTriggerExit(Collider other)
    {
        // ກຳຈັດລູກປືນທີ່ຍິງອອກໄປແລ້ວເພື່ອຊ່ວຍໃຫ້ຄວາມຂະໜາດຂອງເກມໃຫ້ໜ້ອຍລົງ
        Destroy(other.gameObject);
    }
}
