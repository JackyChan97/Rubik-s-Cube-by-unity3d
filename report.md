### 1. Objectives

​	Write a system to realize a 3*3 magic cube. At the same time your system must meet the following requirements:

​	(1) By using the mouse, the whole magic cube needs to be rotated. And by using the mouse and the keyboard, the row or the column of the magic cube needs to be rotated.

​	(2) You need to make an animation about the rotation of the whole magic cube, the row of the magic cube and the column of the magic cube.

​	(3) The texture of the magic cube needs to be changed by keyboard. Also, you need to achieve point lights and spotlight effect. Besides the type and the parameter of the light source need to be changed by using the keyboard.

### 2. Involved Knowledge

​	(1) Get a knowledge of how to use the Maya to build a 3D Rubik's-Cube.

​	(2) Use the transformation matrix learned in class to rotate the whole Rubik's-Cube though the original point and rotate each raw and column of the Rubik's-Cube by using mouse and keyboard.

​	(3) Use the illumination knowledge learned in class to achieve point lights direction lights and spot lights effect on the face of the Rubik's-Cube by Unity.

​	(4) The knowledge of how to use the unity3D.

#### 3. Design scheme

**Model building**

​	Because each face of the cubes are different. If we want to change the color of a cube in unity we need to create a material and map this material onto the surface of the cube. So it is a difficult task for us to build a model in unity. So we use the professional model building software Maye to build this model.

​	Firstly we build 27 cubes in Maya and arrange those cubes into the shape of Rubik's-Cube. And then we color each surface of the cube, and build up a Rubik's-Cube. The model is shown below.

![1543657031124](C:\Users\chenz\AppData\Roaming\Typora\typora-user-images\1543657031124.png)

**Rotation**









