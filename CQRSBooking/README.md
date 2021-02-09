# CQRS Booking

You should implement a simple booking solution with CQRS architecture.

## About CQRS

CQRS for Command Query Responsibility Segregation Pattern.

A query returns data and does not alter the state of the object. A command changes the state of an object but it does not return any data.

Split code in read and write code to really live to this pattern.

## Booking Subject

We want to make a booking solution for one hotel.\
The first 2 users stories are:

* As an user I want to see all free rooms.
* As an user I want to book a room.

A `Booking` is defined by:
* room name
* arrival date
* departure date

The `Room` is defined by:
* room name

## Sources
* [Inspiration source of this kata](https://github.com/tpierrain/CQRS/)
* [Explanation of CQRS by Microsoft](https://docs.microsoft.com/en-us/previous-versions/msp-n-p/jj591573(v=pandp.10))

_Adapted from [here](https://codingdojo.org/kata/CQRS_Booking/)_