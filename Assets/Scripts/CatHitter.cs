using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatHitter : MonoBehaviour
{
    public GameObject textScore;
    public TextMesh textScore3D;
    public GameObject[] hitParticles;
    public bool isIa = false;
    public GameManager gm;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (!isIa)
        {
            if (hit.gameObject.tag == "hittable")
            {
                print("Objet touché = " + hit.gameObject.name);
                hit.gameObject.tag = "hitted";
                Rigidbody obj_rb = hit.gameObject.GetComponent<Rigidbody>();
                HittableObject ho = hit.gameObject.GetComponent<HittableObject>();
                HitEffect(obj_rb, hit);
                Score3DEffect(ho);
                GetCoins(ho);
            }
        }
    }

    public void HitEffect(Rigidbody obj_rb, ControllerColliderHit hit)
    {
        obj_rb.isKinematic = false;
        obj_rb.AddExplosionForce(75, transform.position + Vector3.down, 15);
        Instantiate(hitParticles[Random.Range(0, hitParticles.Length)], hit.gameObject.transform.position, Quaternion.identity);
        iTween.PunchScale(textScore, new Vector3(1.25f, 1.25f, 1.25f), 0.3f);
    }

    public void Score3DEffect(HittableObject ho)
    {
        int newScore = int.Parse(textScore.GetComponent<TextMeshProUGUI>().text) + ho.points;
        textScore.GetComponent<TextMeshProUGUI>().text = newScore.ToString();
        textScore3D.text = "+" + ho.points;
        Invoke("ResetText3D", 0.5f);
    }

    public void ResetText3D()
    {
        textScore3D.text = "";
    }

    public void GetCoins(HittableObject ho)
    {
        int actualCoins = PlayerPrefs.GetInt("nbCoins", 0);
        if (actualCoins + ho.coins > 999999999)
        {
            PlayerPrefs.SetInt("nbCoins", 999999999);
        }
        else
        {
            PlayerPrefs.SetInt("nbCoins", actualCoins + ho.coins);
        }
    }

    // Gestion de l'IA
    private void OnTriggerEnter(Collider other)
    {
        if (isIa && gm.gameStarted && !gm.gameEnded)
        {
            if(other.gameObject.tag == "hittable")
            {
                Rigidbody obj_rb = other.gameObject.GetComponent<Rigidbody>();
                HittableObject ho = other.gameObject.GetComponent<HittableObject>();
                obj_rb.isKinematic = false;
                obj_rb.AddExplosionForce(75, transform.position + Vector3.down, 15);
                Instantiate(hitParticles[Random.Range(0, hitParticles.Length)], other.gameObject.transform.position, Quaternion.identity);

                if(other.gameObject.name != "touched")
                {
                    AiPlayer aip = GetComponent<AiPlayer>();
                    aip.GetPoints(ho.points * 3);
                }

                other.gameObject.name = "touched";
            }
        }
    }
}
