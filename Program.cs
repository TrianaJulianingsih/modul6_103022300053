using System;

class SayaTubeUser
{
    private int id;
    private List<SayaTubeVideo> uploadedVideos;
    private string username;

    public SayaTubeUser(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentException("Title cannot be null or empty");
        }
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.uploadedVideos = new List<SayaTubeVideo>();
        this.username = username;
    }
    public int GetTotalVideoPlayCount()
    {
        int total = 0;
        foreach(var video in uploadedVideos)
        {
            total += video.GetPlayCount();
        }
        return total;
    }
    public void AddVideo(SayaTubeVideo video)
    {
        if (video == null)
        {
            throw new ArgumentNullException("Video tidak boleh null.");
        }
        uploadedVideos.Add(video);
    }
    public void PrintAllVideoPlaycount()
    {
        Console.WriteLine($"User: {username}");
        for(int i = 0; i<uploadedVideos.Count; i++)
        {
            Console.WriteLine($"Video {i + 1} judul : {uploadedVideos[i].GetPlayCount()}");
        }
    }
}
class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException("Title cannot be null or empty");
        }
        Random random = new Random();
        this.id = random.Next(10000, 99999);
        this.title = title;
        this.playCount = 0;
    }
    public void IncreasePlayCount( int count)
    {
        if (count < 0)
        {
            throw new ArgumentException("Play count must be positive");
        }
        this.playCount += count;
    }
    public void PrintVideoDetails()
    {
        Console.WriteLine($"Video ID: {id}");
        Console.WriteLine($"title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }
    public int GetPlayCount()
    {
        return playCount;
    }
}
class Program
{
    static void Main()
    {
        SayaTubeUser user = new SayaTubeUser("Triana Julianingsih");
        for (int i = 0; i < 10; i++)
        {
            SayaTubeVideo video = new SayaTubeVideo($"Review Film {i} oleh Triana Julianingsih");
            video.IncreasePlayCount(10);
            user.AddVideo(video);
        }
        user.PrintAllVideoPlaycount();
        Console.WriteLine($"Total Play Count: {user.GetTotalVideoPlayCount()}");
    }
}
