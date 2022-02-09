# Arithmetics

Durance got tired of learning spells and sorting bags and decided to invest in papicoins, the newest cryptocurrency (we don't judge). In order to do so, he has to learn how to read the records of transactions. Durance promised us a percentage of the profits so let's help!

## Goal

Create an application that helps Durance read the transactions of the cryptocurrency.
The transactions are arithmetic operations wrapped by parentheses. In case a record is invalid, we should let Durance know with an "Invalid record" error message.

## Rules

* All of the operations are wrapped in parentheses
* There is an even number of parentheses
* Spaces can be considered as separators (to help identify negative numbers)
* If only parenthesis are provided, return 0 (consider the other rules)
* Operations should follow PEMDAS precedence rules (Parentheses, Exponents, Multiplication/Division, Addition/Subtraction)

```
( 1 + ( ( 2 + 3 ) * (4 * 5) ) ) -> 101
( 5 * ( 4 * ( 3 * ( 2 * ( 1 * 9 ) / 8 - 7 ) + 6 ) ) ) -> -165
((()())) -> 0
3 + ( 2 * 1 ) -> Invalid record error
```

_Retrieved from [here](https://katalyst.codurance.com/arithmetics)_