using UnityEngine;

public struct Point
{
    public float X;
    public float Y;

    public Vector2 Position { get { return new Vector2(X, Y); } }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void RandomPosition(Vector2 limits)
    {
        X = Random.Range(0, limits.x);
        Y = Random.Range(0, limits.y);
    }
}