Readme doc for SuperHeroes solution

Points to note:

The solution is written in .Net core 2.2 sdk
The sdk can be downloaded from here if needed
https://dotnet.microsoft.com/download/archives

The api endpoint is https://localhost:5001/api/superheroes

This will return XML or JSON formatted response depending on the Accept attribute specified in the Header of the request call ie. Accept : application/xml

An object of type Character is returned which has a list of associated Villains and Superheroes
