using UnityEngine;

public class GlobalReference : MonoBehaviour
{
	public static float deltaTime;
	public static float fixedDeltaTime;

	public static float PPU = 32f;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	private void Update()
	{
		deltaTime = Time.deltaTime;
	}

	private void FixedUpdate()
	{
		fixedDeltaTime = Time.fixedDeltaTime;
	}
}
