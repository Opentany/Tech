#include "myfunctions.h"

int main(int argc, char *argv[])
{

	int test=0;

	myprintf("**** Program testuj�cy do funkcji myprinf i myscanf **** \nProsz� wpisa� liczb� ca�kowit�\n");

	myscanf("%d", &test);

	myprintf("Wpisa�e� liczb� \n%d (base 10)\n%b (base 2)\n%x (base 16)\n", test, test, test);

	myprintf("Prosz� wpisa� liczb� binarn�\n");

	myscanf("%b", &test);

	myprintf("Wpisa�e� liczb� \n%d (base 10)\n%b (base 2)\n%x (base 16)\n", test, test, test);

	myprintf("Prosz� wpisa� liczb� szestnastkow�\n");

	myscanf("%x", &test);

	myprintf("Wpisa�e� liczb� \n%d (base 10)\n%b (base 2)\n%x (base 16)\n", test, test, test);

	return 0;
}