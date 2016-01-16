global function1
global function2
global function3
global function4

section .data

temp dd 0.0


section .text


function1:
	; ln(n)
	push ebp
	mov ebp, esp

	fldln2			; załaduj ln(2)
	fld DWORD [ebp+0x8]	; załaduj x
	fyl2x			; oblicz ln(2)*log_2(x) = ln(x)
	pop ebp
	ret


function2:
	; e^(x)
	push ebp
	mov ebp, esp
	fld DWORD [ebp+0x8]

	fldl2e			;ładuje x, potem log2(e)
	fmul			;mnoże (=xlog2(e))
	fld st0			;zapamiętuje na stosie
	frndint			;biorę częśc całkowitą
	fsub			;otrzymuje część ułamkową
	f2xm1			;obliczam 2^frac(xlog2(e)) - 1 (w tym opcodzie może być tylko częśc ułamkowa) *
	fld1			;ładuje 1
	fadd			; uzyskuje ułamkową częśc e^x
	fld DWORD [ebp+0x8]	;ładuje x
	fldl2e			;ładuje log2(e)
	fmul			;mnoże (j.w.)
	frndint			;częśc całkowita
	fld1			;"1"
	fscale			; obliczam 1*2^int(log2(e)) &
	fxch st1		; ustawiam * i & na górze stosu
	fxch st2
	fmul			;uzyskuje wynik
	pop ebp
	ret


function3:
	; sinh(x)
	push ebp
	mov ebp, esp

	finit

	mov eax, [ebp+0x8]	;wpisuje słowo do tymczasowej zmiennej
	mov [temp], eax

	fld DWORD [temp]
	fchs			;zmiana znaku
	fst DWORD [temp]	;zapamiętuje odwrotność

	mov eax, [temp]
	push eax
	call function2		; licze e^(-x) wynik na stosie
	add esp, 4
	
	fld DWORD [temp]	
	fchs			;wracam znak
	fst DWORD [temp]	;zapamiętuje

	mov eax , [temp]
	
	push eax
	call function2		;obliczam e^(x) wynik na stosie
	add esp, 4

	fxch st1		;ustawiam oba wyniki na górze stosu
	fxch st3
	
	fsub			; e^x - e^(-x)

	fld1			;"1"
	fld1			;duplikuje "1"
	faddp			;1+1 = 2 !
	fdivp			; dziele przez owe 2

	pop ebp
	ret


function4:
	;sinh^-1(x)
	push ebp
	mov ebp, esp

	finit

	mov eax, [ebp+0x8]	;przepisuje liczbe do tymczasowej zmiennej
	mov [temp], eax

	fld DWORD [temp]	;duplikuje ją
	fld DWORD [temp]
	fmul			;liczę kwadrat

	fld1			;"1"
	faddp			;"x^2 + 1
	fsqrt			; pierwiastek z tego wyżej
	fld DWORD [temp]	; 
	faddp			; pierwiastek + x
	fst DWORD [temp]	; zapamiętuje to na szczycie stosu

	mov eax, [temp]
	push eax
	call function1		; i licze ln(x) x to zapamiętana na szczycie stosu liczba
	add esp, 4
	pop ebp
	ret
