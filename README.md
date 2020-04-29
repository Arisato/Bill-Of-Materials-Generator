## Introduction

You are a developer at a company that makes different kind of widgets.
You have been tasked with writing a Bill of Materials generator (“System”).
The output of your System will be fed into the company’s legacy Widget Builder (“Builder”) that builds the widgets.

The company currently builds five different kinds of widgets with the following properties:

Rectangle
* Position X - integer
* Position Y - integer
* Width - integer
* Height - integer

Square
* Position X - integer
* Position Y - integer
* Width - integer

Ellipse
* Position X - integer
* Position Y - integer
* Horizontal Diameter - integer
* Vertical Diameter - integer

Circle
* Position X - integer
* Position Y - integer
* Diameter - integer

Textbox
* Position X - integer
* Position Y - integer
* Width - integer
* Height - integer
* Text - string

For the test, you must build a System that generates a Bill of Materials for the following input:

1 x Rectangle\
Position X - 10\
Position Y - 10\
Width - 30\
Height - 40

1 x Square\
Position X - 15\
Position Y - 30\
Width - 35

1 x Ellipse\
Position X - 100\
Position Y - 150\
Horizontal Diameter - 300\
Vertical Diameter - 200

1 x Circle\
Position X - 1\
Position Y - 1\
Diameter - 300

1 x Textbox\
Position X - 5\
Position Y - 5\
Width - 200\
Height - 100\
Text - sample text

This is the expected output of your System:\
\---------------------------------------------------------------\-\
Bill of Materials\
\---------------------------------------------------------------\-\
Rectangle (10,10) width=30 height=40\
Square (15,30) size=35\
Ellipse (100,150) diameterH = 300 diameterV = 200\
Circle (1,1) size=300\
Textbox (5,5) width=200 height=100 text="sample text"\
\---------------------------------------------------------------\-

The Builder is very old and cannot be modified or replaced, so your System output must match exactly what the Builder is expecting as input.

When you cannot output a valid Bill of Materials from your System, you must output the string “+++++Abort+++++”, as this is the only error condition the Builder understands. Anything else will cause the Builder to crash, and thousands of pounds of production time will be lost.
You must log all errors in your system for manual investigation at a later date.

The widgets are plotted on a square canvas 1000 units in width and height, starting at 0,0 in the bottom left corner. The other integer properties must be positive, and the textbox’s Text property is optional. This is the only validation required.

For the purposes of the test, your System should have an application that takes the input, validates it and generates a Bill of Materials. 
The input can be hardcoded, but the system must be easily modifiable.

Your System must be architected so that the Bill of Materials output can be consumed by a variety of applications, not just the Builder. For the test it is sufficient to write the output to the screen. It should be written in C# and should take into account reusability & modularity. 