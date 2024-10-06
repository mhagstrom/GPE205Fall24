using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankPawn))]
public class TankComponent : MonoBehaviour
{
   protected TankPawn tankPawn;
   //using protected so that noone gets OUR tankpawn while still allowing other scripts that needs access to it to access it

   private void Awake()
   {
      tankPawn = GetComponent<TankPawn>();
   }
   //this script is used for components that are specifically tanks as opposed to other entities like humvees or infantry
}
