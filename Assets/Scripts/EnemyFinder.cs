using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    [SerializeField] private PlayerSystem _playerSystem;

    [SerializeField] private float _minimumDistance;

    public List<Transform> enemiesAndFinish;

    private Transform nearestEnemy;

    public void FindEnemy()
    {
        nearestEnemy = null;

        _minimumDistance = Mathf.Infinity;

        foreach (Transform enemy in enemiesAndFinish)
        {
            if (_playerSystem.transform.position == null)
            {
                return;
            }

            float distance = Vector3.Distance(_playerSystem.transform.position, enemy.position);

            if (distance < _minimumDistance)
            {
                _minimumDistance = distance;
                nearestEnemy = enemy;
            }

            if (_minimumDistance > 10f) _playerSystem.goToNextWaypoint = true;
            else _playerSystem.goToNextWaypoint = false;
        }

        Debug.Log("Nearest: " + nearestEnemy + "; Distance: " + _minimumDistance);
    } 
}
