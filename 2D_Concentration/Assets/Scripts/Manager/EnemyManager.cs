using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private Coroutine waveRoutine;
    [SerializeField] private List<GameObject> enemyPrefabs;
    private Dictionary<string, GameObject> enemyPrefabDic;
    
    [SerializeField] List<Rect> spawnAreas;
    [SerializeField] private Color gizmoColor = new Color(1, 0, 0, .3f);
    private List<EnemyController> activeEnemies = new List<EnemyController>();

    private bool enemySpawnComplete;
    [SerializeField] private float timeBetweenSpawns = 0.2f;
    [SerializeField] private float timeBetweenWaves = 1f;

    GameManager gameManager;

    [SerializeField] private List<GameObject> itemPrefabs;
    public void Init(GameManager gameManager)
    {
        this.gameManager = gameManager;
        enemyPrefabDic = new Dictionary<string, GameObject>();
        foreach (GameObject prefab in enemyPrefabs)
        {
            enemyPrefabDic[prefab.name] = prefab;
        }
    }
    public void StartWave(int waveCount)
    {
        if (waveCount <= 0)
        {
            gameManager.EndOfWave();
            return;
        }

        if(waveRoutine !=null)
            StopCoroutine(waveRoutine);
        waveRoutine = StartCoroutine(SpawnWave(waveCount));
    }
    public void StopWave()
    {
        StopAllCoroutines();
    }

    private IEnumerator SpawnWave(int waveCount)
    {
        enemySpawnComplete = false;
        yield return new WaitForSeconds(timeBetweenWaves);

        for (int i = 0; i < waveCount; i++)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);
            SpawnRandomEnemy();
        }
        enemySpawnComplete = true;
    }

    private void SpawnRandomEnemy(string prefabName = null)
    {
        if (enemyPrefabs.Count == 0 || spawnAreas.Count == 0)
        {
            Debug.LogWarning("EnemyPrefabs 또는 Spawn Areas가 설정되지  않았습니다.");
            return;
        }

        GameObject randomPrefab;
        if (prefabName == null)
        {
            randomPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
        }
        else
        {
            randomPrefab = enemyPrefabDic[prefabName];
        }
        Rect randomArea = spawnAreas[Random.Range(0, spawnAreas.Count)];

        Vector2 randomPosition = new Vector2(
            Random.Range(randomArea.xMin, randomArea.xMax),
            Random.Range(randomArea.yMin, randomArea.yMax));

        GameObject spawnEnmy = Instantiate(randomPrefab, new Vector3(randomPosition.x, randomPosition.y),Quaternion.identity);
        EnemyController enemyController = spawnEnmy.GetComponent<EnemyController>();
        enemyController.Init(this, gameManager.player.transform);


        activeEnemies.Add(enemyController);

    }

    private void OnDrawGizmosSelected()
    {
        if (spawnAreas == null) return;
        Gizmos.color = gizmoColor;
        foreach (var area in spawnAreas)
        {
            Vector3 center = new Vector3(area.x + area.width / 2, area.y + area.height / 2);
            Vector3 size = new Vector3(area.width, area.height);

            Gizmos.DrawCube(center, size);
        }
    }
   
    public void RemoveEnemyOnDeath(EnemyController enemy)
    {
        activeEnemies.Remove(enemy);
        
        CreatRandomItem(enemy.transform.position);
        
        if (enemySpawnComplete && activeEnemies.Count == 0)
            gameManager.EndOfWave();
    }

    public void CreatRandomItem(Vector3 position)
    {
        GameObject item = Instantiate(itemPrefabs[Random.Range(0,itemPrefabs.Count)],position,Quaternion.identity);
    }

    public void StartStage(StageInstance stageInstance)
    {
        if(waveRoutine != null)
            StopCoroutine(waveRoutine);

        waveRoutine = StartCoroutine(SpawnStart(stageInstance));
    }

    private IEnumerator SpawnStart(StageInstance stageInstance)
    {
        enemySpawnComplete = false;
        yield return new WaitForSeconds(timeBetweenWaves);

        WaveData waveData = stageInstance.currentStageInfo.waves[stageInstance.currentWave];
        for (int i = 0; i < waveData.monsters.Length; i++)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            
            MonsterSpawnData monsterSpawnData = waveData.monsters[i];
            for (int j = 0; j < monsterSpawnData.spawnCount; j++)
            {
                SpawnRandomEnemy(monsterSpawnData.monsterType);
            }
        }

        if (waveData.hasBoss)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            
            gameManager.MainCameraShake();
            SpawnRandomEnemy(waveData.bossType);
        }

        enemySpawnComplete = true;
    }



}
