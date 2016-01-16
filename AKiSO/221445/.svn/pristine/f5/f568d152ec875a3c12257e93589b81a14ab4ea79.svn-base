SECTION .data

formatd: db "%d", 0
formatx: db "%08x", 0
newline: db " ", 10, 0

SECTION .bss

name: resb 20
number: resb 4

array: resd 4
backup: resd 4


SECTION .text

extern printf
extern scanf

global main                    


main:
	push EBP
	mov EBP, ESP

	push number
	push formatd
	call scanf ; pobiera liczbe z stdin
	add ESP, 8

	mov ebx, dword [number]

	mov dword [array+0], 0x0 ; czyszczenie liczby wynikowej i jej bufora zapasowego
	mov dword [array+4], 0x0
	mov dword [array+8], 0x0
	mov dword [array+16], 0x0

	mov dword [backup+0], 0x0
	mov dword [backup+4], 0x0
	mov dword [backup+8], 0x0
	mov dword [backup+16], 0x0

	mov [array+0], eax

	; działanie: załadowanie "n", potem dodanie jej do siebie (n-1) razy. outer loop powtarza aż dojdzie do 1
outer_loop:
	cmp ebx, 0x1
	je end

	mov eax, [array+0]
	mov [backup+0], eax

	mov eax, [array+4]
	mov [backup+4], eax

	mov eax, [array+8]
	mov [backup+8], eax
	
	mov eax, [array+12]
	mov [backup+12], eax

	mov ecx, ebx
	dec ecx


inner_loop:
	clc ; początkowo wszystkie flagi wyłączone

	; Dodawanie 128 bitowej liczby. dodawanie z carry w razie przepełnienia
			
	mov eax, [backup+0]
	adc [array+0], eax
	
	mov eax, [backup+4]
	adc [array+4], eax

	mov eax, [backup+8]
	adc [array+8], eax

	mov eax, [backup+12]
	adc [array+12], eax

	clc

	loop inner_loop

	dec ebx

	jmp outer_loop

	; wypisuje od końca - odwrócona kolejność
end:
	push dword [array+12]
	push formatx
	call printf
	add ESP, 8

	push dword [array+8]
	push formatx
	call printf
	add ESP, 8

	push dword [array+4]
	push formatx
	call printf
	add ESP, 8

	push dword [array+0]
	push formatx
	call printf
	add ESP, 8

	push newline	; wydrukuj znak nowej linii
	call printf
	add ESP, 4

	mov ESP, EBP
	pop EBP

	ret
