global main
extern printf


section .text

main:

	; Wypełnianie tabeli liczbami
	mov ecx, 10000


fill_loop:
	mov [array+ecx*4], ecx ; ustawienie miejsca tablicy i wpisanie tam liczby (mlejąco)
	loop fill_loop ; pętla która będzie wracać do fill_loop aż ecx = 0

	mov ecx, 5000 ; ecx = 5000

	mov edx, 2 ; edx = 2

	; pętle wyszukujące liczby NIE pierwsze, wyszukuje wielokrotności liczb od 2 do 5000
	; pozostałe to liczby pierwsze
outer_loop:
	cmp edx, 5000 
	jge outer_end

	mov eax, edx ; ustawienie rejestrów do porównań
	mov ebx, edx

	;szukanie wielokrotności
inner_loop:
	add eax,ebx
	cmp eax, 10000 ; póki wielokrotność jest niewiększa niż 10000
	jge inner_end
	mov word [array+eax*4], 0x0	; wielokrotności w tabeli są zerowane
	jmp inner_loop


inner_end:
	inc edx

	jmp outer_loop

	; czyszczenie i przygotowanie pod drukowanie
outer_end:
	mov eax, 2
	mov ebx, 0
	mov ecx, 0
	mov edx, 0

	
print_loop:
	cmp eax, 10000
	jge the_end

	mov ebx, [array+eax*4]	; ustawiam kolejne liczby (x4 bo rezewuje miejsce dla 32 bitów - 4 bajty) 
	cmp ebx, 0 	; tam gdzie są zera pomijam
	je increase

	push eax
	push dword ebx
	push message ; na stosie lądują kolejno od dołu aktualna wartość (zapis), słowo w tablicy (argument dla printf), wzór wiadomości dla printf
	call printf	; printf zbierze ze stosu message, znajdzie odwołanie do wartości int, więc ze stosu zabierze wartośc odłożoną z ebx. wartość eax zostanie nietknięta na stosie
	add esp, 8

	pop eax	; odzyskanie wartości eax


increase:
	inc eax

	jmp print_loop


the_end:
	push newline
	call printf
	add esp, 4
	
	ret


section .data
message db '%d, ', 0
newline db 10,0

section .bss
array resd 10000

