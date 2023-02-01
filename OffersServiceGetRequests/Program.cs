using OffersServiceGetRequests;

GetRequest get = new GetRequest("https://jsonplaceholder.typicode.com/posts/1");

await get.GetReq(100);