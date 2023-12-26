using UnityEngine;

public class Collectable : MonoBehaviour
{

    public Vector3 SpinAmount = new Vector3(0, 20, 0);
    public CollectableSpawner spw;

    private void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (SpinAmount * Time.deltaTime));

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        spw.SpawnNewObject();
    }

}