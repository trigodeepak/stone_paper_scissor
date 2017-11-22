using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {
	enum elements {Scissor = 1 , Paper , Rock}
	private int playerChoose = -1;
	private int botChoose = -1;
	private int[] counters = new int[3];

	private bool playersTurn = true;
	private int current = 0;
	public List<int> nextitem = new List<int>();

	public int r;

	public GameObject WinnerText;
	public Sprite paperImage, rockImage, scissorImage;
	public GameObject botChooseImage;
	public GameObject ScoreCard;

	void Start(){
		int a = Random.Range (1, 3);
		nextitem.Add (a);
		Debug.Log ("next item count"+nextitem.Count.ToString ());
	}

	// Update is called once per frame
	void Update () {
		if (playersTurn && playerChoose == -1)return;
		else {
			BotChoose(current);
			r = CheckWinner ();
			Update_the_list (r);
			//Debug.Log ("next item count "+nextitem.Count.ToString ()+" "+current.ToString());
			current += 1;
			playerChoose = -1;
			playersTurn = true;
		}
	}

	void Update_the_list (int r){
		if (r == 2) {
			nextitem.Add (playerChoose);
		} else if (r == 1) {
			for (int i = 1; i <= 3; i += 1)
				if (i != playerChoose && i != botChoose) {
					nextitem.Add (i);
					break;
				}
		} else if (r==3) {
			int j = Random.Range (1, 4);
			nextitem.Add (j);
		}
	}

	public int CheckWinner ()
	{	WinnerText.GetComponent<Text>().text = "Score board \n";
		if (playerChoose == botChoose) {
			//draw
			WinnerText.GetComponent<Text> ().text = "AI choose " + botChoose.ToString () + " :\nDRAW";
			counters [2] += 1;
			ScoreCard.GetComponent<Text> ().text = "Score Card\nWin\t Lose\t Tie\n" + counters [0].ToString () + "\t\t" + counters [1].ToString () + "\t\t   " + counters [2].ToString ();
			return 3;
		} else if (playerChoose == (int)elements.Paper && botChoose == (int)elements.Rock) {
			//player wins
			WinnerText.GetComponent<Text> ().text = "AI choose Rock :\nPlayer wins";
			counters [0] += 1;
			ScoreCard.GetComponent<Text> ().text = "Score Card\nWin\t Lose\t Tie\n" + counters [0].ToString () + "\t\t" + counters [1].ToString () + "\t\t   " + counters [2].ToString ();
			return 1;
		} else if (playerChoose == (int)elements.Rock && botChoose == (int)elements.Paper) {
			//Bot wins
			WinnerText.GetComponent<Text> ().text = "AI choose Paper :\nBot wins";
			counters [1] += 1;
			ScoreCard.GetComponent<Text> ().text = "Score Card\nWin\t Lose\t Tie\n" + counters [0].ToString () + "\t\t" + counters [1].ToString () + "\t\t   " + counters [2].ToString ();
			return 2;
		} else if (playerChoose == (int)elements.Rock && botChoose == (int)elements.Scissor) {
			//player wins
			WinnerText.GetComponent<Text> ().text = "AI choose Scissor :\nPlayer wins";
			counters [0] += 1;
			ScoreCard.GetComponent<Text> ().text = "Score Card\nWin\t Lose\t Tie\n" + counters [0].ToString () + "\t\t" + counters [1].ToString () + "\t\t   " + counters [2].ToString ();
			return 1;
		} else if (playerChoose == (int)elements.Scissor && botChoose == (int)elements.Rock) {
			//Bot wins
			WinnerText.GetComponent<Text> ().text = "AI choose Rock :\nBot wins";
			counters [1] += 1;
			ScoreCard.GetComponent<Text> ().text = "Score Card\nWin\t Lose\t Tie\n" + counters [0].ToString () + "\t\t" + counters [1].ToString () + "\t\t   " + counters [2].ToString ();
			return 2;
		} else if (playerChoose == (int)elements.Scissor && botChoose == (int)elements.Paper) {
			//player wins
			WinnerText.GetComponent<Text> ().text = "AI choose Paper :\nPlayer wins";
			counters [0] += 1;
			ScoreCard.GetComponent<Text> ().text = "Score Card\nWin\t Lose\t Tie\n" + counters [0].ToString () + "\t\t" + counters [1].ToString () + "\t\t   " + counters [2].ToString ();
			return 1;
		} else if (playerChoose == (int)elements.Paper && botChoose == (int)elements.Scissor) {
			//Bot wins
			WinnerText.GetComponent<Text> ().text = "AI choose Scissor :\n Bot wins";
			counters [1] += 1;
			ScoreCard.GetComponent<Text> ().text = "Score Card\nWin\t Lose\t Tie\n" + counters [0].ToString () + "\t\t" + counters [1].ToString () + "\t\t   " + counters [2].ToString ();
			return 2;
		} else {
			Debug.Log ("hi");
		}
		return -1;
	}

	public void PlayerChoose( int choose)
	{
		playerChoose = choose;
		playersTurn = false;
	}
	public void BotChoose(int c){
		botChoose = nextitem[c];
		Debug.Log (c.ToString()+" "+nextitem.Count.ToString());
		if (botChoose == 1) {
			botChooseImage.GetComponent<Image> ().sprite = scissorImage;
		}else if(botChoose == 2){
			botChooseImage.GetComponent<Image> ().sprite = paperImage;
		}else {
			botChooseImage.GetComponent<Image> ().sprite = rockImage;
		}
	}
}