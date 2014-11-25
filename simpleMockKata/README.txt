Goal
For this project we would like you to refactor the code in "someMethod()" to be more readable and less mistake prone.

Description
The method "someMethod()" in SomeClass uses the results of calls to "myThing" to determine it's output.
We need to find a way to control the behavior of those calls while this method is under test.
Since Thing implements the interface SomeInterfaceForThings and SomeClass uses SomeInterfaceForThings as it's type, perhaps we can pass in a mock object?  
