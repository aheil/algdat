#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

struct listType {
    struct listNode *head;          // Head node for list
};

struct listNode {
    int i;                          // data field
    struct listNode *lN;            // pointer for next list node
};

 bool isEmpty(struct listType list) {
    if (list.head == NULL) 
        return true;
    else
        return false;
};

int main(void) {
  
    struct listType list = { NULL };
    
    printf("%i", isEmpty(list));
  
//    struct listNode ln1 = {5, NULL}; 
//    struct listNode ln2 = {7, NULL};

//    ln1.lN = &ln2;               

//    printf("%i", ln1.lN->i);            // gibt 7 aus

    return EXIT_SUCCESS;
}