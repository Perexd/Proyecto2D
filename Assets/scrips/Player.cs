using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

	public float jumpForce = 10f;

	public Rigidbody2D rb;
	public SpriteRenderer sr;
	public string currentColor;
	
	public GameObject prefab; //particules Prefab
	public GameObject prefab2; //particules Prefab
	public GameObject sound;  //sound prefab Item
	public GameObject soundJump; //sound jump 
	public GameObject soundS; //sonido Estrella

	public int score;
	public TMP_Text scoretext;

	//color ball

	public Color colorCyan;
	public Color colorYellow;
	public Color colorMagenta;
	public Color colorPink;

	void Start()
	{
		SetRandomColor();
		if(PlayerPrefs.HasKey("Score"))
		{
			score = PlayerPrefs.GetInt("Score");
			scoretext.text = "Score: " + score;
		}
	}

	void Update()
	{
		if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) // JUMP
		{
			rb.velocity = Vector2.up * jumpForce;
			Instantiate(soundJump, transform.position, transform.rotation);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "ColorChanger") //color changer
		{
			SetRandomColor();
			score++;
			PlayerPrefs.SetInt("Score", score);
			scoretext.text = "Score: " + score;
			Instantiate(prefab, transform.position, transform.rotation);//particles
			Instantiate(sound, transform.position, transform.rotation);//sound
			Destroy(col.gameObject);
			return;;
		}

		if (col.transform.parent != null)
		{
			if (col.tag != currentColor && col.transform.parent.tag == "colorC") //color changer kill
			{
				score--;
				PlayerPrefs.SetInt("Score", score);
				scoretext.text = $"Score: {score}";
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}
		}
		if (col.tag == "Boom") // RED wall kill
		{
			score--;
			PlayerPrefs.SetInt("Score", score);
			scoretext.text = $"Score: {score}";
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		}
		if (col.tag == "star") //counter Item 
		{
			score++;
			PlayerPrefs.SetInt("Score", score);
			scoretext.text = "Score: " + score;
			Instantiate(prefab2, transform.position, transform.rotation);
			Instantiate(soundS, transform.position, transform.rotation);
			Destroy(col.gameObject);
		}
		if (col.tag == "win") // Win Hard
		{
			 SceneManager.LoadScene("win");
		}
		if (col.tag == "win2") // Win Easy
		{
			 SceneManager.LoadScene("win2");
		}
	}

	void SetRandomColor() //color ball changer
	{
		int index = Random.Range(0, 4);
		
		// color list

		switch (index)
		{
			case 0:
				currentColor = "Cyan";
				sr.color = colorCyan;
				break;
			case 1:
				currentColor = "Yellow";
				sr.color = colorYellow;
				break;
			case 2:
				currentColor = "Magenta";
				sr.color = colorMagenta;
				break;
			case 3:
				currentColor = "Pink";
				sr.color = colorPink;
				break;
		}
	}
}
