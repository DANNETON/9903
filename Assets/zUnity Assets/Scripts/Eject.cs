
using StarterAssets;
using System.Collections;
using UnityEngine;

public class Eject : MonoBehaviour
{
    [Header("Item Management")]
    public Vector3 direction;
    public float force = 10f;
    public float delay = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {

    }

    public void emit()
    {
        Debug.Log("emit ");
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        FirstPersonController controller = gameObject.GetComponent<FirstPersonController>();
        rb.isKinematic = false;
        rb.useGravity = true;
        controller.enabled = false;
        rb.AddForce(direction * force, ForceMode.Impulse);
        StartCoroutine(afterEmit());
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"碰撞到了物体: {collision.gameObject.name}");
        Collider[] arr = GetComponents<Collider>();
        for (int i = 0; i < arr.Length; i++)
        {
            Debug.Log($"碰撞体: {arr[i].gameObject.name + arr[i].name}");
        }
        arr = GetComponentsInChildren<Collider>();
        for (int i = 0; i < arr.Length; i++)
        {
            Debug.Log($"碰撞体: {arr[i].gameObject.name + arr[i].name}");
        }
    }
    IEnumerator afterEmit()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(delay);
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        FirstPersonController controller = rb.GetComponent<FirstPersonController>();
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        rb.isKinematic = true;
        rb.useGravity = false;
        controller.enabled = true;
    }
}
