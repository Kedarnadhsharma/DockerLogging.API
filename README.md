	
  Logging in Docker Containers :
  
  Traditionally, Logging is used to troubleshoot, analyze and also most recently for exploration purposes as well. Also in enterprise applications in .NET both logging and 
  exception handling are handled at a Global level. In .NET core this can be achived by adding a Custom Middleware exception handling and adding the appropriate HTTP status codes 
  for these exceptions.
  
  There are different ways we can implement Logging in .NET Core applications.
  
  a. Using the standard ILogger interface implementation: This implementation involves adding a dependency injection pattern to inject the Logger object for each and every class.
  b. Using third party tools like SeriLog --> Uses a static implementation and no need to use of DI pattern.

Using ILogger : 
  
  
  
  
