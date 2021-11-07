using UnityEngine;

public class DecorationSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] decorationOptions;

    public GameObject CurrentDecoration { get; private set; }

    public void SpawnDecorations()
    {
        GameObject prefab = decorationOptions[Random.Range(0, decorationOptions.Length)];
        CurrentDecoration = Instantiate(prefab, transform);
        CurrentDecoration.transform.localPosition = Vector3.zero;
        CurrentDecoration.transform.rotation = Quaternion.identity;
    }
}
