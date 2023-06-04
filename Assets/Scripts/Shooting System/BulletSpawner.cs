using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private BulletShooter _spawnShooter;

    public void NewSpawn() => _spawnShooter.ChangeCurrentSpawn(Instantiate(_bulletPrefab.gameObject, transform.position, transform.rotation).GetComponent<Bullet>());
}