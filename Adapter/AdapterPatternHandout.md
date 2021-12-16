# Adapter Pattern


## Motivation
Client code works with an abstraction, but the need is to make another object (which doesn't abide by this abstraction) workable. This may be the result of system evolution, or a design choice. Adapter pattern solves this problem by creating a connection layer between the client's primary interface and the object in question. There are two variants: one uses the composition technique (called object adapter) and the other uses the inheritance (called class adapter). The client works with adapter which in turn uses either composition (object adapter) or inheritance to reach to the object in question.
***So, how can client work with a non-conforming object?*** -- This is the problem we solve.

## Definition
Convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn't otherwise because of incompatible interfaces.