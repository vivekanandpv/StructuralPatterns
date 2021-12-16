# Facade Pattern


## Motivation
In a system when there are many complex but necessary interactions between the constituent objects, it is always desirable to provide a simple and unified interface that provides an abstraction over the underlying complexity. The idea is not to hide the complexity, but to provide a unified route separately. Client can choose to work with the unified interface or deal with low-level APIs. Such an interface is the facade (french for face)
***So, how can client work with a unified interface in a complex system?*** -- This is the problem we solve.

## Definition
Provide a unified interface to a set of interfaces in a subsystem. Facade defines a higher-level interface that makes the subsystem easier to use.