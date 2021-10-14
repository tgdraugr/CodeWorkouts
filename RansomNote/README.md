# Ransom Note

Harold is a kidnapper who wrote a ransom note, but now he is worried it will be traced back to him through his handwriting. He found a magazine and wants to know if he can cut out whole words from it and use them to create an untraceable replica of his ransom note. The words in his note are case-sensitive and he must use only whole words available in the magazine. He cannot use substrings or concatenation to create the words he needs.

Given the words in the magazine and the words in the ransom note, print Yes if he can replicate his ransom note exactly using whole words from the magazine; otherwise, print No.

## Example
_magazine_ = "attack at dawn" _note_ = "Attack at dawn"

The magazine has all the right words, but there is a case mismatch. The answer is _No_.

## Function Description

Complete the `checkMagazine` function in the editor below. It must print _Yes_ if the note can be formed using the magazine, or _No_.

`checkMagazine` has the following parameters:

* `string magazine[m]`: the words in the magazine
* `string note[n]`: the words in the ransom note

### Output

Prints a string: either _Yes_ or _No_, no return value is expected.

### Input

The first line contains two space-separated integers,`m` and `n`, the numbers of words in the _magazine_ and the _note_, respectively.
The second line contains _m_ space-separated strings, each `magazine[i]`.
The third line contains _n_ space-separated strings, each `note[i]`.

### Constraints

* 1 <= _m_,_n_ <= 30000
* 1 <= length of `magazine[i]` and `note[i]` <= 5
* Each word consists of English alphabetic letters (_i.e._, `a` to `z` and `A` to `Z`).

## Samples

```
6 4
give me one grand today night
give one grand today
> Yes
```

```
6 5
two times three is not four
two times two is four
> No
```
* 'two' only occurs once in the magazine.

```
7 4
ive got a lovely bunch of coconuts
ive got some coconuts
> No
```
* Harold's magazine is missing the word.


_Retrieved from [here](https://www.hackerrank.com/challenges/ctci-ransom-note/problem)_