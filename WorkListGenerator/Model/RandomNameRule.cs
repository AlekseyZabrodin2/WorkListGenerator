using System;
using System.Collections.Generic;
using System.Text;

namespace WorkListGenerator.Model
{
    public sealed class RandomNameRule : IGeneratorRule<string>
    {
        private static readonly IDictionary<int, string> _rusName = new Dictionary<int, string>
        {
            {0, "Андрей"},
            {1, "Борис"},
            {2, "Виталик"},
            {3, "Георгий"},
            {4, "Дмитрий"},
            {5, "Егор"},
            {6, "Сергей"},
            {7, "Ярик"},
            {8, "Павел"},
            {9, "Марк"}


        };


        public string Generate()
        {
            Random random = new Random();

            var randomName = _rusName[random.Next(0, _rusName.Count)];

            return randomName;

        }
    }
}
