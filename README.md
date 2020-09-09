# APITestingChallenge
API Testing with C# and SpecFlow in Visual Studio

Automation Tester Coding Challenge
Submitted by : Saraswathi Jayasree


Please find below the details about the framework I made for testing REST API features

This framework is Written using Gherkin syntax with Specflow extension in Visual Studio using C#.
It is an NUnit Testing Project on which the following libraries/dependancies were referenced

Libraries Used: 
1. For API automation- RestSharp 
2. For handling JSON serialization - Newtonsoft.Json
3. For incorporating BDD - SpecFlow, SpecFlow.NUnit, SpecFlow.Tools.MsBuild.Generation


Folder Structure:
1. Helpers Folder- Consists of Helper classes used for both Data comparison as well as handling API requests
2. Model Folder - For holding the Json Model classes and data classes
3. SpecFlowFeatures Folder - Contains Files written for each test case of API testing
4. SpecFlowSteps Folder - Contains files with Definitions for the Specflow feature files. Similar testcases are using a common step file.
5. APITests.cs - The class file for executing Testcases without using the SpecFlow


Ideally in a generic framework, the test data should be taken from a resource like CSV,excel file or JSon file.
As there was a time limitaion, priority was given to the requirements mentioned in the exercise.
I have however followed coding standards and documentation throughout. 


Thanks,
Saraswathi Jayasree
