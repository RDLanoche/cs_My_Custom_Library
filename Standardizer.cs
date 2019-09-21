using System;
using System.Collections.Generic;

namespace StringManipulator
{
    public static class Standardizer
    {
        private static string CapitalizeFirstLetterFirstWord(string str)
        {
            if (str.Length <= 0)
                return "";
            str.Trim();
            char firstChar = str[0];
            if (_alphabetDictionary.TryGetValue(firstChar, out char capitalLetter))
            {
                firstChar = capitalLetter;
            } //End if
            string newString = firstChar + str.Substring(1);
            return newString;
        } //End CapitalizeFirstLetterFirstWord

        public static void CapitalizeFirstLetterFirstWord(ref string originalString, out string modifiedString)
        {
            modifiedString = string.Empty;
            if (originalString.Length <= 0)
            {
            }
            else
            {
                originalString.Trim();
                char firstChar = originalString[0];
                if (_alphabetDictionary.TryGetValue(firstChar, out char capitalLetter))
                {
                    firstChar = capitalLetter;
                } //End if
                modifiedString = firstChar + originalString.Substring(1);
                
            } //End if...else
        } //End CapitalizeFirstLetterFirstWord

        public static void PascalwithSpaces(ref string originalString, out string modifiedString)
        {
            string newString;
            LowerCaseAllWords(ref originalString, out newString);
            modifiedString = string.Empty;

            char firstChar = newString[0];
            if (_alphabetDictionary.TryGetValue(newString[0], out char upperCaseChar))
            {
                firstChar = upperCaseChar;
            } //End if

            for (int i = 1; i < newString.Length; i++)
            {
                char c = newString[i];

                if (newString[i-1] == ' ' && char.IsLetter(newString[i]) )
                {
                    if (_alphabetDictionary.TryGetValue(newString[i], out char upperCaseChar2))
                    {
                        c = upperCaseChar2;
                    } //End if...else
                } //End if...else

                modifiedString += c;
            } //End for
            modifiedString = string.Concat(firstChar, modifiedString);
        } //End PascalwithSpaces

        public static void Pascal(ref string originalString, out string modifiedString)
        {
            string newString;
            LowerCaseAllWords(ref originalString, out newString);
            modifiedString = string.Empty;
            string[] strArray = newString.Split(' ');
            foreach(string s in strArray)
            {
                modifiedString += CapitalizeFirstLetterFirstWord(s);
            } //End foreach
        } //End Pascal

        public static void LowerCaseAllWords(ref string originalString, out string modifiedString)
        {
            modifiedString = string.Empty;
            Dictionary<char,char> invertedDictionary = new Dictionary<char, char>();

            foreach(KeyValuePair<char,char> pair in _alphabetDictionary)
            {
                invertedDictionary.Add(pair.Value, pair.Key);
            } //End foreach

            foreach (char c in originalString)
            {
                char.ToUpper(c);
                if (invertedDictionary.TryGetValue(c, out char lowerCaseLetter))
                {
                    modifiedString += lowerCaseLetter;
                } //End if
                else
                    modifiedString += c;
            } //End foreach
            modifiedString.Trim();

        } //End LowerCaseAllWords

        public static void AllCaps(ref string originalString, out string modifiedString)
        {
            modifiedString = string.Empty;

            foreach (char c in originalString)
            {
                char.ToLower(c);
                if (_alphabetDictionary.TryGetValue(c, out char UpperCaseLetter))
                {
                    modifiedString += UpperCaseLetter;
                } //End if
                else
                    modifiedString += c;
            } //End foreach
            modifiedString.Trim();
        } //End AllCaps

        public static void ReduceToSingleSpaces(ref string originalString, out string modifiedString)
        {
            string[] stringArray = originalString.Split(' ');
            modifiedString = string.Empty;
            foreach (string s in stringArray)
            {
                if (s.Length == 0)
                { }
                else
                {
                    s.Trim();
                    modifiedString += s + ' ';
                } 
            }
            modifiedString.TrimEnd(' ');
        }

        private static readonly Dictionary<char, char> _alphabetDictionary =
            new Dictionary<char, char>
        {
            { 'a','A' }, { 'b','B' }, { 'c','C' }, { 'd','D' }, { 'e','E' },
            { 'f','F' }, { 'g','G' }, { 'h','H' }, { 'i','I' }, { 'j','J' },
            { 'k','K' }, { 'l','L' }, { 'm','M' }, { 'n','N' }, { 'o','O' },
            { 'p','P' }, { 'q','Q' }, { 'r','R' }, { 's','S' }, { 't','T' },
            { 'u','U' }, { 'v','V' }, { 'w','W' }, { 'x','X' }, { 'y','Y' },
            { 'z','Z' }
        };

    } //End Standarizer

}// End namespace InputHandler
