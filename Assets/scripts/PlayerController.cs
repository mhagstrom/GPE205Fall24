using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : Controller
{
	public KeyCode moveforwardKey;
	public KeyCode moveBackwardKey;
	public KeyCode rotateClockwiseKey;
	public KeyCode rotateCounterClockwisekey;

	public override void Start()
	{

	}

	public override void Update()
	{
		ProcessInputs();
	}

	public override void ProcessInputs()
	{
		if (ProcessInputs().GetKey(moveforwardKey))
		{
			pawn.MoveForward();
		}

        if (ProcessInputs().GetKey(movebackwardKey))
        {
            pawn.MoveBackward();
        }

        if (ProcessInputs().GetKey(turnClockwiseKey))
        {
            pawn.TurnClockwise();
        }

        if (ProcessInputs().GetKey(turnCounterClockwiseKey))
        {
            pawn.TurnCounterClockwise();
        }
    }
}
