using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiPlayer : MonoBehaviour
{
    public NavMeshAgent nma;
    public float radius = 10f;
    public Animator catAnim;
    public int score = 0;
    public GameManager gm;
    public Texture[] skins;

    private void Start()
    {
        transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = skins[Random.Range(0, skins.Length)];
    }

    public void StartGame()
    {
        nma.destination = RandomNavmeshLocation(radius);
        catAnim.SetBool("canWalk", true);
        InvokeRepeating("ChangeDest", Random.Range(8, 12), Random.Range(8, 12));
    }

    public Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;
        Vector3 finalPosition = Vector3.zero;
        if(NavMesh.SamplePosition(randomDirection, out hit, radius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }

    public void ChangeDest()
    {
        nma.destination = RandomNavmeshLocation(radius);
    }

    void Update()
    {
        if(gm.gameStarted && nma.remainingDistance < 1.5f )
        {
            ChangeDest();
        }
    }

    public void GetPoints(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}
