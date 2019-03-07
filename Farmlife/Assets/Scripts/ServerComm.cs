using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for HttpClient
using System.Net.Http;

// for StreamReader
using System.IO;

// for Encoding
using System.Text;

// for HttpWebRequest
using System.Net;

// for UnityWebRequest
using UnityEngine.Networking;

public class ServerComm : MonoBehaviour
{

    ////	-----------------------------------------------
    ////	HttpClient
    ////	-----------------------------------------------
    //public static HttpClient client { get; private set; }


    ////	-----------------------------------------------
    ////	HttpWebRequest
    ////	-----------------------------------------------
    //private static HttpWebRequest request;


    ////	-----------------------------------------------
    ////	general
    ////	-----------------------------------------------
    //private static string postTarget = "https://fforganizer.at/farmlife/farmlife.php";
    //public static string lastResponse { get; private set; }
    
    //private static object actMessage;


    void Start()
    {

        //client = new HttpClient();

        //string response = SendJsonRequest("{\"test\": \"Hello world!\"}");
        //Debug.Log(response);

    }

    void Update()
    {
        //StartCoroutine(PostRequest());
    }

    //public static string SendJsonRequest(string json)
    //{
    //    string responseMessage = string.Empty;
    //    string url = @"https://fforganizer.at/farmlife/farmlife.php?json=" + json;

    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    //    request.AutomaticDecompression = DecompressionMethods.GZip;
    //    request.Method = "GET";
    //    request.ContentType = "application/json";

    //    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
    //    using (Stream stream = response.GetResponseStream())
    //    using (StreamReader reader = new StreamReader(stream))
    //    {
    //        responseMessage = reader.ReadToEnd();
    //    }

    //    return responseMessage;
    //}

    //public static async void Post(string message)
    //{
    //    // create a HttpContent out of the given message
    //    HttpContent content = new StringContent(message, Encoding.UTF8, "application/json");

    //    // post content to postTarget
    //    HttpResponseMessage responseMessage = await client.PostAsync(postTarget, content);
    //    Debug.Log(responseMessage.StatusCode);

    //    // await response from server and save responsemessage to lastResponse
    //    lastResponse = await responseMessage.Content.ReadAsStringAsync();
    //}

    //public static void PostWebRequest(object message)
    //{
    //    //	-----------------------------------------------
    //    //	convert object to json
    //    //	-----------------------------------------------
    //    Debug.Log("Converting message object to json format ...");

    //    string dataString = JsonConvert.SerializeObject(message);

    //    Debug.Log("Done conversion!");



    //    //	-----------------------------------------------
    //    //	set up request
    //    //	-----------------------------------------------
    //    request.ContentType = "application/json";
    //    request.Method = "POST";



        

    //    //	-----------------------------------------------
    //    //	post data to postTarget
    //    //	-----------------------------------------------
    //    Debug.Log("Posting data to server ...");
        

    //    using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
    //    {
    //        streamWriter.Write(dataString);
    //        streamWriter.Close();
    //    }


    //    using (StreamWriter streamWriter = new StreamWriter(logFile))
    //    {
    //        streamWriter.Write("Sent: " + dataString);
    //        streamWriter.Close();
    //    }


    //    Debug.Log("Done posting!");



    //    //	-----------------------------------------------
    //    //	get response from server
    //    //	-----------------------------------------------
    //    Debug.Log("Getting response from server ...");

    //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        
    //    Debug.Log("Got response!");

    //    Stream responseStream = response.GetResponseStream();
        
    //    //	-----------------------------------------------
    //    //	something with response
    //    //	-----------------------------------------------
    //    Debug.Log("Reading response ...");

    //    using (StreamReader streamReader = new StreamReader(responseStream))
    //    {
    //        lastResponse = streamReader.ReadToEnd();
    //    }

    //    Debug.Log("Read response!");
        
    //}

    //public static void PostUnityWebRequest(object message)
    //{
    //    actMessage = message;
    //}
    
    //private static IEnumerator PostRequest()
    //{
    //    if (actMessage != null)
    //    {
    //        //	-----------------------------------------------
    //        //	Convert message object to json string
    //        //	-----------------------------------------------
    //        Debug.Log("Converting message object to json string ...");
    //        string jsonMessage = JsonUtility.ToJson(actMessage);
    //        Debug.Log("Converted message object to json string!");


    //        //	-----------------------------------------------
    //        //	Prepare for post
    //        //	-----------------------------------------------
    //        // set url
    //        Debug.Log("Setting target url and method ...");
    //        var request = new UnityWebRequest(postTarget, "POST");
    //        Debug.Log("Set target url and method!");

    //        // convert json string to byte array
    //        Debug.Log("Converting json string to byte array ...");
    //        byte[] bodyRaw = new System.Text.UTF8Encoding().GetBytes(jsonMessage);
    //        Debug.Log("Converted json string to byte array!");

    //        // set content
    //        Debug.Log("Creating upload handler ...");
    //        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(bodyRaw);
    //        Debug.Log("Created upload handler!");

    //        // get stuff
    //        Debug.Log("Creating buffer for download handler ...");
    //        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    //        Debug.Log("Created buffer for download handler!");

    //        // send content type
    //        Debug.Log("Setting request header ...");
    //        request.SetRequestHeader("Content-Type", "application/json");
    //        Debug.Log("Set request header!");



    //        //	-----------------------------------------------
    //        //	Wait for response
    //        //	-----------------------------------------------
    //        Debug.Log("Waiting for response ...");
    //        yield return request.SendWebRequest();
    //        Debug.Log("Got response!");



    //        //	-----------------------------------------------
    //        //	See if there was an Error
    //        //	-----------------------------------------------
    //        if (request.isNetworkError)
    //        {
    //            Debug.Log("Something went wrong, and returned error: " + request.error);
    //        }
    //        else
    //        {
    //            Debug.Log("Response: " + request.downloadHandler.text);
    //            lastResponse = request.downloadHandler.text;
    //        }

    //        actMessage = null;
    //    }
    //}

    public static string Get(object message)
    {

        //	-----------------------------------------------
        //	Convert message object to json string
        //	-----------------------------------------------
        Debug.Log("Converting message object to json string ...");
        string jsonMsg = JsonUtility.ToJson(message);
        Debug.Log("Done conversion!" + jsonMsg);



        //	-----------------------------------------------
        //	Create url for get
        //	-----------------------------------------------
        Debug.Log("Creating url from json string ...");
        string url = @"https://fforganizer.at/farmlife/farmlife.php?json=" + jsonMsg;
        Debug.Log("Created url!");



        //	-----------------------------------------------
        //	Setup for get
        //	-----------------------------------------------
        Debug.Log("Setting up web request ...");
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.AutomaticDecompression = DecompressionMethods.GZip;
        request.Method = "GET";
        request.ContentType = "application/json";
        Debug.Log("Done setup!");



        //	-----------------------------------------------
        //	Call get and wait for response
        //	-----------------------------------------------
        Debug.Log("Communicating with server ...");
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using (Stream responseStream = response.GetResponseStream())
        using (StreamReader responseReader = new StreamReader(responseStream))
        {
            string responseMsg = responseReader.ReadToEnd();
            Debug.Log("Got response: " + responseMsg);
            return responseMsg;
        }
    }
}

