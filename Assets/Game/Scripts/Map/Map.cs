using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] private Vector2 _size;

    public Vector2 Size { get { return _size; } }
}