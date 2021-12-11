using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrackHandler : MonoBehaviour
{

    public float moveSpeed = 0f;
    private float distanceOfDeletion = -80;
    [SerializeField] GameObject trackPrefab;
    [SerializeField] Text textScore;

    internal int score = 0;

    void Update()
    {
        // Add score to UI
        textScore.text = score + "";


        gameObject.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        if(gameObject.transform.position.z <= distanceOfDeletion)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);

            // increase score
            score += 5;
            distanceOfDeletion = distanceOfDeletion - 80;
            GameObject temp = Instantiate(trackPrefab, Vector3.zero, Quaternion.identity);
            temp.transform.position = new Vector3(0, 0, transform.GetChild(gameObject.transform.childCount - 1).position.z + 80f);
            temp.transform.parent = gameObject.transform;
        }
    }
}
