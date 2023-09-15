# anonymous-forum
This Project was a school assignment.

### About the project
This is a simple anonymous forum where users can post and comment on posts.
It was build with csharp, asp.net with mvc and entity framework.

### How to run
Open the project in visual studio.
Create a Class Named CString in the root of the project with the following code:
```
public static string connectionString = "Data Source=CHANGEME; Initial Catalog=ForumDb;Integrated Security=true";
```
Change the Data Source to your sql server instance.
Optionally change the Initial Catalog to a name of ur choice.
Open the project in visual studio, open package manager console and run the command `update-database`.
Run the project.

### Contributors
* [Oliver Wasner](https://github.com/generalxo)
* [Danilo Acosta](https://github.com/Danilo-Acosta5389) 
* [Rickard Eriksson](https://github.com/rieerep)