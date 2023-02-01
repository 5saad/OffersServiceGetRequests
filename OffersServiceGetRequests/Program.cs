using OffersServiceGetRequests;

string endpoint = "";
string accessToken = "";

Task[] tasks = new Task[100];

for (int i = 0; i < 100; i++)
{
    GetRequest request = new GetRequest(endpoint, accessToken);
    tasks[i] = request.GetReq();
}
await Task.WhenAll(tasks);



