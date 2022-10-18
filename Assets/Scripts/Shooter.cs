using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float _force = 100f;
    [SerializeField] private TMP_Text _ballsUsedText;
    
    private int _ballsUsed = 0;
    
    private void Start()
    {
        SetBallsUsedTextText();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out RaycastHit hit, 100.0f);
            Vector3 point = new Vector3();
            
            if (hit.collider && (hit.collider.gameObject.GetComponent<ScoreBlock>() || hit.collider.gameObject.CompareTag("Environment")))
            {
                point = hit.point;
            }
            else
            {
                point = ray.GetPoint(100f);
            }
            
            GameObject newBullet = Instantiate(bullet, cam.gameObject.transform.position, Quaternion.identity);
            newBullet.transform.LookAt(point);
            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            rb.AddForce(newBullet.transform.forward * _force, ForceMode.Impulse);

            _ballsUsed++;
            SetBallsUsedTextText();
        }
    }
    
    private void SetBallsUsedTextText()
    {
        _ballsUsedText.SetText(_ballsUsed.ToString());
    }
}
