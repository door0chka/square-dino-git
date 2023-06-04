using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private EnemyFinder _enemyFinder;

    [SerializeField] private float _flightDuration, _flightDistance;

    public bool ReadyToShoot { private get; set; }

    private Bullet _bullet;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && ReadyToShoot) Shoot();
    }

    public void ChangeCurrentSpawn(Bullet newBullet) => _bullet = newBullet;

    private void Shoot()
    {
        _bulletSpawner.NewSpawn();

        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
       
        if (Physics.Raycast(ray, out RaycastHit hitInfo, _flightDistance)) ShootWithVelocity(hitInfo.point);
    }

    private void ShootWithVelocity(Vector3 targetPosition) => _bullet.MoveWithVelocity((targetPosition - _bullet.transform.position) / _flightDuration);
}