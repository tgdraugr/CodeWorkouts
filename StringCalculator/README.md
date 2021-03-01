# String Calculator

Create a simple string calculator with a method signature.

```c#
int Add(string numbers)
```

## Hints

- Start with the **simplest** test case of an **empty string** and **move to one and two numbers**;

- Remember to solve things as **simply as possible** so that you force yourself to write tests you did not think about;

- Remember to **refactor** after each passing test.

# Tasks

1. The method can take up to two numbers, separated by commas, and will return their sum. For example `""` or `"1"` or `"1,2"` as inputs (for an empty string it will return 0).

2. Allow the `Add` method to handle an unknown amount of numbers

3. Allow the `Add` method to handle new lines between numbers (instead of commas).
   1. Following input is ok: `1\n2,3` (will equal 6)
   2. Following input is NOT ok: `1,\n` (not need to prove it - just clarifying)

4. Support different delimiters. To change a delimiter, the beginning of the string will contain a separate line that looks like this: `//[delimiter]\n[numbers…]` for example `//;\n1;2` should return 3 where the default delimiter is `;`. The first line is optional. all existing scenarios should still be supported


5. Calling `Add` with a negative number will throw an exception with message “negatives not allowed” - and the negative that was passed.

6. If there are multiple negatives, show all of them in the exception message.

7. Numbers bigger than 1000 should be ignored, so adding 2 + 1001 = 2

8. Delimiters can be of any length with the following format: `//[delimiter]\n` for example: `//[***]\n1***2***3` should return 6

9. Allow multiple delimiters like this: `//[delim1][delim2]\n` for example `//[*][%]\n1*2%3` should return 6.

Make sure you can also handle multiple delimiters with length longer than one char.

_Retrieved from [here](https://osherove.com/tdd-kata-1/)_