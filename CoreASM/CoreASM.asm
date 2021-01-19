.code
contains_ASM proc
;bool contains_ASM(char** words, unsigned size, const char* s, unsigned* index);
; words RCX
; size  RDX
; s		R8
; index	R9

push rbp
mov rbp, rcx
mov rcx, 0
forLoop:
	cmp ecx, edx
	je endLoop



	inc ecx
	jmp forLoop
endLoop:	
mov rax, 0
jmp finish
foundIt:
mov [r9], ecx
mov rax, 1
finish:
pop rbp
ret
contains_ASM endp


test_ASM proc
;bool test_ASM(int* words, unsigned size, const int s, unsigned* index);
; words RCX
; size  RDX
; s		R8
; index	R9

push rbp
mov rbp, rcx
mov rcx, 0
mov rbx, r8

forLoop:
	cmp rcx, rdx
	je endLoop
	mov eax, [rbp + rcx * 4]
	cmp eax, ebx
	je foundIt
	inc cx
	jmp forLoop
endLoop:	
mov rax, 0
jmp finish
foundIt:
mov [r9], ecx
mov rax, 1
finish:
pop rbp
ret
test_ASM endp

end