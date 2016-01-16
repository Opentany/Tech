#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <pthread.h>
#include <unistd.h>
#include <semaphore.h>
#include <stdbool.h>

sem_t widelce[5];

bool wait = true;

unsigned long int iloscZjedzen[5] = {0, 0, 0, 0, 0};

typedef struct
{
	int id;
} filozof_args;


//Jeœli obok mnie siedzi osoba która zjad³a 2 potrawy mniej ode mnie bêdê czekaæ
bool czyMogeZjesc(int id)
{

	int lewy = id - 1;
	int prawy = id + 1;

	if (prawy > 4)
	{
		prawy = 0;
	}

	if (lewy < 0)
	{
		lewy = 4;
	}


	if (iloscZjedzen[id] > iloscZjedzen[lewy] + 2 || iloscZjedzen[id] > iloscZjedzen[prawy] + 2)
	{
		return false;
	}

	return true;

}

void filozof(void *args)
{

	filozof_args *actual_args = args;

	int id = actual_args->id;

	int lewy = id - 1;

	if (lewy < 0)
	{
		lewy = 4;
	}

	int prawy = id;

	//Czekamy na wszystkich filozofów
	while (wait)
	{
		sleep(1);
	}

	printf("%d: Wejœcie\n", id);

	while (1)
	{
		start:

		sleep(rand() % 5);
		
		if (!czyMogeZjesc(id)) //anty zag³odzenie
		{
			goto start;
		}

		//Wziêcie prawego widelca
		sem_wait(&widelce[prawy]);

		//Aby wyst¹pi³o zablokowanie
		sleep(rand() % 5);

		int max = rand() % 5;
		int temp = 0;

		//Próba wziêcia lewego widelca
		while (sem_trywait(&widelce[lewy]) == -1)
		{
			if (temp > max)
			{
				//Jeœli nam siê nie uda, odk³adamy prawy i czekamy (anty zakleszczenie)
				sem_post(&widelce[prawy]);
				goto start;
			}

			sleep(1);
			temp++;

		}

		printf("%d: JEM\n", id);
		iloscZjedzen[id]++;
		sleep(rand() % 5);
		sem_post(&widelce[prawy]);
		sem_post(&widelce[lewy]);
		printf("%d: MYŒLÊ\n", id);
	}

}


int main(void)
{

	for (int i = 0; i < 5; i++)
	{
		sem_init(&widelce[i], 0, 1);
	}

	pthread_t tid[5];

	int err;

	for (int i = 0; i < 5; i++)
	{

		filozof_args *args = malloc(sizeof *args);

		args->id = i;

		err = pthread_create(&(tid[i]), NULL, filozof, args);

		if (err != 0)
		{
			printf("\ncan't create thread :[%s]", strerror(err));
		}

	}

	wait = false;

	while (1)
	{
		sleep(10000);
	}

	return 0;
}