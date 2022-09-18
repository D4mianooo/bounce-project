using System.Collections;
using UnityEngine;

public class Ball1 : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float bouncingSpeed = 8f;
    [SerializeField] private float speed = 6f;
    private float velocityMagnitude;
    private Rigidbody enemyRigidBody;
    private Vector3 lastVelocity;
    private HealthUI healthUI;
    private DiedUI diedUI;

    private void Awake()
    {
        enemyRigidBody = GetComponent<Rigidbody>();
        healthUI = GameObject.FindGameObjectWithTag("HealthUI").GetComponent<HealthUI>();
        diedUI = GameObject.FindObjectOfType<DiedUI>();
    }

    private void OnEnable()
    {
        StartCoroutine(AddForceVelocity());
    }

    private void Update()
    {
        EnemyMovingProcess();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            int currentPlayerHealth = playerHealth.GetHealth();
            playerHealth.SetHealth(currentPlayerHealth - 1);

            healthUI.UpdateHeartContainer();

            if (!playerHealth.IsPlayerAlive())
            {
                Time.timeScale = 0f;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                foreach(Transform child in diedUI.transform){
                    child.gameObject.SetActive(true);
                };
                Camera.main.GetComponent<CameraController>().enabled = false;
            }
        }

        BounceEnemyOfAnObject(collision);
    }


    private void BounceEnemyOfAnObject(Collision collisionInfo)
    {
        var bouncingSpeed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collisionInfo.contacts[0].normal).normalized;
        enemyRigidBody.velocity = direction * Mathf.Max(bouncingSpeed, 0f);
    }

    private void EnemyMovingProcess()
    {
        AssignLastVelocity();
        AssignVelocityMagnitude();
        MakeTheRigidBodyVelocityAlwaysTheSameAsStaticVelocity();
        AddVelocityIfEnemyStopped();
    }

    private void AssignLastVelocity()
    {
        lastVelocity = enemyRigidBody.velocity;
    }

    private void AssignVelocityMagnitude()
    {
        velocityMagnitude = enemyRigidBody.velocity.magnitude;
    }

    private void MakeTheRigidBodyVelocityAlwaysTheSameAsStaticVelocity()
    {
        if (velocityMagnitude != speed)
        {
            enemyRigidBody.velocity = lastVelocity.normalized * speed;
        }
    }

    private void AddVelocityIfEnemyStopped()
    {
        if (EnemyStopped())
        {
            StartCoroutine(AddForceVelocity());
        }
    }

    private bool EnemyStopped()
    {
        return enemyRigidBody.velocity == Vector3.zero;
    }

    private IEnumerator AddForceVelocity()
    {
        yield return new WaitForFixedUpdate();
        AddRandomForceToRigidBody();
    }

    private void AddRandomForceToRigidBody()
    {
        Vector3 value = bouncingSpeed * Time.deltaTime * Random.insideUnitSphere.normalized;
        enemyRigidBody.AddForce(value);
    }
}
