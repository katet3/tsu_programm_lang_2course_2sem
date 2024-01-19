#include <iostream>
#include <list>

using namespace std;


class Node{
	friend class Tree;
	private:
		int key = 0;
		int value = 0;
		Node* left = nullptr;
		Node* right = nullptr;
	
	
	public:
        Node(){}
		Node(int key, int value){this->value = value; this->key = key;}

		
        int get_key(){return key;}
        int get_value(){return value;}


};


class Tree{
    private:
        Node* head = nullptr;

    public:
        Tree(){}
        Tree(int key, int value){head = new Node(key, value);}
        Tree(Tree& tree)
        {
            copy_nodes(this->head, tree.head);
        }
        Tree(int count) 
        {
            head = nullptr;
            for(int i = 0; i < count; i++) {
                int key = rand() % 101;
                int value = rand() % 101;
                this->insert(key, value);
            }
        }
        ~Tree(){this->delete_tree();}


    public:
        void insert(int key, int value) 
        {
            if (head == nullptr) {
                head = new Node(key, value);
                return;
            }

            Node* current = head;
            while (true) {

                if (key < current->key && current->left == nullptr) {
                    current->left = new Node(key, value);
                    return;
                }
                else if (key >= current->key && current->right == nullptr) {
                    current->right = new Node(key, value);
                    return;
                }
                if (key < current->key)
                    current = current->left;
                else
                    current = current->right;
            }
        }
		
		
		Node* delete_node(int k) 
		{
            Node *current = head;
            Node *parent = nullptr;
            Node *s;
            Node *r;


            while (current && current->key != k) 
            {
                parent = current;
                if (current->key > k)
                    current = current->left;
                else
                    current = current->right;
            }


        if (!current) {
            cout << "Key not found!" << endl; 
            return nullptr;
        }


        else if (current->left == nullptr)
        {
            if (parent && parent->left == current) {
                parent->left = current->right;
                delete current;
                return  parent->left;
            } 
            else if (parent && parent->right == current){
                parent->right = current->right;
                delete current;
                return parent->right;
            }
            else {
                s = current->right;
                head = s;
                delete s;
                return head;
            }
        }


        else if (current->right == nullptr)
        {
            if (parent && parent->left == current){
                parent->left = current->left;
                delete current;
                return parent->left;
            } 
            else if (parent && parent->right == current){
                parent->right = current->left;
                delete current;
                return parent->right;
            } 
            else {
                s = current->left;
                head = s;
                delete s;
                return head;
            }
        }


        s = current->right;
        if (s->left == nullptr){
            current->key = s->key;
            current->value = s->value;
            current->right = s->right;
            
            delete s;
            return current;
        }
        while (s->left != nullptr){
            r = s;
            s = s->left;
        }
        current->key = s->key;
        current->value = s->value;

        r->left = s->right;
        delete s;
        return current;
    }
		

        void delete_tree()
        {
            delete_tree_recursion(head);
            head = nullptr;
        }

/*       
        void print_tree()
        {
            print_tree_recursion(head);
        }
*/

        Tree &operator = (const Tree& tree) 
        {
            if (this == &tree) {
                return *this;
            }
            else {
                delete_tree_recursion(this->head);
                head = copy_nodes(this->head, tree.head);
            }
            return *this;
        }


        Node* min() 
        {
            if (head == nullptr) 
            {
                return nullptr;
            }
            
            Node * current = head;
            while (current->left != nullptr) 
            {
                current = current->left;
            }
            
            return current;
        }


        Node* max() 
        {
            if (head == nullptr) 
            {
                return nullptr;
            }
            
            Node * current = head;
            while (current->right != nullptr) 
            {
                current = current->right;
            }
            
            return current;
        }


        Node* search(int key) 
        {
            if (head == nullptr) 
            {
                return nullptr;
            }

            Node* current = head;
            while (true) 
            {
                if (current == nullptr) {
                    return nullptr;
                }
                if (current->key == key) {
                    return current;
                }

                if (key < current->key) {
                    current = current->left;
                }
                else if (key > current->key) {
                    current = current->right;
                }

            }
        }

/*
        void copy(Node*& in, Node* from) 
        {
            if (from) {
                in = new Node(from->key, from->value);
                copy(in->left, from->left);
                copy(in->right, from->right);
            }
            else {
                in = nullptr;
            }
        }
*/

        void print_tree() 
        {
            print_tree_recursion(1, this->head);
            cout << endl;
        }


        void BFS_print() 
        {
            BFS(this->head);
            cout << endl;
        }


        void LKR_print() 
        {
            LKR(this->head);
            cout << endl;
        }        


    private:
    /*
        void print_tree_recursion(Node* node)
        {
            if(node == nullptr) return;
            print_tree_recursion(node->left);
            cout << node->key << " ";
            print_tree_recursion(node->right);
        }
    */
        
        
        void print_tree_recursion(int space, Node* node) 
        {
            if (node != nullptr) {
                print_tree_recursion(space + 5, node->right);
                for(int i = 0; i < space; i++) 
                {
                    cout << " ";
                }
                cout << node->key << endl;
                print_tree_recursion(space + 5, node->left);
            }
        }


        void delete_tree_recursion(Node* node) 
        {
            if (node) {
                delete_tree_recursion(node->left);
                delete_tree_recursion(node->right);
                delete node;
            }
        }


        Node* copy_nodes(Node*& in, Node* from) 
        {
            if (from == nullptr) {
                return nullptr;
            }
            else {
                in = new Node(from->key, from->value);
                in->left = copy_nodes(in->left, from->left);
                in->right = copy_nodes(in->right, from->right);
                return in;
            }
        }


        void BFS(Node* node) 
        {
            std::list<Node* > Nodes(1, node);
            while (!Nodes.empty()) 
            {
                Node* current = Nodes.front();
                cout << current->key << " ";
                if (current->left) {
                    Nodes.push_back(current->left);
                }
                if (current->right) {
                    Nodes.push_back(current->right);
                }
                Nodes.pop_front();

            }

        }


        void LKR(Node* node) 
        {
            if (node->left) {
                LKR(node->left);
            }

            cout << node->key << " ";
            
            if (node->right) {
                LKR(node->right);
            }
    }

};




int main()
{
    Tree tree(10);
    tree.print_tree();

    cout << endl;
    tree.insert(100, 100);
    tree.print_tree();
    cout << "-----------------" << endl;


    cout << endl << "poisk: " << endl;
    Node* first = tree.search(32);
    Node* second = tree.search(44);
    Node* third = tree.search(51);

    if(first)
        cout << "first search: " << first->get_key() << endl;
    if(second)
        cout << "second search: " << second->get_key() << endl;
    if(third)
        cout << "third search: " << third->get_key() << endl;


    Node* min = tree.min();
    Node* max = tree.max();
    cout << "min and max: " << endl << min->get_key() << " " << max->get_key() << endl;
    cout << endl;

    cout << "LKR: ";
    tree.LKR_print();
    cout << endl    ;

    cout << "BFS: ";
    tree.BFS_print();
    cout << endl;


    Tree treeCopy;
    treeCopy = tree;
    treeCopy.print_tree();
    cout << "-----------------" << endl;


    treeCopy.delete_node(100);
    treeCopy.print_tree();
    cout << "-----------------" << endl;


    Tree tree1(tree);
    tree1.print_tree();
    cout << "-----------------" << endl;
    tree1.delete_tree();
    tree.print_tree();


    return 0;
}