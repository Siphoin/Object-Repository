### Object Repository System for Unity
A lightweight and type-safe object repository system for Unity that provides efficient object tracking and retrieval.

## Features
Type-Safe Repositories: Create and manage repositories for any component type

Automatic Registration: Objects automatically register/unregister themselves when enabled/disabled

Efficient Lookups: Quickly find all instances of a given type without scene traversal

IEnumerable Support: All repositories support LINQ operations

Minimal Boilerplate: Easy to implement with just a few lines of code

Core Components
ObjectRepository<T>
The generic repository class that stores and manages collections of objects by type.

RepositoryObjectRegister<T>
A MonoBehaviour that automatically registers/unregisters components with their appropriate repository when enabled/disabled.


Usage Example
1. Create your component
```csharp
[RequireComponent(typeof(UnitRepositoryRegister))]
public class Unit : MonoBehaviour
{
    // Your unit implementation
}

```
2. Create the register (can be empty)
```csharp
public class UnitRepositoryRegister : RepositoryObjectRegister<Unit>
{
}

```
3. Find objects from anywhere
```csharp
public class Finder : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.V))
        {
            var units = this.FindObjectsOfTypeOnRepository<Unit>();
            Debug.Log(units.Count());
        }
    }
}
```

Extension Methods
The system includes a useful extension method:

``` csharp
public static IEnumerable<T> FindObjectsOfTypeOnRepository<T>(this Component component)
{
    return ObjectRepository.GetInstance<T>();
}
```
Performance Benefits
Avoids expensive FindObjectsOfType calls

Objects are immediately available when enabled

Clean removal when objects are disabled/destroyed

No need to manually manage lists of objects.


### Installation

import unitypackage from Releases.
