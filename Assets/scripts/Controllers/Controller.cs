using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public abstract void Start();

    public abstract void Update();

    public abstract void ProcessInputs();
}
