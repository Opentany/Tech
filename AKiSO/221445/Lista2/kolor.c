#include <stdio.h>
int main(void)

{

  const char *const normal = "\033[0m";

  int i=0;

  for(i;i<256;i++)

  {

        char color[20];

        char str[15];

        sprintf(str, "%d", i);

        strcpy(color, " \x1b[38;5;");

        strcat(color, str);

        strcat(color, "m");

        printf("%sHello World%s\n", color, normal);
    
 
  }

  return 0;

}