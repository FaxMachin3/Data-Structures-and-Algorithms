inputLength = input()
inputData = input()

data = list(map(int, inputData.split()))

def largestArea(data):
    areas = [0] * len(data)
    stack = []
    greatest = 0  # The max area
    topOfStack = 0  # To store the top of stack
    areaWithTop = 0  # To store area with top bar as the smallest bar

    i = 0
    while i < len(data):
        if not stack or (data[stack[0]]) <= data[i]:
            stack.insert(0, i)
            i += 1
        else:
            topOfStack = stack.pop(0)
            minStack = i if not stack else i - stack[0] - 1
            areaWithTop = data[topOfStack] * minStack

            greatest = areaWithTop if areaWithTop > greatest else greatest

    while stack:
        topOfStack = stack.pop(0)
        minStack = i if not stack else i - stack[0] - 1
        areaWithTop = data[topOfStack] * minStack
        greatest = areaWithTop if areaWithTop > greatest else greatest

    print(greatest)

largestArea(data)