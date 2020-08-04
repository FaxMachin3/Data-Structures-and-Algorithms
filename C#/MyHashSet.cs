using System;
using System.Collections.Generic;
public class MyHashSet {
    private struct Slot {
        public int hashCode;
        public int next;
        public int value;
    }

    private IEqualityComparer<int> comparer;
    private Slot[] slots;
    private int[] lists;
    private int count;
    private int next;
    private int n;

    public MyHashSet () {
        comparer = EqualityComparer<int>.Default;
        slots = new Slot[11];
        lists = new int[11];
        n = 11;
        count = 1;
        next = 0;
    }
    public void Add (int value) {
        var hashCode = GetHashCode (value);

        for (int i = lists[hashCode % n]; i > 0; i = slots[i].next) {
            if (comparer.Equals (value, slots[i].value))
                return;
        }

        int index;

        if (next == 0) {
            if (count == slots.Length)
                Resize ();
            index = count++;
        } else {
            index = next;
            next = slots[index].next;
        }

        var listIndex = hashCode % n;

        slots[index].hashCode = hashCode;
        slots[index].value = value;
        slots[index].next = lists[listIndex];

        lists[listIndex] = index;
    }

    public void Remove (int value) {
        var hashCode = GetHashCode (value);
        var listIndex = hashCode % n;

        for (int i = lists[listIndex], last = 0; i > 0; last = i, i = slots[i].next) {
            if (comparer.Equals (value, slots[i].value)) {
                if (last == 0) {
                    lists[listIndex] = slots[i].next;
                } else {
                    slots[last].next = slots[i].next;
                }

                slots[i].value = default;
                slots[i].hashCode = -1;
                slots[i].next = next;

                next = i;
                return;
            }
        }
    }

    public bool Contains (int value) {
        var hashCode = GetHashCode (value);
        for (int i = lists[hashCode % n]; i > 0; i = slots[i].next) {
            if (comparer.Equals (value, slots[i].value))
                return true;
        }
        return false;
    }

    private int GetHashCode (int value) {
        return comparer.GetHashCode (value) & 0x7FFFFFFF;
    }

    private void Resize () {
        n = count * 2 + 1;
        var newLists = new int[n];
        var newSlots = new Slot[n];

        Array.Copy (slots, 0, newSlots, 0, count);

        for (int i = 1; i < count; i++) {
            var listIndex = newSlots[i].hashCode % n;
            newSlots[i].next = newLists[listIndex];
            newLists[listIndex] = i;
        }

        slots = newSlots;
        lists = newLists;
    }

}

// public class TestSet {
//     public static void Main (string[] args) {
//         MyHashSet hashSet = new MyHashSet ();
//         hashSet.Add (1);
//         hashSet.Add (2);
//         Console.WriteLine (hashSet.Contains (1)); // returns true
//         Console.WriteLine (hashSet.Contains (3)); // returns false (not found)
//         hashSet.Add (2);
//         Console.WriteLine (hashSet.Contains (2)); // returns true
//         hashSet.Remove (2);
//         Console.WriteLine (hashSet.Contains (2)); // returns false (already removed)
//     }
// }