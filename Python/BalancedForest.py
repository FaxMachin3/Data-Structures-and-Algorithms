#!/bin/python3

import math
import os
import random
import re
import sys
from collections import deque
# Complete the balancedForest function below.
# Step 1: Create adjacency table
class Node:
    def __init__(self, value, nid):
        self.val = value
        self.children = []
        self.cost = value
        self.nid = nid
        
def constructTree(v, e):
    l_v = len(v)
    
    tbl = {i:[] for i in range(l_v)}
    discovered = [None for i in range(l_v)]    # 0-based

    for src, des in e:
        src -= 1                # 1-base -> 0-base
        des -= 1                # 1-base -> 0-base
        tbl[src].append(des)
        tbl[des].append(src)

    # Step 2: Initialize root node
    discovered[0] = Node(v[0], 0)
    stack = deque([(False, 0)])    # (type, id_zerob)

    # Step 3: Traversal and create root cost
    while stack:
        flag_agg, curr_id = stack.pop()
        if flag_agg:
            # At this moment, all child node's cost are already
            # computed, so just sum them up.
            # Leaf node will keep the cost unchanged.
            pnode = discovered[curr_id]
            for cnode in pnode.children:
                pnode.cost += cnode.cost
        else:
            # Append aggregate flag
            stack.append((True, curr_id))
            # Append available childrens
            for adj_id in tbl[curr_id]:
                if discovered[adj_id] is None:
                    tmp_newnode = discovered[adj_id] = Node(v[adj_id], adj_id)
                    discovered[curr_id].children.append(tmp_newnode)
                    stack.append((False, adj_id))
    # Return root node
    return discovered[0]

_MAX_COST = 5 * (10 ** 13) + 1
def aux_traversal(root, size):
    best = _MAX_COST
    stack = deque([root])
    path_table = [False for _ in range(size)]
    path_table[0] = True

    # Two types of data will occur in the stack:
    # | Node => Do general traversal and label path
    # | int  => Means we're leaving this node, and
    #           remove it from label path
    while stack:
        cur_node = stack.pop()
        if type(cur_node) == int:
            path_table[cur_node] = False
        else:
            path_table[cur_node.nid] = True
            stack.append(cur_node.nid)      # Insert exit flag
            for chd_node in cur_node.children:
                target_root = root.cost - chd_node.cost
                target_split = chd_node.cost
                # Corresponds to cases (3), (1), (2) in description above
                res_equal = target_root if target_root == target_split else _MAX_COST
                res_root = best_split(root, target_split, chd_node.nid, path_table)
                res_split = best_split(chd_node, target_root)
                best = min(best, res_equal, res_root, res_split)
                if best == 0:
                    return 0
                stack.append(chd_node)
    return best if best < _MAX_COST else -1

def best_split(root, target, exclude=None, path=None):
    # root:    Root node of the tree to be traversed
    # target:  Target cost
    # exclude: Node ID of excluded subtree's root node
    # path:    Table for traversed path. Used to deduct cost of
    #          excluded sub-tree

    # Total cost of current tree

    whole_cost = root.cost - (target if exclude is not None else 0)

    # (1) If current tree's cost is more than two times of target
    #     cost, then you need to insert negative value in order to
    #     balance them, which is not valid for our task.
    # (2) If current tree's cost is less than target, then you'll
    #     need at least two nodes to balance any cut. (Think of the
    #     case where you insert a node with cost as target, then
    #     separate it and leave the original tree along. You'll 
    #     still need another node to balance this tree.)
    # (3) Also, we've already talked about tie case in
    #     aux_traversal() so we skip it as well.

    if whole_cost > target * 2 or whole_cost <= target:
        return _MAX_COST

    best = _MAX_COST
    stack = deque([root])

    while stack:
        cur_node = stack.pop()
        for chd_node in cur_node.children:
            if chd_node.nid != exclude:
                sub_cost = chd_node.cost - (target if path and path[chd_node.nid] else 0)
                root_cost = whole_cost - sub_cost
                # If we can find an even split, then do early exit
                if root_cost == sub_cost == target:
                    return 0
                # Otherwise, find out if one of them is balanced
                elif root_cost == target and sub_cost < target:
                    best = min(best, target - sub_cost)
                elif sub_cost == target and root_cost < target:
                    best = min(best, target - root_cost)
                # TODO: Any other possible PRUNING strategy?
                stack.append(chd_node)
    return best

def balancedForest(tree_values, tree_edges):
    t = constructTree(tree_values, tree_edges)
    return aux_traversal(t, len(tree_values))
    
if __name__ == '__main__':
    c = [1, 2, 2, 1, 1]

    edges = [[1, 2], [1, 3], [3, 5], [1, 4]]

    result = balancedForest(c, edges)

    print(str(result))

# 2
# 5
# 1 2 2 1 1
# 1 2
# 1 3
# 3 5
# 1 4
# 3
# 1 3 5
# 1 3
# 1 2
