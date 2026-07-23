using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] private float bulletTime = 1f;

    private void Awake()
    {
        Destroy(gameObject, bulletTime);
    }
    
}
