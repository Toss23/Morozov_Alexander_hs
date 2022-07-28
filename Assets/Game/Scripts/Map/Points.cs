using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private GameObject _pointPrefab;
    [SerializeField] private Map _map;
    [SerializeField] private int _pointsCount;
    [SerializeField] private float _distanceMin;
    private List<Point> _points;

    private void Awake()
    {
        if (_pointsCount > 0)
        {
            _points = new List<Point>();

            Point firstPoint = new Point();
            firstPoint.RandomPosition(_map.Size);
            _points.Add(firstPoint);

            for (int i = 1; i < _pointsCount; i++)
            {
                int iteration = 0;
                Point point = new Point();
                do
                {
                    point.RandomPosition(_map.Size);
                    iteration++;
                    if (iteration >= 1000)
                    {
                        Debug.LogError("Point cant be found. Created: " + i);
                        break;
                    }
                }
                while (CheckDistanceWithPoints(point, _distanceMin) == false);

                if (iteration >= 1000)
                    break;

                _points.Add(point);
            }

            foreach (Point point in _points)
            {
                GameObject pointObject = Instantiate(_pointPrefab);
                pointObject.transform.position = new Vector3(point.Position.x, pointObject.transform.position.y, point.Position.y);
                pointObject.transform.SetParent(transform);
                pointObject.name = "Point";
            }
        }
    }

    public Point GetRandomPoint()
    {
        int randomIndex = Random.Range(0, _points.Count);
        return _points.ToArray()[randomIndex];
    }

    private bool CheckDistanceWithPoints(Point newPoint, float distanceMin)
    {
        foreach (Point point in _points)
        {
            if (Vector2.Distance(newPoint.Position, point.Position) < distanceMin)
                return false;
        }
        return true;
    }
}