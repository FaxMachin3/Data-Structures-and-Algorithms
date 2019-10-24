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


def checkBST(root):
	return check(root,-float("inf"),float("inf"))

def check(n,min,max):
	if(n==None):
		return True
	if(n.info <= min or n.info >= max):
		return False
	return check(n.left, min, n.info) and check(n.right, n.info, max)

tree = BinarySearchTree()
t = 15

arr = [8,4,2,1,3,6,5,7,10,14,15,9,12,11,13]

for i in range(t):
    tree.create(arr[i])

v = [15,11]

ans = checkBST(tree.root)
print(ans)