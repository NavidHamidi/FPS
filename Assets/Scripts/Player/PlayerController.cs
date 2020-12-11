using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float moveSpeed = 5f;
	[SerializeField] private float mouseSpeedY = 5f;
	[SerializeField] private float mouseSpeedX = 5f;

	// Components
	private Rigidbody rb;
	private Transform playerCamera;

	public void Start()
	{
		rb = GetComponent<Rigidbody>();
		playerCamera = GetComponentInChildren<Camera>().transform;
	}

	private Vector3 Move()
	{
		float InputX = Input.GetAxisRaw("Horizontal");
		float InputZ = Input.GetAxisRaw("Vertical");

		Vector3 moveH = transform.right * InputX;
		Vector3 moveV = transform.forward * InputZ;

		Vector3 velocity = (moveH + moveV).normalized * moveSpeed * Time.fixedDeltaTime;
		return velocity;
	}

	private Vector3 Rotate()
	{
		float rotationY = Input.GetAxisRaw("Mouse X");
		Vector3 rotation = new Vector3(0, rotationY, 0) * mouseSpeedY;
		return rotation;
	}

	private Vector3 RotateCamera()
	{
		float rotationX= Input.GetAxisRaw("Mouse Y");
		Vector3 rotation = new Vector3(rotationX, 0, 0) * mouseSpeedX;
		return rotation;
	}

	public void FixedUpdate()
	{
		Vector3 velocity = Move();
		rb.MovePosition(rb.position + velocity);

		Vector3 rotationY = Rotate();
		rb.MoveRotation(rb.rotation * Quaternion.Euler(rotationY));

		Vector3 rotationX = RotateCamera();
		playerCamera.Rotate(-rotationX);
	}
}
