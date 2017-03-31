using UnityEngine;

public class EffectSpawner : MonoBehaviour
{
    static EffectSpawner instance;
    public GameObject fightParticles;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static GameObject SpawnFightParticles(Vector3 position)
    {
       return Instantiate(instance.fightParticles, position, Quaternion.AngleAxis(-90,Vector3.right));
    }

}
