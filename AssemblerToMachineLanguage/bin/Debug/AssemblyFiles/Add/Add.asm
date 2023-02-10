// This file is part of www.nand2tetris.org
// and the book "The Elements of Computing Systems"
// by Nisan and Schocken, MIT Press.
// File name: projects/06/add/Add.asm

// Computes R0 = 2 + 3  (R0 refers to RAM[0])


@2 // dette er et 2 tal
D=A
@3
D=D + A // whitespace og inline comment
@0
M=D
