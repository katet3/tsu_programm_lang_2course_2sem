#include <iostream>

using namespace std;


class Node{
	friend class Tree;
	private:
		int key = 0;
		int value = 0;
		Node* left = nullptr;
		Node* right = nullptr;
	
	
	public:
        Node(){key = 0; value = 0; left = nullptr; right = nullptr;}
		Node(int key, int value){this->value = value; this->key = key;}

		
        int get_key(){return key;}
        int get_value(){return value;}

/*
	    friend ostream& operator << (ostream& out, Node& node)
        {
            out << node.key << " ";
            out << node.value;
            out << endl;
            return out;
        }
*/
};


class Tree{
    private:
        Node* head = nullptr;

    public:
        Tree(){head = new Node(0, 0);}
        Tree(int key, int value){head = new Node(key, value);}
        Tree(Tree& tree)
        {
            head = insert_node_recursion(this->head, tree.head);
        }
        ~Tree(){this->delete_tree();}


    public:
        void insert(int key, int value)
		{
            insert_recursion(head, key, value);
		}
		
		
		Node* get_min()
		{
		    return get_min_recursion(head);
		}
		
		
		Node* get_max()
		{
		    return get_max_recursion(head);
		}
		
		/*
		Node* delete_node(int key)
		{
			return delete_recursion(head, key);
		}
		*/
		
		
		Node* Delete(int k) 
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
            //exit(0);
        }


        else if (current->left == nullptr)
        {
            if (parent && parent->left == current) {
                parent->left = current->right;
                delete current;
                return  parent->left;
            } else if (parent && parent->right == current){
                parent->right = current->right;
                delete current;
                return parent->right;
            }
            else {
                s = current->right;
                head = s;
                return head;
            }
        }


        else if (current->right == nullptr)
        {
            if (parent && parent->left == current){
                parent->left = current->left;
                delete current;
                return parent->left;
            } else if (parent && parent->right == current){
                parent->right = current->left;
                delete current;
                return parent->right;
            } else {
                s = current->left;
                head = s;
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
        void copy_tree(Tree* output_node)
        {
            copy_tree_recursion(head, &output_node->head);
        }
        */
        
        void print_tree()
        {
            print_tree_recursion(head);
        }
	

        Tree &operator = (const Tree &tree) 
        {
            if (this == &tree) {
                return *this;
            }
            else {
                delete_tree_recursion(this->head);
                head = insert_node_recursion(this->head, tree.head);
            }
            return *this;
        }


        Node* search(int key)
        {
            return search_recursion(head, key);
        }


    private:
		void insert_recursion(Node* node, int key, int value)
		{
			if(key < node->key){
				if(node->left == nullptr) node->left = new Node(key, value);
				else insert_recursion(node->left, key, value);
			}
		
			if(key >= node->key){
				if(node->right == nullptr) node->right = new Node(key, value);
				else insert_recursion(node->right, key, value);
			}
		}
		
		
		Node* get_min_recursion(Node* node)
		{
			if(node == nullptr) return nullptr;
			if(node->left == nullptr) return node;
			return get_min_recursion(node->left);
		}
		
		
		Node* get_max_recursion(Node* node)
		{
			if(node == nullptr) return nullptr;
			if(node->right == nullptr) return node;
			return get_max_recursion(node->right);
		}
		
		/*
		Node* delete_recursion(Node* node, int key)
		{
			if(node == nullptr) return nullptr;
			else if(key < node->key) node->left = delete_recursion(node->left, key);
			else if(key > node->key) node->right = delete_recursion(node->right, key);
			else{
				if(node->left == nullptr || node->right == nullptr)
					node = (node->left == nullptr) ? node->right : node->left;
				else{
					Node* max_ln_left =  get_max_recursion(node->left);
					node->key = max_ln_left->key;
					node->value = max_ln_left->value;
					node->right = delete_recursion(node->right, max_ln_left->key);			
				}
			
			}
			
			return node;
		}
        */
        /*
        void copy_tree_recursion(Node* node, Node** input_node)
        {
            if (node) {
                *input_node = new Node(node->key, node->value);

                if(node->left != nullptr){
                    (*input_node)->left = new Node();
                    copy_tree_recursion(node->left, &(*input_node)->left);
                }

                if(node->right != nullptr){
                    (*input_node)->right = new Node();
                    copy_tree_recursion(node->right, &(*input_node)->right);
                }
            }
            else {
                input_node = nullptr;
            }
        }
        */

        void print_tree_recursion(Node* node)
        {
            if(node == nullptr) return;
            print_tree_recursion(node->left);
            cout << node->key << " ";
            print_tree_recursion(node->right);
        }


        void delete_tree_recursion(Node* node) 
        {
            if (node) {
                delete_tree_recursion(node->left);
                delete_tree_recursion(node->right);
                delete node;
            }
        }


        Node* insert_node_recursion(Node *in, Node *from) 
        {
            if (!from) {
                return nullptr;
            }
            else {
                in = new Node(from->key, from->value);
                in->left = insert_node_recursion(in->left, from->left);
                in->right = insert_node_recursion(in->right, from->right);
                return in;
            }
        }


        Node* search_recursion(Node* node, int key)
        {
            if(node == nullptr) return nullptr;
            if(node->key == key) return node;
            return(key < node->key) ? search_recursion(node->left, key) : search_recursion(node->right, key);
        }
};




int main()
{
    Tree A(6, 100);
    A.insert(5, 200);
    A.insert(8, 500);
    
    A.insert(2, 200);
    A.insert(1, 200);


	
    A.Delete(8);
	Node* a = A.get_max();
    cout << "max = " << a->get_key() << endl;


    Tree copy_tree_test;
    copy_tree_test = A;
    copy_tree_test.print_tree();
    cout << endl;



    Node* test_search = copy_tree_test.search(1);
    cout << "find node: " << test_search->get_key();
    cout << endl;
    
    
    Tree copyConst(copy_tree_test);
    copyConst.print_tree();

    return 0;
}