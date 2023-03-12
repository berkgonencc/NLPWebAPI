# NLP – Character to Number Conversion ( for Turkish Characters )

- MVC Web API method takes one string text input.
- The method can handle connected words.
- It works in the range of 0 to billion. ( expandable to cover large numbers )
- Related string input is sent by POST operation in JSON format.
- ie. input:

	{ 
		"UserText": "Seksen 7 bin iki 100 on altı lira borcum var, bin elli beş lira daha verirsen eğer seksensekizbin271 olur" 
	} 	

- The text data sent by POST is processed in the API method, and the numbers written in the sentence are converted to numeric format.
- ie. output:

	{ 
		"Output": "87216 lira borcum var, 1055 lira daha verirsen eğer 88271 olur" 
	}

## Technologies Used:
C#, .Net 6.0, MVC Web API, Visual Studio 2022

## How to set up and run this project:
- The project is developed with .NET 6.0 so the mentioned C# .Net version must be installed.
- Open the .sln file and run the project.
- And, can be tested by sending the post method via the Swagger.
