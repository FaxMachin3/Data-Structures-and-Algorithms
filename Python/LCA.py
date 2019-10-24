import queue


class Node:
    def __init__(self, info):
        self.info = info
        self.left = None
        self.right = None
        self.level = None

    def __str__(self):
        return str(self.info)


class BinarySearchTree:
    def __init__(self):
        self.root = None

    def create(self, val):
        if self.root == None:
            self.root = Node(val)
        else:
            current = self.root

            while True:
                if val < current.info:
                    if current.left:
                        current = current.left
                    else:
                        current.left = Node(val)
                        break
                elif val > current.info:
                    if current.right:
                        current = current.right
                    else:
                        current.right = Node(val)
                        break
                else:
                    break


# Enter your code here. Read input from STDIN. Print output to STDOUT
'''
class Node:
      def __init__(self,info): 
          self.info = info  
          self.left = None  
          self.right = None 
           

       // this is a node of the tree , which contains info as data, left , right
'''

parent = [i for i in range(100)]
size = [1 for i in range(100)]
pathV1 = [Node(0)] * 100
pathV2 = [Node(0)] * 100


def find(a):
    root = a
    while(parent[root] != root):
        root = parent[root]
    while(a != root):
        temp = parent[a]
        parent[a] = root
        a = temp
    return root


def union(a, b):
    x = find(a)
    y = find(b)

    if(x == y):
        return

    if(size[x] > size[y]):
        parent[y] = x
        size[x] += 1
    else:
        parent[x] = y
        size[y] += 1


def lca(root, v1, v2):
    while(root != None):
        if(v1 > root.info and v2 > root.info):
            root = root.right
        elif(v1 < root.info and v2 < root.info):
            root = root.left
        else:
            break
    return root


tree = BinarySearchTree()
t = 15

arr = [8,4,2,1,3,6,5,7,10,14,15,9,12,11,13]

for i in range(t):
    tree.create(arr[i])

v = [15,11]

ans = lca(tree.root, v[0], v[1])
print(ans.info)
