using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Net.Http;
using System.Text;

public class ServerComm : MonoBehaviour
{
    public static HttpClient client { get; private set; }
    public static string lastResponse { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        client = new HttpClient();
    }

    public static async void Post(string target, string message)
    {
        HttpContent content = new StringContent(message, Encoding.UTF8, "application/json");

        //HttpResponseMessage responseMessage = await client.PostAsync(target, content);

        //lastResponse = await responseMessage.Content.ReadAsStringAsync();

        lastResponse = "true";
    }

    public static async void Get(string target)
    {
        //lastResponse = await client.GetStringAsync(target);
    }
}
