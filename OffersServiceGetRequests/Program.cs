using OffersServiceGetRequests;

string endpoint = "";
string accessToken = "";
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



