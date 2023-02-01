using OffersServiceGetRequests;

string endpoint = "";
string accessToken = "";
int numTasks = 100;

Task[] tasks = new Task[numTasks];

for (int i = 0; i < numTasks; i++)
{
    GetRequest request = new GetRequest(endpoint, accessToken);
    tasks[i] = request.GetReq();
}
await Task.WhenAll(tasks);



