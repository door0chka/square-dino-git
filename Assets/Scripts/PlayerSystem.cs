using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerSystem : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints;
    [SerializeField] private NavMeshAgent _playerNavMeshAgent;

    [SerializeField] private Animator _playerNavAgentAnimator;

    [SerializeField] private Camera _mainCamera;
    [SerializeField] private BulletShooter _bulletShooter;
    [SerializeField] private Transform _firstPersonView, _thirdPersonView;

    [SerializeField] private GameObject _startGameButton;

    [SerializeField] private int _waypointsIndex;

    public bool goToNextWaypoint;

    private void Start() => _playerNavAgentAnimator.SetBool("isRunning", false);

    private void Update()
    {
        if (goToNextWaypoint)
        {
            _playerNavMeshAgent.destination = _waypoints[_waypointsIndex].position;

            _playerNavAgentAnimator.SetBool("isRunning", true);

            goToNextWaypoint = false;
        }
    }

    public void StartTheGame()
    {
        _playerNavAgentAnimator.SetBool("isRunning", true);

        _startGameButton.SetActive(false);

        _playerNavMeshAgent.destination = _waypoints[_waypointsIndex].position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Waypoint>())
        {
            _waypointsIndex++;

            _bulletShooter.ReadyToShoot = true;

            _playerNavAgentAnimator.SetBool("isRunning", false);

            _mainCamera.transform.SetPositionAndRotation(_firstPersonView.transform.position, _firstPersonView.transform.rotation);

            if (_waypointsIndex == _waypoints.Count) SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Waypoint>())
        {
            _bulletShooter.ReadyToShoot = false;

            _mainCamera.transform.SetPositionAndRotation(_thirdPersonView.transform.position, _thirdPersonView.transform.rotation);
        }
    }
}