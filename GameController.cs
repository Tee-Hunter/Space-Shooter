using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // lib ສຳລັບການສ້າງ Text in Unity

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public int hazardCount;
    public float spawnWaite;
    public float spawnWave;

    public Text ScoreText;
    public Text gameOverText;
    public Text restartText;

    private int score; // ໄວ້ເກັບຄະແນນ
    private bool gameOver;// ກວດເບິ່ງວ່າ ເກມເຮົາຈົບແລ້ວ ຫຼື ບໍ່?
    private bool restart;

    public GameObject emyObj; // ຕົວແປເພື່ອສ້າງຍານສັດຕູຫຼາຍລຳ
   
	void Start () {

        gameOver = false;
        restart = false;

        gameOverText.text = "";
        restartText.text = "";

        score = 0;
        UpdateScore();

        StartCoroutine(SpawnWaves());

        InvokeRepeating("AddEmy", 2f, 5f);

    }

    void AddEmy()
    {
        // ຖ້າ player ຍັງບໍ່ຕາຍໃຫ້ສ້່ງຍານສັດຕູມາເລີອຍໆ
        if (gameOver == false)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-11, 11), 0f, 9f); // Random Emyship
            Instantiate(emyObj, spawnPosition, Quaternion.identity);
        }

        // ຖ້າ player ຕາຍຍົກເລີກ ແລະ ຍຸດການສ້າງຍານສັດຕູທີ່ສ້າງມາ
        else
        {
            CancelInvoke("AddEmy");
        }
    }

    // ໄວ້ເກັບຄະແນນ
    public void AddScore(int newScoreValue) //ຮັບຄ່າເຂົ້າມາເກັບໄວ້ newScoreValue
    {
        score += newScoreValue;
        UpdateScore();
    }

    // ໄວອັບເດດຄະແນນ
    void UpdateScore()
    {
        ScoreText.text = "Score : " + score.ToString();
    }


    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }

    void Update()
    {
        // ຖ້າເກມຈົບໃຫ້ສະແດງຂໍ້ຄວາມ Press 'R' for restart! ອອກທາງໜ້າຈໍ
        if (gameOver)
        {
            restart = true;
            restartText.text = "Press 'R' for restart!";
        }

        if (restart) // ຖ້າ restart ແລ້ວໃຫ້ເຮັດຕໍ່ໄປ
        {
            if (Input.GetKeyDown(KeyCode.R)) // ກວດສອບເບຶ່ງວ່າມີການກົດ R ບໍ່ ຖ້າກົດໃຫ້ເຮັດຕໍ່ໄປ
            {
                Application.LoadLevel(Application.loadedLevel); // ຖ້າກົດ R ໃຫ້ມັນໄປໂຫຼດ ສ່ວນໂປຣແກຣມກັບມາເລີ່ມໃໝ່ອີກຄັ້ງ
            }
        }
    }


    // ການສ້າງອຸກະບາດຫຼາຍລູກ
    IEnumerator SpawnWaves()
    {
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                // ສາມບັນທັດນີ້ແມ່ນຄຳສັ່ງໃນການສ້າງອຸກະບາດ
                Vector3 spawnPosition = new Vector3(Random.Range(-11, 11), 0f, 9f); //Random.Range ຄຳສັ່ງໃນການແລນດອມຕຳແໜ່ງຂອງອຸກະບາດ
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);

                // ສັ່ງໃຫ້ອຸກະບາດລໍເພື່ອໃຫ້ຕົກມາເປັນລຳດັບ່ພ້ອມກັນ
                yield return new WaitForSeconds(spawnWaite);
            }
            yield return new WaitForSeconds(spawnWave);
        }
    }
}
