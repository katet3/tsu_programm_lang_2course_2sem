#include <iostream>
#include <list>

using namespace std;

class Node {
private:
    int key;
    Node *Left;
    Node *Right;
    friend class Ftree;

public:
    Node(int k = 0, Node *l = nullptr, Node *r = nullptr) {
        key = k;
        Left = l;
        Right = r;
    }

//    ~Node() {
//        key = 0;
//        Left = nullptr;
//        Right = nullptr;
//    }

    int getValueKey() {
        return key;
    }
};

class Ftree 
{
    protected:
        Node *root;
        
    public:
        Ftree() {
            root = nullptr;
        }

        Ftree(int len) 
        {
            root = nullptr;
            for(int i = 0; i < len; i++) {
                int value = rand() % 101;
                this->add(value);
            }
        }

        Ftree(int len, int *arr) 
        {
            root = nullptr;
            for(int i = 0; i < len; i++) {
                this->add(arr[i]);
            }
        }

        ~Ftree() {
            delTree(this->root);
        }

        void delTree(Node * node) 
        {
            if (node) {
                delTree(node->Left);
                delTree(node->Right);
                delete node;
            }
        }

        Node * addNode(Node *in, Node *from) 
        {
            if (!from) {
                return nullptr;
            }
            else {
                in = new Node(from->key);
                in->Left = addNode(in->Left, from->Left);
                in->Right = addNode(in->Right, from->Right);
                return in;
            }
        }

        Ftree &operator = (const Ftree &tree) 
        {
            if (this == &tree) {
                return *this;
            }
            else {
                delTree(this->root);
                root = addNode(this->root, tree.root);
            }
            return *this;
        }

        Ftree(Ftree &ftree) {
            Copy(this->root, ftree.root);
        }

        void Copy(Node*& x, Node* y) 
        {
            if (y) {
                x = new Node(y->key);
                Copy(x->Left, y->Left);
                Copy(x->Right, y->Right);
            }
            else {
                x = nullptr;
            }
        }

        void add(int value) 
        {
            if (root == nullptr) {
                root = new Node(value);
                return;
            }
            Node *node = root;
            while (true) {

                if (node->key > value && node->Left == nullptr) {
                    node->Left = new Node(value);
                    return;
                }
                else if (node->key <= value && node->Right == nullptr) {
                    node->Right = new Node(value);
                    return;
                }
                if (node->key > value)
                    node = node->Left;
                else
                    node = node->Right;
            }
        }

        Node * search(int value) {
    //        if (root == nullptr) {
    //            return nullptr;
    //        }
            Node * node = root;
            while (true) {
                if (node == nullptr) {
                    return nullptr;
                }
                if (node->key == value) {
                    return node;
                }

    //            else if (value < node->key && node->Left == nullptr) {
    //                return nullptr;
    //            }
    //            else if (value > node->key && node->Right == nullptr) {
    //                return nullptr;
    //            }

                if (value < node->key) {
                    node = node->Left;
                }
                else if (value > node->key) {
                    node = node->Right;
                }
    //            if (node == nullptr) {
    //                return nullptr;
    //            }
            }
        }
        Node * min() {
            if (root == nullptr) {
                return nullptr;
            }
            Node * node = root;
            while (node->Left != nullptr) {
                node = node->Left;
            }
            return node;
        }
        Node * max() {
            if (root == nullptr) {
                return nullptr;
            }
            Node * node = root;
            while (node->Right != nullptr) {
                node = node -> Right;
            }
            return node;
        }

        void print() {
            printTree(1, this->root);
            cout << endl;
        }
        void printTree(int indent, Node *node) {
            if (node != nullptr) {
                printTree(indent + 5, node->Right);
                for(int i = 0; i < indent; i++) {
                    cout << " ";
                }
                cout << node->key << endl;
                printTree(indent + 5, node->Left);
            }
        }

        void LKR(Node *node = nullptr) {
            if (node == nullptr) {
                node = root;
            }
            if (node->Left) {
                LKR(node->Left);
            }
            cout << node->key << " ";
            if (node->Right) {
                LKR(node->Right);
            }
        }

        Node * Delete(int k) {
            Node *current = root;
            Node *parent = nullptr;
            Node *s;
            Node *r;


            while (current && current->key != k) {
                parent = current;
                if (current->key > k)
                    current = current->Left;
                else
                    current = current->Right;
            }


            if (!current) {
                cout << "error"; exit(0);
            }


            else if (current->Left == nullptr)
                if (parent && parent->Left == current) {
                    parent->Left = current->Right;
                    delete current;
                    return  parent->Left;
                } else if (parent && parent->Right == current){
                    parent->Right = current->Right;
                    delete current;
                    return parent->Right;
                }
                else {
                    s = current->Right;
                    root = s;
                    return root;
                }


            else if (current -> Right == nullptr){
                if (parent && parent->Left == current){
                    parent->Left = current->Left;
                    delete current;
                    return parent->Left;
                } else if (parent && parent->Right == current){
                    parent->Right = current->Left;
                    delete current;
                    return parent->Right;
                } else {
                    s = current->Left;
                    root = s;
                    return root;
                }
            }


            s = current->Right;
            if (s->Left == nullptr){
                current->key = s->key;
                current->Right = s->Right;
                delete s;
                return current;
            }
            while (s->Left != nullptr){
                r =s;
                s=s->Left;
            }
            current->key = s->key;
            r->Left = s->Right;
            delete s;
            return current;
        }


        void BFSprint() {
            BFS(this->root);
            cout << endl;
        }

        void BFS(Node *root) {
            std::list<Node *> Nodes(1, root);
            while (!Nodes.empty()) {
                Node *node = Nodes.front();
                cout << node->key << " ";
                if (node->Left) {
                    Nodes.push_back(node->Left);
                }
                if (node->Right) {
                    Nodes.push_back(node->Right);
                }
                Nodes.pop_front();
            }

        }

};




int main() {
    Ftree tree(10);
    tree.print();

    cout << "-----------------------------------" << endl;
    tree.add(100);
    tree.print();


    cout << "poisk: " << endl;
    Node * first = tree.search(41);
    Node * second = tree.search(80);
    Node * third = tree.search(68);

    cout << first->getValueKey() << " " << second->getValueKey() << " " << third->getValueKey() << endl;

    Node *min = tree.min();
    Node *max = tree.max();
    cout << "min and max: " << endl << min->getValueKey() << " " << max->getValueKey() << endl;

    cout << endl << endl;
    cout << "LKR: ";
    tree.LKR(); cout << endl;
    cout << "BFS: ";
    tree.BFSprint();
    cout << endl;

    cout << "-----------------------------------" << endl;
    cout << "-----------------------------------" << endl;
    Ftree treeCopy;
    treeCopy = tree;
    treeCopy.print();
    cout << "-----------------------------------" << endl;
    treeCopy.Delete(41);
    treeCopy.print();
    cout << "-----------------------------------" << endl;

    Ftree tree1(tree);
    tree1.print();
    return 0;
}



