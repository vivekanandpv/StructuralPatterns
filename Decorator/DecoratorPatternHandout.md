# Decorator Pattern


## Motivation
Objects in C++/C# cannot be added with additional functionalities post creation. For example, a document object cannot be added with additional (but related) functionality of framing. One solution is to subclass the document and add the functionality in the subclass. But this approach tends to create a lot of classes. Decorator pattern provides a technique to attach additional functionality without subclassing. It does so by composition. No doubt the additional functionalities are contained in their  own classes, but the necessity to subclass is removed.
***So, how can we add additional functionality to an object that is not in its class?*** -- This is the problem we solve.

## Definition
Attach additional responsibilities to an object dynamically. Decorators provide a flexible alternative to subclassing for extending functionalities. 