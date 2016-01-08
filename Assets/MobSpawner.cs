using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MobSpawner : MonoBehaviour
{
    public GameObject[] mobPrefabs;
    public Button nextLevelButton;
    private int[] levels = {1, 3, 5, 7, 10},
                    mobs = {0, 0, 0, 0, 0};
    public float spawnRate;
    private float spawnTime;
    private int waveSize, mobIndex, curLevel = -1;

	void Start()
    {
        spawnTime = Time.time + spawnRate;
	}

	void Update ()
    {
        Spawner();
        nextLevelButton.GetComponentInChildren<Text>().text = "Next level\nCurrently: " + (curLevel + 1).ToString();
	}

    public void NextLevel()
    {
        curLevel++;
        Spawn(levels[curLevel], mobs[curLevel]);
        nextLevelButton.enabled = false;
    }

    public void Spawn(int size, int mob)
    {
        waveSize = size;
        mobIndex = mob;
    }

    private void Spawner()
    {
        if(spawnTime <= Time.time && waveSize > 0)
        {
            Instantiate(mobPrefabs[mobIndex], transform.position, Quaternion.identity);
            spawnTime = Time.time + spawnRate;
            waveSize--;
            if(waveSize <= 0)
                nextLevelButton.enabled = true;
        }
    }
}
