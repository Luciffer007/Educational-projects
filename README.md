# Sorting/Tree Library

These are educational libraries, designed to show my knowledge of the basics of C #.
The namespace "Sort" ([Sort.cs](https://github.com/Luciffer007/Educational-projects/blob/master/Sort.cs) and [Helper.cs](https://github.com/Luciffer007/Educational-projects/blob/master/Helper.cs)) contains a [Bubble Sort](https://en.wikipedia.org/wiki/Bubble_sort) method (complexity of О(n<sup>2</sup>)) and a [Quicksort](https://en.wikipedia.org/wiki/Quicksort) method (complexity of O(n log n)).
The namespace "BinaryTree" ([Trees.cs](https://github.com/Luciffer007/Educational-projects/blob/master/Trees.cs)) contains Binary Sort and Search Trees.

## Bubble Sort

``` C#
SortingAlgorithms.BubbleSort(array, direction);
```

* **array** - _double[]_ - your sorted array;
* **direction** - _SortingDirection_ - array sorting direction. SortingDirection - enumeration with the values of Asc and Desc;

## Quicksort

``` C#
SortingAlgorithms.QuickSort(array, firstElement, lastElement); 
```

* **array** - _double[]_ - your sorted array;
* **firstElement** - _int_ - index of the beginning of the array being sorted;
* **lastElement** - _int_ - index of the end of the array being sorted;

## Binary Sort/Search Tree

### Creating a binary tree:

``` C#
BinarySortTree binaryTree = new BinarySortTree(value);
```

**or**

``` C#
BinarySearchTree binaryTree = new BinarySearchTree(value);
```

* **value** - _long_ - the value of the root node of the tree;

### Adding new nodes to a tree:

``` C#
binaryTree.Insert(nodeValue, binaryTree.Root);
binaryTree.Insert(nodeValues);
```

* **nodeValue** - _long_ - value of the tree node being added;
* **nodeValues** - _long[]_ - array of value of the tree nodes being added;

### Search for a tree node with a given value (return instance of the BinaryTreeNode class):

``` C#
binaryTree.Find(nodeValue, binaryTree.Root);
```

* **nodeValue** - _long_ - the searched value of the node;

An instance of the BinaryTreeNode class contains the following properties:

* **Data** - _long_ - value of the tree node;
* **Parent** - _BinaryTreeNode_ - reference to the parent node;
* **Left** - _BinaryTreeNode_ - reference to the left child node;
* **Right** - _BinaryTreeNode_ - reference to the right child node;

All these properties are read-only.

### Deleting a tree node:

``` C#
binaryTree.Delete(node);
```

* **node** - _BinaryTreeNode_ - removable tree node;
