using Cryptography.Helpers;
using Cryptography.Interface;
using System;

namespace Cryptography.Algorithms
{
    public class BifidCipher : ICipher
    {
        private string _EncryptionKey;
        private PolybiusSquare _Scheme;

        public BifidCipher(string encryptionKey = "")
        {
            UpdateKey(encryptionKey);
        }

        private void UpdateKey(string keyword)
        {
            _EncryptionKey = keyword;
            _Scheme = new PolybiusSquare(_EncryptionKey);
        }

        public void ChangeEnrcryptionKey(string keyword)
        {
            UpdateKey(keyword);
        }

        #region DECODE

        public string Decode(string value)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ENCODE
        public string Encode(string value)
        {
            var removedValue = RegexHelper.RemoveSpecialMarks(value);
            var letterCords = EncodeGetLettersCords(removedValue);
            var rows = EncodeGetRows(letterCords);
            var encoded = EncodeRows(rows);

            return encoded;
        }

        private int[,] EncodeGetLettersCords(string value)
        {
            var markCords = new int[value.Length, 2];
            int index = 0;
            var polybiusSquare = _Scheme.Get();

            foreach (var mark in value)
            {
                for (int i = 0; i < polybiusSquare.GetLength(0); i++)
                {
                    for (int j = 0; j < polybiusSquare.GetLength(1); j++)
                    {
                        if (polybiusSquare[i, j] == mark)
                        {
                            markCords[index, 0] = i;
                            markCords[index, 1] = j;
                        }
                    }
                }
                index++;
            }

            return markCords;
        }

        private int[] EncodeGetRows(int[,] letterCords)
        {
            var rows = new int[letterCords.GetLength(0)];
            int maxIndex = letterCords.GetLength(0);
            int currentIndex = 0;
            int dimensionIndex = 0;
            int rowIndex = 0;
            int tempValue = -1;

            while (true)
            {
                if (maxIndex == currentIndex)
                {
                    dimensionIndex++;
                    currentIndex = 0;
                    continue;
                }

                if (dimensionIndex > 1)
                {
                    break;
                }

                if (tempValue == -1)
                {
                    tempValue = letterCords[currentIndex, dimensionIndex];
                }
                else
                {
                    var tempRow = $"{tempValue}{letterCords[currentIndex, dimensionIndex]}";
                    rows[rowIndex] = Int32.Parse(tempRow);
                    rowIndex++;
                    tempValue = -1;
                }

                currentIndex++;
            }
            return rows;
        }

        private string EncodeRows(int[] rows)
        {
            var encodedWord = new char[rows.Length];
            var polybiusSquare = _Scheme.Get();

            for (int i = 0; i < rows.Length; i++)
            {
                var tempRowCords = rows[i].ToString().Length == 2 ? rows[i].ToString() : $"0{rows[i]}";
                int firstCord = Int32.Parse(tempRowCords[0].ToString());
                int secondCord = Int32.Parse(tempRowCords[1].ToString());
                var letter = polybiusSquare[firstCord, secondCord];

                encodedWord[i] = letter;
            }

            return string.Join("", encodedWord);
        }
        #endregion
    }
}