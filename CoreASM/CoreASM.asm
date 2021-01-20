.code
streq_ASM proc
; streqASM(char* str1, char* str2)
; str1 RCX
; str2 RDX
	mov rax, rcx
	sub rax, rdx
	sub rdx, 16

	streqLoop:
		add rdx, 16
		movdqu xmm0, xmmword ptr[rdx]
		pcmpistri xmm0, xmmword ptr[rdx + rax], 00011000b	; 0y11000 - negative polarity, equal each, unsigned byte
		ja streqLoop	; ZF == CF == 0, all chars equal and valid
		
	jc streqDiff	; CF == 1, strings are not equal
	mov rax, 1
	jmp streqRet

	streqDiff:
	mov rax, 0
	streqRet:
	ret
streq_ASM endp

contains_ASM proc
; bool contains_ASM(char** words, const char* s, unsigned size, unsigned* index)
; words RCX
; s		RDX
; size	R8
; index	R9

	push rbp
	mov rbp, rcx	; store words in rbp
	mov rcx, 0		; rcx as iterator
	forLoop:
		cmp rcx, r8	; (rcx == size)
		je endLoop
		mov rax, [rbp + rcx * 8]	; rax = words[rcx]

		push rcx
		push rdx
		mov rcx, rax
		call streq_ASM
		pop rdx
		pop rcx

		cmp rax, 1
		je foundIt
		inc ecx
		jmp forLoop
	endLoop:	
	mov rax, 0		; return 0
	jmp finish

	foundIt:
	mov [r9], ecx	; *index = iterator
	mov rax, 1		; return 1

	finish:
	pop rbp
	ret
contains_ASM endp

end