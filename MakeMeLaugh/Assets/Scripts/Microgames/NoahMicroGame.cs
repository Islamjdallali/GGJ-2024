using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahMicroGame : MicroGamesBase
{
    [SerializeField] private GameObject obstacleGO;
    [SerializeField] private float spawnTimer;
    [SerializeField] private BoatController boat;

    // Start is called before the first frame update
    void Start()
    {
        Init();
;       spawnTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Tick();
        spawnTimer -= Time.deltaTime * gameManager.gameSpeed;
        if (spawnTimer <= 0)
        {
            var spawnObstacle = Instantiate(obstacleGO,transform);
            spawnObstacle.transform.localPosition = new Vector3(500, Random.Range(120,-121), 0);
            spawnObstacle.GetComponent<ObstacleBehaviour>().game = this.GetComponent<MicroGamesBase>();
            spawnObstacle.GetComponent<ObstacleBehaviour>().boat = boat;
            spawnTimer = 1.5f;
        }

        if (boat.boatScore >= 3)
        {
            isCompleted = true;
        }
    }
}
