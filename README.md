	
  Logging in Docker Containers :
  
  Traditionally, Logging is used to troubleshoot, analyze and also most recently for exploration purposes as well. Also in enterprise applications in .NET both logging and 
  exception handling are handled at a Global level. In .NET core this can be achived by adding a Custom Middleware exception handling and adding the appropriate HTTP status codes 
  for these exceptions.
  
  There are different ways we can implement Logging in .NET Core applications.
  
  a. Using the standard ILogger interface implementation: This implementation involves adding a dependency injection pattern to inject the Logger object for each and every class.
  ![image](https://user-images.githubusercontent.com/50028950/143679317-1db1cc00-476b-4f3c-815b-4c22b05cf265.png)

  b. Using third party tools like SeriLog --> Uses a static implementation and no need to use of DI pattern.
  ![image](https://user-images.githubusercontent.com/50028950/143679347-a9d13c56-efd0-4285-888e-9bdb4d8c5ce5.png)
  ![image](https://user-images.githubusercontent.com/50028950/143679355-175eb0af-dd5b-4830-b097-8a818cfbb679.png)
 
 The advantage with SeriLog is we can customize/enrich the content as we need and also use the option of writing the logs to other desitnations as well like cloud provider storage (AWS Cloud Watch/Azure Table Storage/Seq). Here we are using Seq as the other desitnation.
  
 Now if we assume this API to be running in a Docker Container, then writing the logs outside of the container makes more sense as the logs will be available even after the container is lost or exited because of errors. Writing logs outside of the containers and also to additional destinations with different cloud providers will provide insights to the applications. 

Details of the Repo :

1. This is a simple ASP.NET Core Web API project that was built using the default VS 2019 template and added the Docker Support.
2. Add SeriLog.AspnetCore, SeriLog.Enrichers.Environment, SeriLog.Sinks.Seq Nuget Packages to the solution. (https://github.com/serilog/serilog/wiki/)
3. Pull the Seq docker image and run it locally on the machine using the below commands


    docker pull datalust/seq
    docker run --name seq -d --restart unless-stopped -e ACCEPT_EULA=Y -p 5341:80 datalust/seq:latest
    
    
 4. Now we need to tell the SeriLog to also write the logs to one additional desitation by specifying the Seq URL as below. (See last but one line Writeto.Seq method.)
 
 ![image](https://user-images.githubusercontent.com/50028950/143679557-ace35575-42cd-45d3-aa20-0d7423647e36.png)
 
 
 
 5. Now if you run your application and execute the APIs in the Swagger try out option, you can see the same logs appearing in Seq as well.
 
 From VS 2019 Debug Console : 
 
 ![image](https://user-images.githubusercontent.com/50028950/143679730-6f676742-a755-4674-9a95-672fc1fdbe03.png)
 
 From Seq : (http://localhost:5341)
 
 
 ![image](https://user-images.githubusercontent.com/50028950/143679778-9771b19a-ebf8-4a7e-a798-2cc6d4ae4076.png)
 


 ![image](https://user-images.githubusercontent.com/50028950/143679684-aa12eacd-5684-4bf0-9da5-0fb31ab01331.png)



  
  
  
  

