using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimalTransform
{
    Horse,
    Chicken,
    Player
}

public class AvailableTransform : MonoBehaviour
{
    [SerializeField] private AnimalTransform currentTransform;
    public AnimalTransform CurrentTransform => currentTransform;    
}
