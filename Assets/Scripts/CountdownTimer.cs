using UnityEngine;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text countdownText;
    [SerializeField] float countdownTime = 3f;
    
    private bool _hasLost = false;

    private void Update()
    {
        if (_hasLost) return;
        
        if (countdownTime > 1)
        {
            countdownTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(countdownTime / 60);
            int seconds = Mathf.FloorToInt(countdownTime % 60);
            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        else
        {
            countdownTime = 0;
            countdownText.color = Color.green;
            countdownText.text = "You won!";
            var player = GameObject.FindGameObjectWithTag("Player").GetComponent<PointsNavigation>();
            player.StopNavigation();
        }
    }
    
    public void Lose()
    {
        _hasLost = true;
        countdownText.color = Color.red;
        countdownText.text = "You lost!";
    }
}
