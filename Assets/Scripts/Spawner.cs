using UnityEngine;

public class Spawner : MonoBehaviour
{
	// Ссылки на игровые объекты «бонус» и «препятствие» 
	public GameObject powerupPrefab;
	public GameObject obstaclePrefab;

	// Переменные для управления временем и порядком появления объектов
	public float spawnCycle = .5f;

	GameManager manager;

	float elapsedTime;
	// Бонусы и препятствия будут порождаться поочередно, и специальный флаг
	// станет следить за тем, что именно должно порождаться
	bool spawnPowerup = true;

	void Start()
	{
		manager = GetComponent<GameManager>();
	}

	void Update()
	{
		// Увеличивается счетчик истекшего времени
		elapsedTime += Time.deltaTime;

		// Пора ли порождать новый объект?
		if (elapsedTime > spawnCycle)
		{
			GameObject temp;
			// Какой объект нужно породить: бонус или препятствие?
			if (spawnPowerup)
				temp = Instantiate(powerupPrefab) as GameObject;
			else
				temp = Instantiate(obstaclePrefab) as GameObject;

			// Новый объект смещается вправо или влево на случайную величину
			Vector3 position = temp.transform.position;
			position.x = Random.Range(-3f, 3f);
			temp.transform.position = position;

			// Новый объект получает ссылку на менеджера игры
			Collidable col = temp.GetComponent<Collidable>();
			col.manager = manager;

			// Уменьшается истекшее время
			elapsedTime = 0;
			// Флаг, отвечающий за тип порождаемого объекта, меняется на противоположный
			spawnPowerup = !spawnPowerup;
		}
	}
}
