using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
	public Bonus[] bonusPrefabs;
	public Collidable[] obstaclePrefab;

	public float minSpawnTime = 0.5f;
	public float maxSpawnTime = 1.5f;

	GameManager manager;
	
	float elapsedTime;
	bool spawnPowerup = true;
	private float time;
	
	void Start()
	{
		manager = GetComponent<GameManager>();
		time = Random.Range(minSpawnTime, maxSpawnTime + 1);
	}

	void Update()
	{
		elapsedTime += Time.deltaTime;

		if (elapsedTime > time)
		{
			GameObject temp;
			if (spawnPowerup)
				temp = Instantiate(SpawnBonus());
			else
				temp = Instantiate(SelectObstacle());

			Vector3 position = temp.transform.position;
			position.x = Random.Range(-3f, 3f);
			temp.transform.position = position;

			Collidable col = temp.GetComponent<Collidable>();
			col.manager = manager;

			elapsedTime = 0;
			spawnPowerup = !spawnPowerup;
			time = Random.Range(minSpawnTime, maxSpawnTime + 1);
		}
	}

	private GameObject SelectObstacle()
	{
		var index = Random.Range(0, obstaclePrefab.Length);
		var obstacle = obstaclePrefab[index];
		return obstacle.gameObject;
	}

	private GameObject SpawnBonus()
	{
		while (true)
		{
			var index = Random.Range(0, bonusPrefabs.Length);
			var bonus = bonusPrefabs[index];

			if (bonus.bonusType == Bonus.BonusType.AddShield && manager.shieldIsOn ||
			    bonus.bonusType == Bonus.BonusType.AddInvisible && manager.invisibleIsOn)
			{
				continue;
			}
			
			return bonus.gameObject;
		}
	}
}
