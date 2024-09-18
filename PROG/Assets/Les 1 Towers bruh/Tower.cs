using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject Tower;
    public Camera mainCamera;

    public Vector3 minSize = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 maxSize = new Vector3(2f, 2f, 2f);

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnTowerAtMousePosition();
        }
    }

    void SpawnTowerAtMousePosition()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Instantiate(Tower, hit.point, Quaternion.identity);
            Vector3 randomScale = new Vector3(
                Random.Range(minSize.x, maxSize.x),
                Random.Range(minSize.y, maxSize.y),
                Random.Range(minSize.z, maxSize.z)
            );
            Tower.transform.localScale = randomScale;
        }
    }
}