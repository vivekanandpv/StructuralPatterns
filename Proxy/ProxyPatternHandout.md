# Proxy Pattern


## Motivation
We want to provide a candidate object in lieu for a real object sometimes. The situations that require this may be lazy initialization, remoting, protection, or optimization. In such situations, dealing directly with the real object is not desirable, but we want a replacement that looks and feels like the real object, except it is not. When the delegation has to happen, may be after a due check, the replacement object relays the request to the actual object. The client doesn't know whether it is dealing with the real or replacement object, because both conform to the same interface.
***So, how can we provide the replacement for an object until the real action happens?*** -- This is the problem we solve.

## Definition
Provide a surrogate or placeholder for another object to control access to it.