using UnityEngine;

        public class Orbit : MonoBehaviour
{
    public float speed = 30f;

    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
