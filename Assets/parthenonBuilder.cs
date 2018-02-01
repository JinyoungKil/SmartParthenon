//21400051 jinyoungKil

using System.Linq;
using UnityEngine;

public class parthenonBuilder : MonoBehaviour {

    public GameObject cubePrefab;
    public GameObject cylinderPrefab;

    public float floorWidth = 5.0f;
    public float floorDepth = 10.0f;
    public float floorHeight = 0.25f;

    public float pillarRadius = 0.2f;
    public float pillarHeight = 2.0f;
    public float pillarCountWidth = 6.0f;
    public float pillarCountDepth = 10.0f;

    public float roofHeight = 1.0f;

    public Material floorMaterial;
    public Material pillarMaterial;
    public Material roofMaterial;

    [ContextMenu("Parthenon Build1")]
    void Build1()
    {
        var floor1 = Instantiate(cubePrefab, transform);
        floor1.transform.localPosition = new Vector3(0, 0, 0);
        floor1.transform.localScale = new Vector3(floorWidth, floorHeight, floorDepth);

        var floor2 = Instantiate(cubePrefab, transform);
        floor2.transform.localPosition = new Vector3(0, floorHeight, 0);
        floor2.transform.localScale = new Vector3(floorWidth * 0.9f, floorHeight, floorDepth * 0.9f);

        var floor3 = Instantiate(cubePrefab, transform);
        floor3.transform.localPosition = new Vector3(0, floorHeight * 2, 0);
        floor3.transform.localScale = new Vector3(floorWidth * 0.81f, floorHeight, floorDepth * 0.81f);
    }

    [ContextMenu("Parthenon Build2")]
    void Build2()
    {
        for(int i = 0; i < 17; i++)
        {
            float d = (floorDepth * 0.81f - 0.4f) / 16;

            var pillar1 = Instantiate(cylinderPrefab, transform);
            pillar1.transform.localPosition = new Vector3(-(floorWidth * 0.81f) / 2 + pillarRadius, pillarHeight, -(floorDepth * 0.81f) / 2 + pillarRadius + d * i);
            pillar1.transform.localScale = new Vector3(pillarRadius, pillarHeight, pillarRadius);

        }

        for(int i = 1; i < 7; i++)
        {
            float w = (floorWidth * 0.81f - 0.4f) / 7;

            var pillar2 = Instantiate(cylinderPrefab, transform);
            pillar2.transform.localPosition = new Vector3(-(floorWidth * 0.81f) / 2 + pillarRadius + i * w, pillarHeight, (floorDepth * 0.81f) / 2 - pillarRadius);
            pillar2.transform.localScale = new Vector3(pillarRadius, pillarHeight, pillarRadius);
        }


        
        for(int i = 0; i < 17; i++)
        {
            float d = (floorDepth * 0.81f - 0.4f) / 16;

            var pillar3 = Instantiate(cylinderPrefab, transform);
            pillar3.transform.localPosition = new Vector3((floorWidth * 0.81f) / 2 - pillarRadius, pillarHeight, (floorDepth * 0.81f) / 2 - pillarRadius - i * d);
            pillar3.transform.localScale = new Vector3(pillarRadius, pillarHeight, pillarRadius);
        }


        for(int i = 1; i < 7; i++)
        {
            float w = (floorWidth * 0.81f - 0.4f) / 7;

            var pillar4 = Instantiate(cylinderPrefab, transform);
            pillar4.transform.localPosition = new Vector3((floorWidth * 0.81f) / 2 - pillarRadius - i * w, pillarHeight, -(floorDepth * 0.81f) / 2 + pillarRadius);
            pillar4.transform.localScale = new Vector3(pillarRadius, pillarHeight, pillarRadius);

        }
    }

    [ContextMenu("Parthenon Build3")]
    void Build13()
    {
        var roof = Instantiate(cubePrefab, transform);
        roof.transform.localPosition = new Vector3(0, pillarHeight * 2, 0);
        roof.transform.localScale = new Vector3(floorWidth * 0.9f, roofHeight, floorDepth * 0.9f);
    }

    [ContextMenu("Destroy All")]
    void DestroyAllChildren()
    {
        foreach (Transform t in transform.Cast<Transform>().ToArray())
        {
            DestroyImmediate(t.gameObject);
        }
    }
}
