using OffersServiceGetRequests;
using System;

string endpoint = "https://funapnftfdoff0101.azurewebsites.net/api/v1/getOffers?";

Uri uri = new Uri(endpoint);
string url = uri.GetLeftPart(UriPartial.Authority);

GetToken token = new GetToken(url);
string accessToken =token.GrabToken();

int numTasks = 100;

Task[] tasks = new Task[numTasks];

while (true)
{
    for (int i = 0; i < numTasks; i++)
    {
        PostRequest request = new PostRequest(endpoint, accessToken);
        tasks[i] = request.PostReq();
    }
    await Task.WhenAll(tasks);
}



