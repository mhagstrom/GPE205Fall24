using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Controller
{
	//GetAxis returns float from Unity for named axis
	public float verticalInput;
	public float horizontalInput;


	public override void Start()
	{

	}

	public override void Update()
	{
		ProcessInputs();
	}

	public override void ProcessInputs()
	{
		verticalInput = Input.GetAxis("Vertical");
		horizontalInput = Input.GetAxis("Horizontal");

		if (verticalInput < 0)
			horizontalInput = -Input.GetAxis("Horizontal");
	}
}
