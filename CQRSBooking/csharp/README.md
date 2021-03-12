# Implementation Details

The solution was developed using an approach of _Ports & Adapters architecture_ (aka, [Hexagonal architecture](https://en.wikipedia.org/wiki/Hexagonal_architecture_(software))), as described by Alistair Cockburn [on this video](https://www.youtube.com/watch?v=th4AgBcrEHA&t=1s).

## Solution
Each port, is an interface that describes its intent. An adapter can be any class that implements the behaviour.

* __Core__. Contains the domain rules and interactions.
* __Infrastructure__. Implements the adapters, connectors to the "real world".

## Conclusion
It seems a cool approach, with nice scalability and ease of development. On the other hand, it kind of "grinds my gears" to have such specific/isolated interfaces. The ports kind of look like _Clean Architecture_'s UseCase/Interactor objects.
This architecture seems a fit to use with Domain-Driven Design, as the outside world can be mapped out into ports.
Could be a good idea to develop the same solution with a different mindset towards the Hexagonal approach.