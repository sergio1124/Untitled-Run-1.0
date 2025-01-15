using Cinemachine;
using Quantum;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraViewContext : MonoBehaviour, IQuantumViewContext
{
    [field:SerializeField] public CinemachineVirtualCamera VirtualCamera {  get; private set; }
}
