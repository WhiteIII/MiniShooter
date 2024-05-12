using System;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] protected int _damage;
    [SerializeField] protected float _distance;
    [SerializeField] protected LayerMask _layerMask;

    public virtual event Action Shooting;
}
