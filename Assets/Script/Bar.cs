public class Bar
{
    public string name;
    float speed = 1f;
    int score = 1;

    public Bar(float newSpeed,int newScore){
        speed = newSpeed;
        score = newScore;
    }

    public float Speed{
        get{
            return speed;
        }
    }

    public int Score{
        get{
            return score;
        }
    }
}
