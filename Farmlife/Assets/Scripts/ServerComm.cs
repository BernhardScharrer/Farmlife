using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net.Http;
using System.Text;

public class ServerComm : MonoBehaviour
{
    public static HttpClient client { get; private set; }
    public static string lastResponse { get; private set; }
    private static string postTarget = "https://fforganizer.at/farmlife/farmlife.php";

    // Start is called before the first frame update
    void Start()
    {
        client = new HttpClient();
    }

    public static async void Post(string message)
    {
        HttpContent content = new StringContent(message, Encoding.UTF8, "application/json");

        HttpResponseMessage responseMessage = await client.PostAsync(postTarget, content);

        Debug.Log(responseMessage.StatusCode);

        lastResponse = await responseMessage.Content.ReadAsStringAsync();
    }

    public static async void Get()
    {
        lastResponse = await client.GetStringAsync(postTarget);
    }
}

public class Login
{
    public string Username;
    public string Password;

    public Login()
    {

    }

    public Login(string username, string password)
    {
        Username = username;
        Password = password;
    }

}
