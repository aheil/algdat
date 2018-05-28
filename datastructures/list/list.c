#include <stdio.h>
#include <stdlib.h>

struct listNode {
    int i;                          // Datenfeld
    struct listNode *lN;            // Zeiger auf nächsten Listeneintrag
};

int main(void)
{
  
struct listNode  ln1 = {5, NULL}; 
struct listNode ln2 = {7, NULL};

ln1.lN = &ln2;               

printf("%i", ln1.lN->i);            // gibt 7 aus


  return EXIT_SUCCESS;
}