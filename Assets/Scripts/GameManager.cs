using System.Collections;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public UIManager UIManager;
	public Player player;
	public GameObject shield;
	public GameObject invisible;
	public bool shieldIsOn => shield.activeSelf;
	public bool invisibleIsOn => invisible.activeSelf;
	public TextureScroller ground;
	public float gameTime = 10;
	public float invisibleTime;
	public static float SpeedUpCoef = 1;
	public float speedUpStep = 5;
	public float speedUpAdd = 0.15f;
	private int speedUpCount;
	
	float totalTimeElapsed = 0;
	bool isGameOver = false;
	private float invisTime;
	private float tSpeedUp;
	
	private void Awake()
	{
		shield.SetActive(false);
		invisible.SetActive(false);
	}

	void Update()
	{
		if (isGameOver)
			return;

		tSpeedUp += Time.deltaTime;

		if (tSpeedUp > speedUpStep)
		{
			speedUpCount++;
			tSpeedUp = 0;

			SpeedUpCoef += speedUpAdd * speedUpCount;
		}
		
		if (!shieldIsOn)
			gameTime -= Time.deltaTime;

		totalTimeElapsed += Time.deltaTime;

		UpdateCount();
		
		if (gameTime <= 0)
		{
			Time.timeScale = 0;
			isGameOver = true;
			UIManager.ShowReplayPanel((int)totalTimeElapsed);
		}
	}

	public void AdjustTime(float amount)
	{
		if (amount < 0)
		{
			if (invisibleIsOn) return;
			if (shieldIsOn) SetShieldActive(false);
			SlowWorldDown();
		}
		
		gameTime += amount;
	}

	void SlowWorldDown()
	{
		CancelInvoke(); 
		Time.timeScale = 0.35f;
		Invoke("SpeedWorldUp", 1);
	}

	void SpeedWorldUp()
	{
		Time.timeScale = 1f;
	}

	private void UpdateCount()
	{
		UIManager.UpdateText((int)gameTime);
	}
	
	public void SetShieldActive(bool value)
	{
		shield.SetActive(value);
	}

	public void SetInvisible()
	{
		if (invisibleIsOn)
		{
			invisTime += invisibleTime;
			return;
		}
		invisTime = invisibleTime;
		StartCoroutine(Invisible());
	}

	public void Replay()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(sceneBuildIndex: 1);
	}

	private IEnumerator Invisible()
	{
		invisible.SetActive(true);
		player.SetInvisible(invisibleIsOn);

		float t = 0;

		while (t <= invisTime)
		{
			t += Time.deltaTime;
			UIManager.UpdateInvisibleText((int) (invisTime - t));
			yield return null;
		}
		
		invisible.SetActive(false);
		player.SetInvisible(invisibleIsOn);
	}
}
