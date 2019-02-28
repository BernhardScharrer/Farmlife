using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for HttpClient
using System.Net.Http;

// for StreamReader
using System.IO;

// for Encoding
using System.Text;
using Newtonsoft.Json;

// for HttpWebRequest
using System.Net;



public class ServerComm : MonoBehaviour
{

    //	-----------------------------------------------
    //	HttpClient
    //	-----------------------------------------------
    public static HttpClient client { get; private set; }


    //	-----------------------------------------------
    //	HttpWebRequest
    //	-----------------------------------------------
    private static HttpWebRequest request;


    //	-----------------------------------------------
    //	general
    //	-----------------------------------------------
    private static string postTarget = "https://fforganizer.at/farmlife/farmlife.php";
    public static string lastResponse { get; private set; }


    void Start()
    {
        client = new HttpClient();

        request = (HttpWebRequest)WebRequest.Create(postTarget);
        request.KeepAlive = false;
        request.ProtocolVersion = HttpVersion.Version10;
    }

    public static async void Post(string message)
    {
        // create a HttpContent out of the given message
        HttpContent content = new StringContent(message, Encoding.UTF8, "application/json");

        // post content to postTarget
        HttpResponseMessage responseMessage = await client.PostAsync(postTarget, content);
        Debug.Log(responseMessage.StatusCode);

        // await response from server and save responsemessage to lastResponse
        lastResponse = await responseMessage.Content.ReadAsStringAsync();
    }

    public static void PostWebRequest(object message)
    {
        //	-----------------------------------------------
        //	convert object to json
        //	-----------------------------------------------
        Debug.Log("Converting message object to json format ...");

        string dataString = JsonConvert.SerializeObject(message);

        Debug.Log("Done conversion!");



        //	-----------------------------------------------
        //	set up request
        //	-----------------------------------------------
        request.ContentType = "application/json";
        request.Method = "POST";



        

        //	-----------------------------------------------
        //	post data to postTarget
        //	-----------------------------------------------
        Debug.Log("Posting data to server ...");
        

        using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(dataString);
            streamWriter.Close();
        }
        

        Debug.Log("Done posting!");



        //	-----------------------------------------------
        //	get response from server
        //	-----------------------------------------------
        Debug.Log("Getting response from server ...");

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        
        Debug.Log("Got response!");

        Stream responseStream = response.GetResponseStream();
        
        //	-----------------------------------------------
        //	something with response
        //	-----------------------------------------------
        Debug.Log("Reading response ...");

        using (StreamReader streamReader = new StreamReader(responseStream))
        {
            Debug.Log("Length: " + responseStream.Length);
            lastResponse = streamReader.ReadToEnd();
        }

        Debug.Log("Read response!");
        
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
