using UnityEngine;

public class Player : MonoBehaviour
{
	// Атрибут Header, с помощью которого на панели Inspector выводится строка заголовка 
	[Header("References")]
	// Переменные содержат ссылки на менеджера игры и два материала
	public GameManager manager;
	public Material normalMat;
	public Material phasedMat;

	// Переменные обрабатывают настройки игры — границы уровня
	// и скорость бокового движения игрока
	[Header("Gameplay")]
	public float bounds = 3f;
	public float strafeSpeed = 4f;

	Renderer mesh;
	Collider collision;

	void Start()
	{
		mesh = GetComponentInChildren<SkinnedMeshRenderer>();
		collision = GetComponent<Collider>();
	}

	public void SetInvisible(bool value)
	{
		mesh.material = value? phasedMat : normalMat;
	//	collision.enabled = !value;
	}

	void Update()
	{
		float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * strafeSpeed;
		Vector3 position = transform.position;
		position.x += xMove;

		position.x = Mathf.Clamp(position.x, -bounds, bounds);
		transform.position = position;
		
	}
}
