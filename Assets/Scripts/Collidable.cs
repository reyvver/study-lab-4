using UnityEngine;

public class Collidable : MonoBehaviour
{
	// Переменные для скрипта менеджера игры — 
	// скорость движения и величина изменения времени
	public GameManager manager;
	public float moveSpeed = 20f;
	public float value = 1.5f;

	void Update()
	{
		transform.Translate(0, 0, -moveSpeed * Time.deltaTime);
	}

	protected virtual void OnCollide()
	{
		Destroy(gameObject);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			OnCollide();
		}
	}
}
