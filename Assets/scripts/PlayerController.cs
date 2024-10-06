using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Controller
{
	private Pawn playerPawn;
	private AimCursor cursor;
	public void TakeControl(Pawn pawn)
	{
		playerPawn = pawn;
		//need to do more here to move camera to newly controlled tank
		cursor = playerPawn.GetComponentInChildren<AimCursor>();
		//finds first aimcursor in children of playerpawn
	}
	
	[SerializeField] private Transform cameraTransform;
	[SerializeField] private float cameraZoomSpeed = 1.0f;
	//f says the number is a float not a decimal
	
	public override void Start()
	{

	}

	public override void Update()
	{
		//every frame check if the tank still exists, if so do inputs
		//don't process inputs if tank is destroyed to avoid errors
		if (playerPawn == null) return;
		
		ProcessInputs();
	}
	
	public override void ProcessInputs()
	{
		cursor.UpdateCursorPosition(Input.mousePosition);
		float verticalInput = Input.GetAxis("Vertical");
		float horizontalInput = Input.GetAxis("Horizontal");

		if (verticalInput < 0)
			horizontalInput = -Input.GetAxis("Horizontal");
		
		playerPawn.VerticalInput(verticalInput);
		playerPawn.HorizontalInput(horizontalInput);
		
		//camera zoom is vector2 from Input.mouseScrollDelta p.s. might switch to new unity input system for more device compatibility
		//cameraTransform.position += cameraTransform.forward * Input.mouseScrollDelta.y * cameraZoomSpeed; comment out for more explanatory format below
		
		//get scroll delta, only the y value is used, x is ignored according to unity docs
		//negative values are zooming out and positive in
		float scrollDelta = Input.mouseScrollDelta.y;
		//multiply by the zoom speed
		scrollDelta *= cameraZoomSpeed;
		//move the camera forward or backward based on the scroll delta
		cameraTransform.position += cameraTransform.forward * scrollDelta;
		
		//camerascroll function lets this script serve more purpose than just passing along values and makes finding enemies easier
		
		//shooting with left click mouse input
		if (Input.GetMouseButtonDown(0))
		{
			playerPawn.Attack();
		}
	}
}
