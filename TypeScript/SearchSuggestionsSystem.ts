// LeetCode 1268: Search Suggestions System
// After sorting, build: O(S). Search: O(m). Trie space: O(S).
// S is the total length of the product names, and m is the search word length.

class TrieNode {
    children = new Map<string, TrieNode>();
    suggestions: string[] = [];
}

class Trie {
    private readonly root = new TrieNode();

    insert(product: string): void {
        let node = this.root;

        for (const char of product) {
            let child = node.children.get(char);

            if (child === undefined) {
                child = new TrieNode();
                node.children.set(char, child);
            }

            if (child.suggestions.length < 3) {
                child.suggestions.push(product);
            }

            node = child;
        }
    }

    suggest(searchWord: string): string[][] {
        const results: string[][] = [];
        let node: TrieNode | undefined = this.root;

        for (const char of searchWord) {
            node = node?.children.get(char);
            results.push(node ? [...node.suggestions] : []);
        }

        return results;
    }
}

function suggestedProducts(products: string[], searchWord: string): string[][] {
    const trie = new Trie();

    for (const product of products.sort()) {
        trie.insert(product);
    }

    return trie.suggest(searchWord);
}
