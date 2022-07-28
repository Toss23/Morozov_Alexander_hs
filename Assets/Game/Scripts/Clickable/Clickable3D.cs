using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public abstract class Clickable3D : MonoBehaviour
{
    public abstract void OnClick();
}