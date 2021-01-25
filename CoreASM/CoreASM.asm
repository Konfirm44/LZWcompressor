;/**
; * Algorytm kompresji LZW
; * 
; * Tomasz Sitek, gr. 3
; * Jêzyki Asemblerowe, sekcja 2
; * informatyka SSI 2020/2021, semestr zimowy
; * 
; * wersja 1.0
; */

.code

;// Returns 1 in RAX if the C-string arguments are equal, else returns 0.
;// char* str1 - C-string to be compared (not null)
;// char* str2 - C-string to be compared (not null)

streq_ASM proc
; streqASM(char* str1, char* str2)
; str1 RCX
; str2 RDX
	mov rax, rcx
	sub rax, rdx
	; RAX contains the difference between both strings' adresses

	sub rdx, 16		; prepare for loop
	streqLoop:
		add rdx, 16
		movdqu xmm0, xmmword ptr[rdx]
		pcmpistri xmm0, xmmword ptr[rdx + rax], 00011000b	; 00011000b - mode/return setting
		ja streqLoop	; ZF == CF == 0, all chars equal and valid
		
		jc streqDiff	; CF == 1, strings are not equal
		
		mov rax, 1		; return true
		jmp streqRet

	streqDiff:
	mov rax, 0		; return false
	streqRet:
	ret
streq_ASM endp


;// Assembly language implementation of the Dictionary_ASM::contains() method.
;// Returns true if the dictionary contains the word.
;// char** words - array of C-strings to search in (not null)
;// const char* str - C-string to search for (not null)
;// unsigned words_size - size of the array
;// unsigned* index - variable where the index of the found element will be placed (not null)

contains_ASM proc
; bool contains_ASM(char** words, const char* s, unsigned size, unsigned* index)
; words RCX
; s		RDX
; size	R8
; index	R9

	push rbp
	mov rbp, rcx	; store words in RBP
	mov rcx, 0		; RCX as iterator
	forLoop:
		cmp rcx, r8	; (RCX == size)
		je endLoop
		mov rax, [rbp + rcx * 8]	; RAX = words[iterator]

		; save registers and prepare arguments for function call
		push rcx
		push rdx
		mov rcx, rax
		call streq_ASM	; check if strings are equal
		; restore registers
		pop rdx
		pop rcx

		cmp rax, 1	; function returned true
		je foundIt
		inc ecx		; ++iterator
		jmp forLoop

	endLoop:	
	mov rax, 0		; return 0
	jmp finish

	foundIt:
	mov [r9], ecx	; *index = iterator
;	mov rax, 1		; return 1				redundant - foundIt is jumped to when rax is already 1

	finish:
	pop rbp
	ret
contains_ASM endp


;// Assembly language implementation of a section of the Dictionary_ASM constructor.
;// Fills the "words" array of allocated C-strings with the initial 256 words of an LZW dictionary.
;// char** words - array of C-strings with 256 allocated elements, each 2 characters long
dictionaryInit_ASM proc
; void dictionaryInit_ASM(char** words);
; words	RCX

	push rbx
	push rdi
	mov rbx, rcx	; store words in RBX
	mov rcx, 0		; RCX = 0
	for256:
		mov rdi, [rbx + rcx * 8]		; RSI = words[RCX]
		mov [rdi], cl					; words[0] = RCX
		mov byte ptr[rdi + 1], 0		; words[1] = 0

		inc ecx			
		cmp ecx, 256	
		jne for256

	pop rdi
	pop rbx
	ret
dictionaryInit_ASM endp
end