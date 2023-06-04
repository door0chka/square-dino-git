using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Image _healthSlider;

    [SerializeField] private float _health;

    private EnemyFinder _enemyFinder;

    private const int _MAX_HEALTH = 100;

    private void Start()
    {
        _health = _MAX_HEALTH;

        _enemyFinder = FindObjectOfType<EnemyFinder>();

        _enemyFinder.enemiesAndFinish.Add(gameObject.transform);
    }

    private void TakeDamage(float damage)
    {
        _health -= damage;
        _healthSlider.fillAmount = _health / _MAX_HEALTH;
    }

    private void DieByBullet() => Destroy(gameObject);

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Bullet>())
        {
            TakeDamage(25);

            if (_health <= 0) DieByBullet();
        }
    }

    private void OnDestroy()
    {
        _enemyFinder.enemiesAndFinish.Remove(gameObject.transform);

        _enemyFinder.FindEnemy();
    }
}