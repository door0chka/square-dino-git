using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    public void MoveWithVelocity(Vector3 velocity) => _rigidbody.velocity = velocity;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Enemy>())
        {
            // AddForce on ragdolls
        }

        Destroy(gameObject);
    }
}