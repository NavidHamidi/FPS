using Mirror;
using UnityEngine;

public class PlayerSetup : NetworkBehaviour
{
	// To avoid controlling all player 
	[SerializeField] private Behaviour[] componentsToDisable;

	GameObject mainCamera;

	private void Start()
	{
		mainCamera = Camera.main.gameObject;

		if (isLocalPlayer)
		{
			mainCamera.SetActive(false);
			return;
		}

		for (int i = 0; i < componentsToDisable.Length; i++)
			componentsToDisable[i].enabled = false;


	}

	private void OnDisable()
	{
		mainCamera.SetActive(true);
	}
}
