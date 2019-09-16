using UnityEngine;

public class GlobalReference : MonoBehaviour
{
	public static float deltaTime { get; private set; }
	public static float fixedDeltaTime { get; private set; }
	public static float PPU { get; private set; }

	private void Awake()
	{
		PPU = 32f;
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
