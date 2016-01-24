####Question 1.

It took about 5 hours to write the whole test code and implement the feature in methods. As I am familiar with TDD and first test approach, I finished  both the unit test and implementing each method very early. But I had to spend time for integration test with Console Application as I haven't tested console application in integration test before. For that reason it took slightly longer than anticipated.

I also believe that there are two improvements that could be made to the work.

1. Thread: If I had more time to spend on the work, I would have implemented an asynchronous feature on RestaurantService to prevent halting the system by accessing the api server.

2. Cache: Before calling directly the api, we can store the result by outcode in our cache system.


####Question 2.

In C#5.0, the most useful feature is async/await keyword. I believe async/await have a bigger impact than LINQ. It allows developer to adopt asynchronous programming easily like node.js. Those keywords async/await are just an indication to the compiler so it can refactor the code. 
Here's an example: 
```c#
public async Task DoSomethingAsync()
{
  // In the Real World, we would actually do something...
  // For this example, we're just going to (asynchronously) wait 100ms.
  await Task.Delay(100);
}
```

####Question 3.

Speaking from my back-end experience, I normally used to check hardware status first. Then if servers’ CPUs are 100% and they may be caused by just users’ traffic, we can solve them with adjusting precise elastic configuration on cloud service or extending the hardware. Otherwise, if the database’s usage is very high, we can check internal locks’ count on database to analyze whether there are a lot of waiting existing on the database. If there are many locks, they may be deadlocks or caused by a lot of load to database that are made from update/insert work or inquiring data without using the back-end cache systems.

When I worked at Samsung, we adopted a micro-service architecture which allowed us to divide the big databases and services to smaller ones. If there are “select” work, we tried to deal with memory cache rather than accessing db directly. To update/delete work, we adopted a messaging queue system to relieve the locking tables from simultaneous big traffic.


####Question 4.

1. There isn’t error handling logic when outcode is wrong or there is no result from the outcode.
2. To generate optimized Json size, rather than sending the whole restaurants’ properties, the apis can provide an option to choose the properties from end users.
3. In restaurant api, there’s no way to check what the rating maximum value is.


####Question 5.

```Json
{
  "Name": "Kyunghoon Park",
  "NickName": "KH",
  "Keywords" : [
    "passionate",
    "humble",
    "challenging"
    ]
  "Programming": {
    "Languages": [
      "C#",
      "Ruby",
      "Objective-C",
      "Javascript"
    ],
    "Frameworks": [
      "ASP.NET",
      "Rails",
      "JQuery",
      "Bootstrap",
      "React.js"
    ]
  },
  "Interests": [
    "Computer Games",
    "New Business",
    "Pubbing"
  ]
}
```
