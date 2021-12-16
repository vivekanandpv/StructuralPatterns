# Bridge Pattern


## Motivation
Creating an interface and implementing is the common theme in object oriented style of programming. Abstractions themselves cause inflexibility in the sense their evolution is hindered. If the abstraction is enhanced, the implementations that were designed before will break. One solution to this is the bridge pattern, where the interface is seen as a primary (high-level) and secondary (low-level) and thus is separated. Together these two constitute the bridge (between high and low levels of interfaces). The whole idea is to prevent growth of implementation classes and rather use composition to mitigate the problem
***So, how can we provide the replacement for an object until the real action happens?*** -- This is the problem we solve.

## Definition
Decouple an abstraction from its implementation so that the two can vary independently.