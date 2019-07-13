using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Main : MonoBehaviour {
	public int[][] charactercolors = new int[26][];
	public Texture2D letter;
	public Sprite lettersprite;
	public int score;
	public Text scoretext;
	public Image letterimage;
	bool skipfirstletter = false;
	public int pixelsmatched = 0;
	public GameObject buttonholder, seperateletterholder;
	GameObject[] buttons = new GameObject[26];
	 Image[] seperateletters = new Image[26];
	// Use this for initialization
	void Start () {
		for (int i = 0; i < 26; i++)
		{
			buttons[i] = buttonholder.transform.GetChild(i).gameObject;
			seperateletters[i] = seperateletterholder.transform.GetChild(i).GetComponent<Image>();

		}
		letter = new Texture2D(3, 5);
		letter.filterMode = FilterMode.Point;
		for (int x = 0; x< 3; x++)
		{
		for (int y = 0; y< 5; y ++)
		{
				letter.SetPixel(x, y, Color.black);

		}	
		}
		letter.Apply();
		charactercolors[0] = new int[] { //A
		1,1,1,
		1,0,1,
		1,1,1,
		1,0,1,
		1,0,1};
		charactercolors[1] = new int[] { //B
		1,0,0,
		1,0,0,
		1,1,1,
		1,0,1,
		1,1,1};
		charactercolors[2] = new int[] { //C
		1,1,1,
		1,0,0,
		1,0,0,
		1,0,0,
		1,1,1};
		charactercolors[3] = new int[] { //D
		0,0,1,
		0,0,1,
		1,1,1,
		1,0,1,
		1,1,1};
		
		charactercolors[4] = new int[] { //E
			1,1,1,
			1,0,0,
			1,1,1,
			1,0,0,
			1,1,1
		};
		charactercolors[5] = new int[] { //F
			1,1,1,
			1,0,0,
			1,1,1,
			1,0,0,
			1,0,0
		};
		charactercolors[6] = new int[] { //G
			1,1,1,
			1,0,0,
			1,0,1,
			1,0,1,
			1,1,1
		};
		charactercolors[7] = new int[] { //H
			1,0,1,
			1,0,1,
			1,1,1,
			1,0,1,
			1,0,1
		};
		charactercolors[8] = new int[] { //I
			1,1,1,
			0,1,0,
			0,1,0,
			0,1,0,
			1,1,1
		};
		charactercolors[9] = new int[] { //J
			0,0,1,
			0,0,1,
			0,0,1,
			1,0,1,
			1,1,1
		};
		charactercolors[10] = new int[] { //K
			1,0,1,
			1,0,1,
			1,1,0,
			1,0,1,
			1,0,1
		};
		charactercolors[11] = new int[] { //L
			1,0,0,
			1,0,0,
			1,0,0,
			1,0,0,
			1,1,1
		};
		charactercolors[12] = new int[] { //M
			1,0,1,
			1,1,1,
			1,0,1,
			1,0,1,
			1,0,1
		};
		charactercolors[13] = new int[] { //N
			1,0,1,
			1,1,1,
			1,1,1,
			1,1,1,
			1,0,1
		};
		charactercolors[14] = new int[] { //O
			1,1,1,
			1,0,1,
			1,0,1,
			1,0,1,
			1,1,1
		};
		charactercolors[15] = new int[] { //P
			1,1,1,
			1,0,1,
			1,1,1,
			1,0,0,
			1,0,0
		};
		charactercolors[16] = new int[] { //Q
			1,1,1,
			1,0,1,
			1,1,1,
			0,0,1,
			0,0,1
		};
		charactercolors[17] = new int[] { //R
			1,1,0,
			1,0,1,
			1,1,0,
			1,0,1,
			1,0,1
		};
		charactercolors[18] = new int[] { //S
			1,1,1,
			1,0,0,
			1,1,1,
			0,0,1,
			1,1,1
		};
		charactercolors[19] = new int[] { //T
			1,1,1,
			0,1,0,
			0,1,0,
			0,1,0,
			0,1,0
		};
		charactercolors[20] = new int[] { //U
			1,0,1,
			1,0,1,
			1,0,1,
			1,0,1,
			1,1,1
		};
		charactercolors[21] = new int[] { //V
			1,0,1,
			1,0,1,
			1,0,1,
			1,0,1,
			0,1,0
		};
		charactercolors[22] = new int[] { //W
			1,0,1,
			1,0,1,
			1,0,1,
			1,1,1,
			1,0,1
		};
		charactercolors[23] = new int[] { //X
			1,0,1,
			1,0,1,
			0,1,0,
			1,0,1,
			1,0,1
		};
		charactercolors[24] = new int[] { //Y
			1,0,1,
			1,0,1,
			0,1,0,
			0,1,0,
			0,1,0
		};
		charactercolors[25] = new int[] { //Z
			1,1,1,
			0,0,1,
			0,1,0,
			1,0,0,
			1,1,1
		};

	}
	public void ChangeImage(int letterindex)
	{
		pixelsmatched = 0;
		for (int x = 0; x < 3; x++)
		{
		for (int y = 0; y < 5; y++)
		{
				letter.SetPixel(x, y, (((letter.GetPixel(x, y) == Color.white ? 1 : 0) ^ charactercolors[letterindex][y*3+x]) == 1 ? Color.white : Color.black));

		}	
		}
		letter.Apply();
		for (int i = 0; i < 26; i++)
		{
			for (int x = 0; x < 3; x++)
			{
				for (int y = 0; y < 5; y++)
				{
					if (!(letter.GetPixel(x, y) == (charactercolors[i][y * 3 + x] == 1 ? Color.white : Color.black)))
					{
						pixelsmatched = 0;
						break;
					}
					else
					{
						pixelsmatched++;
					}
					if (x == 2 && y == 4 && pixelsmatched == 15 && !(seperateletters[i].color == Color.black))
					{
						if (skipfirstletter)
						{

							score++;
							buttons[i].SetActive(false);
							seperateletters[i].color = Color.black;
							return;
						}
						else
							skipfirstletter = true;


					}
				}
				if (pixelsmatched == 0) break;
			}
		}
	
	}

	public void Reset()
	{
		skipfirstletter = false;
		//SceneManager.LoadScene("superfluous");
			for (int x = 0; x< 3; x++)
		{
		for (int y = 0; y< 5; y ++)
		{
				letter.SetPixel(x, y, Color.black);

		}	
		}
		letter.Apply();
		for (int i = 0; i < 26; i++)
		{
			if (seperateletters[i].color != Color.black)
				buttons[i].SetActive(true);

		}

	}
	// Update is called once per frame
	void Update () {
		scoretext.text = "SCORE "  + score;
		lettersprite = Sprite.Create(letter, new Rect(0, 0, 3, 5), new Vector2(0.5f, 0.5f));

		letterimage.sprite = lettersprite;

	}
}
