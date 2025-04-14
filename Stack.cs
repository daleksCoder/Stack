using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    public class Stack
    {
        private class StackItem(string value, StackItem? previous)
        {
            public string Value { get; } = value;
            public StackItem? Previous { get; } = previous;
        }

        public string? Top { get; private set; }
        public int Size { get; private set; }
        public bool IsEmpty { get; private set; } = true;
        private StackItem? TopNode { get; set; }

        public Stack()
        {
        }

        public Stack(string value)
        {
            AddNode(value, TopNode);
        }

        public Stack(params string[] strings)
        {
            foreach (var value in strings)
            {
                AddNode(value, TopNode);
            }            
        }

        public void Add(string value)
        {
            AddNode(value, TopNode);
        }

        private void AddNode(string value, StackItem? previousNode)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Значение элемента стека не может быть пустым", nameof(value));

            Top = value;
            TopNode = new StackItem(value, previousNode);
            Size++;
            IsEmpty = false;
        }

        public string Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");

            string result = TopNode!.Value;

            TopNode = TopNode.Previous;
            Top = TopNode?.Value;
            Size--;
            IsEmpty = TopNode is null;

            return result;
        }

        public static Stack CopyTo(Stack stack)
        {
            ArgumentNullException.ThrowIfNull(stack);

            var result = new Stack();

            AppendAllNodes(result, stack, false);

            return result;
        }

        public static Stack Concate(params Stack[] stacks)
        {
            ArgumentNullException.ThrowIfNull(stacks);

            var result = new Stack();
            foreach (var stack in stacks)
            {
                if (stack != null)
                {
                    AppendAllNodes(result, stack);
                }
            }
            return result;
        }

        private static void AppendAllNodes(Stack destination, Stack source, bool reverse = true)
        {
            ArgumentNullException.ThrowIfNull(destination);
            ArgumentNullException.ThrowIfNull(source);

            if (reverse)
            {
                var currentNode = source.TopNode;
                while (currentNode != null)
                {
                    destination.Add(currentNode.Value);
                    currentNode = currentNode.Previous;
                }
            }
            else
            {
                var tempStack = new Stack();
                var currentNode = source.TopNode;

                while (currentNode != null)
                {
                    tempStack.Add(currentNode.Value);
                    currentNode = currentNode.Previous;
                }

                while (tempStack.Size > 0)
                {
                    destination.Add(tempStack.Pop());
                }
            }
        }
    }
}