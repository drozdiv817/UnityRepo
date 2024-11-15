using UnityEngine;

public class NoiseTest : MonoBehaviour
{
    // Start is called before the first frame update
    private float Perlin()
    {
        float min = Random.Range(0f, 1f);
        float max = Random.Range(0f, 1f);

        var noise = Mathf.PerlinNoise(min, max);
        return noise;
    }

    public int iterationX = 0;
    public int iterationZ = 0;

    private void TerrainGenerate()
    {
        while (iterationZ < 25)
        {
            while (iterationX < 25)
            {
                var terrain = GameObject.CreatePrimitive(PrimitiveType.Cube);
                terrain.transform.localScale = new Vector3(1, Perlin() * 10, 1);

                terrain.transform.position = new Vector3(iterationX, 0, iterationZ);
                
                iterationX = iterationX + 1;
            }
            iterationX = 0;
            iterationZ = iterationZ + 1;
        }
    }

    void Update()
    {
        TerrainGenerate();
    }
}
