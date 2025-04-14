using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Stack.Stack;

namespace Stack
{
    public static class StackExtensions
    {
        /// <summary>
        /// Примечание для преподавателя: в данной реализации поддерживается парадигма расширения исходного класса без знания и модификации его внутреннего устройства. 
        /// Для этого используются только открытые методы класса Stack. При этом поддержка данной парадигмы в текущей архитектуре стека приводит
        /// к некоторому дублированию и усложнению кода. Альтернативным же вариантом может служить открытие метода AppendAllNodes исходного класса Stack в публичный доступ
        /// и реализация метода - расширения Merge в виде обертки над данным методом.
        /// </summary>
        public static void Merge(this Stack destination, Stack source)
        {
            ArgumentNullException.ThrowIfNull(destination);
            ArgumentNullException.ThrowIfNull(source);

            var tempStack = Stack.CopyTo(source);

            while (tempStack.Size > 0)
            {
                destination.Add(tempStack.Pop());
            }
        }
    }
}