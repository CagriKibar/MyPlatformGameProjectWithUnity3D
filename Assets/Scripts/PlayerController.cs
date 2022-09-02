using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameManager _gameManager;
    public float speed;
    float FirstTouchX;
    float diff = 0;
    float lastTouxhX;
    public int cofeeCount = 0;
    public List<GameObject> cofees;
    public int Hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        cofees = new List<GameObject>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent < GameManager > ();
    }

    // Update is called once per frame
    void Update()
    {
        if (_gameManager.currentGameState!= GameState.Start)
        {
            return;
        }

        
        //ileri gönder;
        Vector3 movementVector= new Vector3(0, 0, 1 * speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            FirstTouchX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            lastTouxhX = Input.mousePosition.x;
            diff = lastTouxhX-FirstTouchX;
            movementVector += new Vector3(diff * Time.deltaTime, 0, 0);
            FirstTouchX = lastTouxhX;

        }
        transform.position += movementVector;
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            other.transform.SetParent(transform);//diðer objenýn parentini ben yap.
            cofees.Add(other.gameObject);
            cofeeCount++;
            
        }
        else if (other.CompareTag("Finish"))
        {
            
            if (cofeeCount==0)
            {
                _gameManager.EndGame();
            }
            else
            {
                cofees[cofees.Count - 1].SetActive(false);
                cofees.RemoveAt(cofees.Count - 1);
                cofeeCount--;
            }
            
            
        }
        else if (other.CompareTag("Spawn"))
        {
            if (Hp==0)
            {
                _gameManager.EndGame();
            }
        }
    }
}
