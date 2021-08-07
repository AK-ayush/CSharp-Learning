## C# Fundamental : Pluralsight

30-30-40 principle

.NET => CLR(common language runtime) + FCL(framework class library) OR BCL(base)

`dll` files very much similar to `jar` files. they are assembly generated after the build process.

string interpellation : `$" some string{ var}";`

passing a parameter using cli : `dotnet run -- param`

create project using a specific sdk : `dotnet new <project-name> --sdk-version 3.1.101`

Arrays in C# are fixed length.

`System.Collections.Generics`  is collection of DS some dynamics.

Opposite of `static` are object instance members.	

By default, any new class is an `internal` class, visible only in it's project/assembly.

`public` member always has uppercase name.

By default, all the agrs are passed by value in C#. Object variable are reference var, they store the location of memory allocated. to pass by reference use `ref` before the datatype of arg at both the place. Alternative to `ref` keyword is to use `out` keyword but then in the calling method, you must set the some value to it.

In dotnet, `string` are immutable though they defined as `class` 

dotnet service provides a automatic garbage collector.

`readonly` member can be set during initialization or in the constructor.

`const` member can be set during initialization only not even in constructor. As a convention, they are all uppercase variable name. and they behave like static variable. in order to access it you need to use the class name rather than object name.

`delegate` is a type.

```C#
public delegate void GradeAddedDelegate(object sender, EventArgs args);
```



Pillers of OOP: `Encapsulation` + `Inheritence` + `Ploymorphism`



###  Access Modifier

https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers