using OffersServiceGetRequests;

string endpoint = "";
string accessToken = "";

GetRequest get = new GetRequest(endpoint, accessToken);

await get.GetReq();