using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float bobbingSpeed;
    [SerializeField] private float bobbMinHeight;
    [SerializeField] private float bobbMaxHeight;
    [SerializeField] private int pointValue;

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0, Space.Self);
        if (transform.position.y < bobbMinHeight)
        {
            DoBobb(Vector3.up);
        }
        else if (transform.position.y > bobbMaxHeight)
        {
            DoBobb(Vector3.down);
        }
        else
        {
            DoBobb(Vector3.up);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindAnyObjectByType<ScoreManager>().IncreaseScore(pointValue);
            Destroy(this.gameObject);
        }
    }

    private void DoBobb(Vector3 direction)
    {
        transform.Translate(direction * bobbingSpeed * Time.deltaTime, Space.World);
    }
}
