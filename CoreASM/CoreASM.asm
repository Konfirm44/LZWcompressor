.code
MyProc1 proc
add RCX, RDX
add RCX, RCX
mov RAX, RCX
ret
MyProc1 endp

MyProc2 proc
add RCX, RCX
mov RAX, RCX
ret
MyProc2 endp
end