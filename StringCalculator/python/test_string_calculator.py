""" String Calculator tests """

import unittest
import string_calculator as calc

class FirstStepTests(unittest.TestCase):
    def test_empty_string_input(self):
        self.assertEqual(0, calc.add(""))
        self.assertEqual(0, calc.add(" "))

    def test_one_string_input(self):
        self.assertEqual(1, calc.add("1"))
        self.assertEqual(2, calc.add("2"))

    def test_two_string_input(self):
        self.assertEqual(3, calc.add("1,2"))
        self.assertEqual(6, calc.add("2,4"))


class SecondStepTests(unittest.TestCase):
    def test_unknown_amount_input(self):
        self.assertEqual(6, calc.add("1,2,3"))
        self.assertEqual(4, calc.add("1,1,1,1"))
        self.assertEqual(6, calc.add("1,1,1,1,2"))


class ThirdStepTests(unittest.TestCase):
    def test_newline_between_numbers_input(self):
        self.assertEqual(6, calc.add("1\n2,3"))
        self.assertEqual(6, calc.add("1,2\n3"))
        self.assertEqual(12, calc.add("1,2\n3\n1,2,3"))


class FourthStepTests(unittest.TestCase):
    def test_different_delimiters(self):
        self.assertEqual(3, calc.add("//;\n1;2"))
        self.assertEqual(6, calc.add("//;\n1;2\n3"))
        self.assertEqual(6, calc.add("//;1;2\n3"))
        self.assertEqual(6, calc.add("//;1\n2\n3"))


class FifthStepTests(unittest.TestCase):
    def test_with_negative_number(self):
        with self.assertRaises(Exception) as context:
            calc.add("//;\n-1")
        self.assertTrue("Negatives not allowed: -1" in str(context.exception))


class SixthStepTests(unittest.TestCase):
    def test_with_several_negative_numbers(self):
        with self.assertRaises(Exception) as context:
            calc.add("//;\n-1;-2")
        self.assertTrue("Negatives not allowed: [-1, -2]" in str(context.exception))


class SeventhStepTests(unittest.TestCase):
    def test_numbers_bigger_than(self):
        self.assertEqual(2, calc.add("//;\n1001;2"))
        self.assertEqual(1002, calc.add("//;\n1000;2"))
        self.assertEqual(2, calc.add("//;\n2;1001"))
        self.assertEqual(6, calc.add("//;\n2;1001;1;3"))


class EighthStepTests(unittest.TestCase):
    def test_any_length_delimiter(self):
        self.assertEqual(6, calc.add("//[***]\n1***2***3"))
        self.assertEqual(10, calc.add("//[+]\n1+2+3+4"))
        self.assertEqual(10, calc.add("//[..]\n1..2\n3..4"))


class NinthStepTests(unittest.TestCase):
    def test_multiple_delimiters(self):
        self.assertEqual(6, calc.add("//[*][%]\n1*2%3"))
        self.assertEqual(10, calc.add("//[a][x][..]\n1a2..3x4"))


unittest.main()