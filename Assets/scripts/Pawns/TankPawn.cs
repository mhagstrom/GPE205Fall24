﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class TankPawn : Pawn
{
	//serializefields instead of getcomponent in awake
	[SerializeField] private TankMovement tankMovement;
	[SerializeField] private Turret turret;
	
	//because multiplication can be done in any order, speed values can be here so that tankpawn overwrites pawn allowing multiple tanks to have different values. also being here means the value fields only appear on the tankpawn in the inspector and not also in tankmovement again
	public override void VerticalInput(float value)
	{
		value *= moveSpeed;
		tankMovement.ApplyMovement(value);
	}
	public override void HorizontalInput(float value)
	{
		value *= rotationSpeed;
		tankMovement.ApplyHullRotation(value);
	}
}
