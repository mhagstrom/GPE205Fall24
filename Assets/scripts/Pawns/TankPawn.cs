using System.Collections;
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
	[SerializeField] private TankShooting shooting;
	private float timeSinceLastAttack = 0;
	
	// Update is called once per frame
	public override void Update()
	{
		timeSinceLastAttack += Time.deltaTime;
	}
	
	//because multiplication can be done in any order, speed values can be here so that tankpawn overwrites pawn allowing multiple tanks to have different values. also being here means the value fields only appear on the tankpawn in the inspector and not also in tankmovement again
	public override void Mover()
	{
		float verticalInput = Input.GetAxis("Vertical");
		float horizontalInput = Input.GetAxis("Horizontal");
		tankMovement.ApplyMovement(verticalInput);
		tankMovement.ApplyHullRotation(horizontalInput);
	}
	public override void Attack()
	{ //check if able to attack again
		if (timeSinceLastAttack < attackRate)
		{
			return;
		}
		shooting.Shoot();
		timeSinceLastAttack = 0;
	}

	public override void cursorInput(Vector3 value)
	{
		
	}
}
