This web application is written in Angular and DotNet Core. On the main page you will see the information about Covid new cases, new deaths daily and total cases for each states. 
Follow these steps to run the web application:
1) Download and extract the source code.
2) Open the command promp with administrator mode, change directory to the folder: "CovidData-master\Covid.Web\ClientApp", run the command "npm install".
3) In command promp, change directory back to "CovidData-master\Covid.Web" and run the command: "dotnet restore", after that run the command: "dotnet build".
4) Change directory back to CovidData-master and run: "dotnet run --project Covid.Web/Covid.Web.csproj".
5) Open Chrome and type this url: "https://localhost:5001/".
6) If you see the screen below, click the button "Advance".

![1](https://user-images.githubusercontent.com/48367218/102268647-926f4580-3ee9-11eb-90a4-da8ba68b99e0.PNG)

And then click "Proceed to localhost (unsafe)" .

![2](https://user-images.githubusercontent.com/48367218/102268940-f134bf00-3ee9-11eb-8966-ec539bcfd743.PNG)

7) On the landing page, click "Get Covid Data" button, it will take up to a minute to retrive data from the API.
![3](https://user-images.githubusercontent.com/48367218/102269187-496bc100-3eea-11eb-9824-93130cd4ff9a.PNG)

Completed page will look like this:
![4](https://user-images.githubusercontent.com/48367218/102269578-d9116f80-3eea-11eb-97e3-1ff5b12c77c7.PNG)

