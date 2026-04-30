using UnityEngine;
using System.Collections;

public class GameplayAnimations : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public float stf = -10f; // start from left
    public float enf = 10f; // end to right
    public float HEIGHT = 10f; //I think height maybe 

    public void AnimateNewCard(int handIndex, Card newCard)
    {

        Vector3 startPosition = new Vector3(Random.Range(stf, enf), HEIGHT, 30f);

        Vector3 targetPosition = newCard.gameObject.GetComponent<Transform>().position;

        Transform tr = newCard.gameObject.GetComponent<Transform>();
        tr.position = startPosition;
        tr.rotation = Quaternion.Euler(0, 0, Random.Range(-75f, 75f)); // rotation bitchessssssss


        Debug.Log($"Animating new card from {startPosition} to {targetPosition}");


        StartCoroutine(MoveCard(tr, targetPosition));
    }

    IEnumerator MoveCard(Transform card, Vector3 target)
    {
        float duration = 0.3f; // seconds 
        float time = 0f;
        Vector3 start = card.position;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            card.position = Vector3.Lerp(start, target, t);
            yield return null;
        }

        card.position = target;
        card.rotation = Quaternion.identity;
    }


}
