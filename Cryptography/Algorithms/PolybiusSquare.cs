using System;
using System.Collections.Generic;
using System.Text;

namespace Cryptography.Algorithms
{
    public class PolybiusSquare
    {
        private string _EncryptionKey;

        /// <summary>
        ///  Polybius Latin I=J 5x5
        /// </summary>
        private char[,] _Scheme = new char[,]
        {
            { 'A', 'B', 'C', 'D', 'E' },
            { 'F', 'G', 'H', 'I', 'K' },
            { 'L', 'M', 'N', 'O', 'P' },
            { 'Q', 'R', 'S', 'T', 'U' },
            { 'V', 'W', 'X', 'Y', 'Z' }
        };

        public PolybiusSquare(string encryptionKeyword = "")
        {
            SetKey(encryptionKeyword);
        }

        public void SetKey(string encryptionKeyword)
        {
            _EncryptionKey = encryptionKeyword;
            Update();
        }

        public char[,] Get()
        {
            return _Scheme;
        }

        private void Update()
        {
            if(!string.IsNullOrEmpty(_EncryptionKey))
            {
                var tempScheme = new char[5,5];
                var usedChars = new List<char>();
                int indexX = 0;
                int indexY = 0;

                foreach(var letter in _EncryptionKey)
                {
                    char tempLetter = letter;

                    if (letter == 'J')
                    {
                        tempLetter = 'I';
                    }

                    if(indexX == 5)
                    {
                        indexX = 0;
                        indexY++;
                    }

                    if(indexX == 5 && indexY == 5)
                    {
                        break;
                    }

                    if(!usedChars.Contains(letter))
                    {
                        tempScheme[indexY, indexX] = letter;
                        indexX++;
                        usedChars.Add(letter);
                    }
                }

                FillRest(ref tempScheme, usedChars);
                _Scheme = tempScheme;
            }
        }

        private void FillRest(ref char[,] tempScheme, List<char> usedChars)
        {
            for(int i = 0; i<tempScheme.GetLength(0);i++)
            {
                for(int j=0; j<tempScheme.GetLength(1);j++)
                {
                    if(tempScheme[i,j] == '\x0000')
                    {
                        for(char c = 'A'; c <= 'Z'; c++)
                        {
                            if (c == 'J')
                            {
                                continue;
                            }

                            if(!usedChars.Contains(c))
                            {
                                tempScheme[i, j] = c;
                                usedChars.Add(c);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
