using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pin : MonoBehaviour {
    Rigidbody2D rigid;
    public float speed = 20f;
    bool isPined = false;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isPined)
        {
            rigid.MovePosition(rigid.position + Vector2.up * speed * Time.deltaTime);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Spin")
        {
            isPined = true;
            this.transform.SetParent(collision.gameObject.transform);
        }

        if(collision.gameObject.tag == "Pin")
        {
            Camera.main.backgroundColor = Color.yellow;
            StartCoroutine(Restart());
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
