// Pseudo kode
// computes RAM[1] = 1+2+ ... + RAM[0]

//     n = R0
//     i = 1
//     sum = 0
//   LOOP:
//     if i > n goto STOP
//     sum = sum + i
//     i = i + 1
//     goto STOP

//   STOP
//     R1 = sum

    @R0
    D=M
    @n
    M=D // n = R0
    @i
    M=1 // i = 1
    @sum
    M=0 // sum = 0
  (LOOP)
    @i
    D=M
    @n
    D=D-M
    @STOP
    D;JGT // if i > n goto STOP
    @sum
    D=M
    @i
    D=D+M
    @sum
    M=D
    @i
    M=M+1 // i = i + 1
    @LOOP
    0;JMP
  (STOP)
    @sum
    D=M
    @R1 
    M=D // RAM[1] (R1) = sum
  (END)
    @END
    0;JMP