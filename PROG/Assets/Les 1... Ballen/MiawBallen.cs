using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject prefab;

    private GameObject CreateBall(Color c, Vector3 position)
    {
        GameObject ball = Instantiate(prefab, position, Quaternion.identity);

        Material material = ball.GetComponent<MeshRenderer>().material;
        material.SetColor("_Color", c);


        Rigidbody rb = ball.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = ball.AddComponent<Rigidbody>();
        }
        rb.useGravity = true;

        return ball;
    }

    private void DestroyBall(GameObject ball, float time)
    {
        Destroy(ball, time);
    }


    private void Start()
    {
        CreateLotOfBalls();
    }
    void CreateLotOfBalls()
    {
        for (int i = 0; i < 100; i++)
        {
            Color color = RandomColor();
            Vector3 randPos = RandomPosition(-10f, 10f);
            CreateBall(color, randPos);
        }
    }

    private float elapsedTime = 0f;
    void Update()
    {
        CreateLotOfBalls();
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 1f)
        {
            Color color = RandomColor();
            Vector3 randPos = RandomPosition(-10f, 10f);
            GameObject ball = CreateBall(color, randPos);
            DestroyBall(ball, 5);
            elapsedTime = 0f;
        }
    }

    private Color RandomColor()
    {
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        return new Color(r, g, b, 1f);
    }

    private Vector3 RandomPosition(float min, float max)
    {
        float x = Random.Range(min, max);
        float y = Random.Range(min, max);
        float z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }
}