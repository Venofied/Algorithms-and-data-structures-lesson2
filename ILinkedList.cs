using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson2
{
    public interface ILinkedList
    {
        //int GetCount(); // возвращает количество элементов в списке
        int GetCount(Node _node)
        {
            int count = 0;
            while(_node != null)
            {
                count++;
                _node = _node.NextNode;
            }
            return count;
        }
        void AddNode(Node _node, int value) // добавляет новый элемент списка
        {
            var node = _node;

            while (node.NextNode != null)
            {
                node = node.NextNode;
            }

            var newNode = new Node { Value = value };
            node.NextNode = newNode;
        }
        void AddNodeAfter(Node node, int value) // добавляет новый элемент списка после определённого элемента
        {
            var newNode = new Node { Value = value };
            var nextItem = node.NextNode;
            node.NextNode = newNode;
            newNode.NextNode = nextItem;
        }
        void RemoveNode(Node node, int index) // удаляет элемент по порядковому номеру
        {
            if (index == 0)
            {
                var newStartNode = node.NextNode;
                node.NextNode = null;
                return;
            }

            int currentIndex = 0;
            var currentNode = node;
            while (currentNode != null)
            {
                if (currentIndex == index - 1)
                {
                    RemoveNode(currentNode);
                    return;
                }

                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            return;
        }
        void RemoveNode(Node node) // удаляет указанный элемент
        {
            if (node.NextNode == null)
                return;

            var nextItem = node.NextNode.NextNode;
            node.NextNode = nextItem;
        }
        Node FindNode(Node node, int searchValue) // ищет элемент по его значению
        {
            var currentNode = node;

            while (currentNode != null)
            {
                if (currentNode.Value == searchValue)
                    return currentNode;

                currentNode = currentNode.NextNode;
            }

            return null;
        }
    }
}
